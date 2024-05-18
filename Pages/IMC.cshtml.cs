using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization; // Añadir esta línea para usar CultureInfo

namespace Práctica1.Pages
{
	public class IMCModel : PageModel
	{
		// Definimos propiedades
		[BindProperty]
		public string peso { get; set; } = "";

		[BindProperty]
		public string altura { get; set; } = "";

		public double imc;
		public string clasificacion;
		public double metros_cuadrados;

		public void OnPost()
		{
			// Recibimos los datos
			double peso_double = double.Parse(peso, CultureInfo.InvariantCulture);
			double altura_double = double.Parse(altura, CultureInfo.InvariantCulture);

			metros_cuadrados = Math.Pow(altura_double, 2);

			// Calculamos el índice de masa corporal
			imc = peso_double / metros_cuadrados;

			// Clasificamos el IMC
			if (imc < 18)
			{
				clasificacion = "Peso Bajo";
			}
			else if (imc >= 18 && imc < 25)
			{
				clasificacion = "Peso Normal";
			}
			else if (imc >= 25 && imc < 27)
			{
				clasificacion = "Sobrepeso";
			}
			else if (imc >= 27 && imc < 30)
			{
				clasificacion = "Obesidad grado I";
			}
			else if (imc >= 30 && imc < 40)
			{
				clasificacion = "Obesidad grado II";
			}
			else if (imc >= 40)
			{
				clasificacion = "Obesidad grado III";
			}

			// Limpiamos el estado del modelo
			ModelState.Clear();
		}
	}
}
