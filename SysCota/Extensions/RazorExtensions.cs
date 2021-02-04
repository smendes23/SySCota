using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace SysCota.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatarData(this RazorPage page, string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            return Convert.ToDateTime(data).ToString("dd/MM/yyyy");
        }

        public static string FormatarDocumento(this RazorPage page, string tipo, string documento)
        {
            return tipo.Equals("cpf") ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataNomeSexo(this RazorPage page, string sexo)
        {
            return sexo.Equals("F") ? "Feminino" : "Masculino";
        }

        public static string FormataMoeda(this RazorPage page, decimal valor)
        {
            return valor.ToString("C");
        }

        public static string FormatarDescricaoTrim(this RazorPage page, string descricao)
        {
            if(descricao == null)
            {
                descricao = "Sem informação";
            }

            return descricao.Length <= 25 ? descricao : descricao = descricao.Substring(0, 25) + "...";
        }

        public static string DevelopedBy(this RazorPage page)
        {
            return " Saulo Mendes";
        }
    }
}
