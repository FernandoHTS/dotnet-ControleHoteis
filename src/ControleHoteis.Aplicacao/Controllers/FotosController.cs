using AutoMapper;
using ControleHoteis.Aplicacao.ViewModels;
using ControleHoteis.Negocio.Interfaces;
using ControleHoteis.Negocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ControleHoteis.Aplicacao.Controllers
{
    public class FotosController : Controller
    {

        private readonly IFotoRepository _fotoRepository;
        private readonly IMapper _mapper;

        public FotosController(IFotoRepository fotoRepository, IMapper mapper)
        {            
            _fotoRepository = fotoRepository;
            _mapper = mapper;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarFoto(FotoViewModel fotoViewModel)
        {

            if (fotoViewModel.ImagemUploads != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(fotoViewModel.ImagemUploads, fotoViewModel.TipoProprietarioFoto, imgPrefixo))
                {
                    return View(fotoViewModel);
                }

                fotoViewModel.Imagem = imgPrefixo + fotoViewModel.ImagemUploads.FileName;

            }

            if (!ModelState.IsValid) return PartialView("_Foto", fotoViewModel);


            var fotoAtual = new FotoViewModel();
            fotoAtual.DescricaoFoto = fotoViewModel.DescricaoFoto;
            fotoAtual.ProprietarioFotoId = fotoViewModel.ProprietarioFotoId;
            fotoAtual.TipoProprietarioFoto = fotoViewModel.TipoProprietarioFoto;
            fotoAtual.ImagemUploads = fotoViewModel.ImagemUploads;
            fotoAtual.Imagem = fotoViewModel.Imagem;

            await _fotoRepository.Adicionar(_mapper.Map<Foto>(fotoAtual));            

            return RedirectToAction("Edit", fotoViewModel.TipoProprietarioFoto, new { Id = fotoViewModel.ProprietarioFotoId });

        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string tipoProprietarioFoto, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/" + tipoProprietarioFoto);

            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), caminho, imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        
        public async Task<IActionResult> DeletarFoto(Guid id)
        {
            var fotoViewModel = await _fotoRepository.ListarPorId(id);

            if (fotoViewModel == null) return NotFound();

            await _fotoRepository.Remover(fotoViewModel.Id);

            return RedirectToAction("Edit", fotoViewModel.TipoProprietarioFoto, new { Id = fotoViewModel.ProprietarioFotoId });
        }

        public async Task<IActionResult> ListarFotos(Guid idProprietarioFoto, string tipoProprietarioFoto)
        {
            var fotos = await _fotoRepository.ListarFotosPorProprietarioFoto(idProprietarioFoto, tipoProprietarioFoto);

            return PartialView("_ListaFotos", fotos);
        }

    }
}
