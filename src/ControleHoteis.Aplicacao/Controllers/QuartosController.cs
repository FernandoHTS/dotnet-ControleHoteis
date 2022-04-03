using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleHoteis.Aplicacao.Data;
using ControleHoteis.Aplicacao.ViewModels;
using ControleHoteis.Negocio.Interfaces;
using AutoMapper;
using ControleHoteis.Negocio.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ControleHoteis.Aplicacao.Controllers
{
    public class QuartosController : Controller
    {
        private readonly IQuartoRepository _quartoRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IFotoRepository _fotoRepository;
        private readonly IMapper _mapper;

        public QuartosController(IQuartoRepository quartoRepository, IHotelRepository hotelRepository, IFotoRepository fotoRepository, IMapper mapper)
        {
            _quartoRepository = quartoRepository;
            _hotelRepository = hotelRepository;
            _fotoRepository = fotoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<QuartoViewModel>>(await _quartoRepository.ListarQuartosHoteis()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var quartoViewModel = await ListarQuarto(id);
            if (quartoViewModel == null)
            {
                return NotFound();
            }

            return View(quartoViewModel);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var quartoViewModel = await PopularHoteis(new QuartoViewModel());
            return View(quartoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuartoViewModel quartoViewModel)
        {
            quartoViewModel = await PopularHoteis(quartoViewModel);

            if (!ModelState.IsValid) return View(quartoViewModel);            

            await _quartoRepository.Adicionar(_mapper.Map<Quarto>(quartoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var quartoViewModel = await ListarQuarto(id);
            quartoViewModel.Fotos = _mapper.Map<IEnumerable<FotoViewModel>>(await _fotoRepository.ListarFotosPorProprietarioFoto(quartoViewModel.Id, "Quartos"));

            if (quartoViewModel == null)
            {
                return NotFound();
            }

            return View(quartoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, QuartoViewModel quartoViewModel)
        {
            if (id != quartoViewModel.Id) return NotFound();            

            var quartoAtualizacao = await ListarQuarto(id);
            quartoViewModel.Hotel = quartoAtualizacao.Hotel;            
            if (!ModelState.IsValid) return View(quartoViewModel); 

            quartoAtualizacao.Nome = quartoViewModel.Nome;
            quartoAtualizacao.QtdOcupantes = quartoViewModel.QtdOcupantes;
            quartoAtualizacao.QtdAdultos = quartoViewModel.QtdAdultos;
            quartoAtualizacao.QtdCriancas = quartoViewModel.QtdCriancas;
            quartoAtualizacao.Valor = quartoViewModel.Valor;           

            await _quartoRepository.Atualizar(_mapper.Map<Quarto>(quartoAtualizacao));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ListarQuarto(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _quartoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CadastrarFoto(Guid id)
        {

            var quarto = await ListarQuarto(id);

            if (quarto == null)
            {
                return NotFound();
            }

            return PartialView("../Shared/_Foto",new FotoViewModel { ProprietarioFotoId = quarto.Id, TipoProprietarioFoto = "Quartos" }) ;
        }        

        private async Task<QuartoViewModel> ListarQuarto(Guid id)
        {
            var quarto = _mapper.Map<QuartoViewModel>(await _quartoRepository.ListarQuartoHotel(id));
            quarto.Hoteis = _mapper.Map<IEnumerable<HotelViewModel>>(await _hotelRepository.ListarTodos());
            return quarto;
        }

        private async Task<QuartoViewModel> PopularHoteis(QuartoViewModel quarto)
        {
            quarto.Hoteis = _mapper.Map<IEnumerable<HotelViewModel>>(await _hotelRepository.ListarTodos());
            return quarto;
        }
       
    }
}
