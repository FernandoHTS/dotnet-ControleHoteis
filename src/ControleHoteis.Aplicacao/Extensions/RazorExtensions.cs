using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHoteis.Aplicacao.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataCNPJ(this RazorPage page, string cnpj)
        {
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

    }
}
