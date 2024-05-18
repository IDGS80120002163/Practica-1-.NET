using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Práctica1.Pages
{
    public class Programa4Model : PageModel
    {
        public int[] numeros_azar;
        public int[] numeros_ordenados;
        public int suma;
        public double promedio;
        public string moda;
        public double mediana;

        public Programa4Model()
        {
            numeros_azar = new int[0];
            numeros_ordenados = new int[0];
            suma = 0;
            promedio = 0;
            moda = string.Empty;
            mediana = 0;
        }

        public void OnGet()
        {
            GenerarNumerosAleatorios();
            CalcularSuma();
            CalcularPromedio();
            CalcularModa();
            CalcularMediana();
        }

        private void GenerarNumerosAleatorios()
        {
            Random rnd = new Random();
            numeros_azar = new int[20];
            numeros_ordenados = new int[20];
            for (int i = 0; i < numeros_azar.Length; i++)
            {
                int num = rnd.Next(0, 101);
                numeros_azar[i] = num;
                numeros_ordenados[i] = num;
            }
        }

        private void CalcularSuma()
        {
            suma = numeros_azar.Sum();
        }

        private void CalcularPromedio()
        {
            promedio = (double)suma / numeros_azar.Length;
        }

        private void CalcularModa()
        {
            int[] frecuencia = new int[101];
            foreach (int numero in numeros_azar)
            {
                frecuencia[numero]++;
            }

            int maxFrecuencia = frecuencia.Max();
            if (maxFrecuencia == 1)
            {
                moda = "No hay número que se repita";
            }
            else
            {
                var modaList = new List<int>();
                for (int i = 0; i < frecuencia.Length; i++)
                {
                    if (frecuencia[i] == maxFrecuencia)
                    {
                        modaList.Add(i);
                    }
                }
                moda = string.Join(", ", modaList);
            }
        }

        private void CalcularMediana()
        {
            Array.Sort(numeros_azar);
            if (numeros_azar.Length % 2 == 0)
            {
                mediana = (numeros_azar[numeros_azar.Length / 2 - 1] + numeros_azar[numeros_azar.Length / 2]) / 2.0;
            }
            else
            {
                mediana = numeros_azar[numeros_azar.Length / 2];
            }
        }
    }
}
