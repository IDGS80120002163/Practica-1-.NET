using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Práctica1.Pages 
{ 
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; }

        [BindProperty]
        public double B { get; set; }

        [BindProperty]
        public double X { get; set; }

        [BindProperty]
        public double Y { get; set; }

        [BindProperty]
        public int N { get; set; }

        public double Resultado { get; set; }

        public void OnPostCalcular()
        {
            Resultado = CalcularExpresion(A, B, X, Y, N);
        }

        private double CalcularExpresion(double a, double b, double x, double y, int n)
        {
            double resultado = 0;

            for (int k = 0; k <= n; k++)
            {
                double coeficiente = Factorial(n) / (Factorial(k) * Factorial(n - k));
                double termino1 = Math.Pow(a * x, n - k);
                double termino2 = Math.Pow(b * y, k);
                resultado += coeficiente * termino1 * termino2;
            }

            return resultado;
        }

        private double Factorial(int num)
        {
            if (num == 0)
                return 1;
            double resultado = 1;
            for (int i = 1; i <= num; i++)
                resultado *= i;
            return resultado;
        }
    }
}
