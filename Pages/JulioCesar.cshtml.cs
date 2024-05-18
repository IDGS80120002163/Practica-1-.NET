using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Práctica1.Pages
{
    public class JulioCesarModel : PageModel
    {
        [BindProperty]
        public string TextoEntrada { get; set; }

        [BindProperty]
        public int Desplazamiento { get; set; }

        public string TextoCodificado { get; set; }
        public string TextoDecodificado { get; set; }

        public void OnPost(string action)
        {
            switch (action)
            {
                case "Codificar":
                    TextoCodificado = CifrarCesar(TextoEntrada, Desplazamiento);
                    TextoDecodificado = null; // Asegúrate de que solo uno se muestre a la vez
                    break;
                case "Decodificar":
                    TextoDecodificado = CifrarCesar(TextoEntrada, -Desplazamiento);
                    TextoCodificado = null; // Asegúrate de que solo uno se muestre a la vez
                    break;
                default:
                    break;
            }
        }

        private string CifrarCesar(string texto, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();
            desplazamiento = desplazamiento % 26;

            foreach (char c in texto.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    char d = (char)((((c - 'A') + desplazamiento + 26) % 26) + 'A');
                    resultado.Append(d);
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }
    }
}
