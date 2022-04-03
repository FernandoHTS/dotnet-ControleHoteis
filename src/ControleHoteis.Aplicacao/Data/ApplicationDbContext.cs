using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ControleHoteis.Aplicacao.ViewModels;

namespace ControleHoteis.Aplicacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ControleHoteis.Aplicacao.ViewModels.HotelViewModel> HotelViewModel { get; set; }
        public DbSet<ControleHoteis.Aplicacao.ViewModels.EnderecoViewModel> EnderecoViewModel { get; set; }
        public DbSet<ControleHoteis.Aplicacao.ViewModels.QuartoViewModel> QuartoViewModel { get; set; }
    }
}
