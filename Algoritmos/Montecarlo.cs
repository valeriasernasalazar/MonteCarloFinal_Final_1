using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloFinal_F.Algoritmos
{
    internal class Montecarlo
    {
        public (double[,], string decripcion) Matriz(int rows, int cols, double lim_inf, double lim_sup)
        {
            double[,] matrix = new double[rows, cols];

            // Crear una instancia de la clase Random
            Random random = new Random();

            // Llenar la matriz con valores aleatorios
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double randomValue = random.NextDouble() * (lim_sup - lim_inf) + lim_inf;
                    matrix[row, col] = Math.Round(randomValue, 2); // rellena con el num random
                }
            }

            string descripcion = $"Matriz de {rows}x{cols} con limites [{lim_inf}, {lim_sup}]";

            return (matrix, descripcion);
        }

        public (List<double> PanelSeleccionado, string algo) Seleccion(double[,] matrix, int rows, int cols)
        {
            string algo = "";
            List<double> PanelSeleccionado = new List<double>();


            Random random = new Random();

            for (int row = 0; row < rows; row++)
            {
                int randCol = random.Next(0, cols);

                double valor = matrix[row, randCol];

                PanelSeleccionado.Add(valor);
            }
            return (PanelSeleccionado, algo);
        }

        public (List<double> estadisticos, string cosas) Calculos(List<double> PanelSeleccionado)
        {
            List<double> estadisticos = new List<double>();
            double avg = PanelSeleccionado.Average(); // promedio
            double cuadrados = PanelSeleccionado.Sum(x => Math.Pow(x - avg, 2)); // suma de los cuadrados
            double var = cuadrados / (PanelSeleccionado.Count - 1); // varianza
            double std = Math.Sqrt(var); // stdv
            estadisticos.Add(Math.Round(avg, 2));
            estadisticos.Add(Math.Round(std, 2));
            estadisticos.Add(Math.Round(var, 2));

            string cosas = "";

            return (estadisticos, cosas);
        }

    }
}
