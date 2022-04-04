using AutoMapper;
using ControleHoteis.Aplicacao.ViewModels;
using ControleHoteis.Negocio.Interfaces;
using ControleHoteis.Negocio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleHoteis.Aplicacao.Controllers
{
    public class HoteisController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IFotoRepository _fotoRepository;
        private readonly IMapper _mapper;

        public HoteisController(IHotelRepository hotelRepository, IFotoRepository fotoRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _fotoRepository = fotoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<HotelViewModel>>(await _hotelRepository.ListarTodos()));
        }
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModel hotelViewModel)
        {

            hotelViewModel.Endereco.Complemento = hotelViewModel.Endereco.Complemento == null ? "" : hotelViewModel.Endereco.Complemento;
            hotelViewModel.Cnpj = hotelViewModel.Cnpj.Replace(".","").Replace("/","").Replace("-","");

            if (!ModelState.IsValid)
                return View(hotelViewModel);

            var fornecedor = _mapper.Map<Hotel>(hotelViewModel);
            await _hotelRepository.Adicionar(fornecedor);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var hotelViewModel = await ListarHotelQuartosEndereco(id);
            hotelViewModel.Fotos = _mapper.Map<IEnumerable<FotoViewModel>>(await _fotoRepository.ListarFotosPorProprietarioFoto(hotelViewModel.Id, "Hoteis"));

            if (hotelViewModel == null)
            {
                return NotFound();
            }
            return View(hotelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, HotelViewModel hotelViewModel)
        {

            hotelViewModel.Endereco.Complemento = hotelViewModel.Endereco.Complemento == null ? "" : hotelViewModel.Endereco.Complemento;
            hotelViewModel.Cnpj = hotelViewModel.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            if (id != hotelViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(hotelViewModel);

            var hotel = _mapper.Map<Hotel>(hotelViewModel);
            await _hotelRepository.Atualizar(hotel);

            return RedirectToAction("Index");
        }        
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var hotelViewModel = await ListarHotelEndereco(id);

            if (hotelViewModel == null) return NotFound();

            await _hotelRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> CadastrarFoto(Guid id)
        {

            var hotel = await ListarHotelEndereco(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return PartialView("../Shared/_Foto", new FotoViewModel { ProprietarioFotoId = hotel.Id, TipoProprietarioFoto = "Hoteis" });
        }

        private async Task<HotelViewModel> ListarHotelEndereco(Guid id)
        {
            return _mapper.Map<HotelViewModel>(await _hotelRepository.ListarHotelEndereco(id));
        }

        private async Task<HotelViewModel> ListarHotelQuartosEndereco(Guid id)
        {
            return _mapper.Map<HotelViewModel>(await _hotelRepository.ListarHotelQuartosEndereco(id));
        }
    }
}
