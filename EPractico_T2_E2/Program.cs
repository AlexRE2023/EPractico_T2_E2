using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPractico_T2_E2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Trabajadores ");
            int numeroTrabajadores = int.Parse(Console.ReadLine());

            if (numeroTrabajadores < 1 || numeroTrabajadores > 1999)
            {
                Console.WriteLine("Trabajadores ");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("| Trab. | HorasTrab | Categoria | Tarifa | SBruto | Dsctos | SNeto |");
            Console.WriteLine("-------------------------------------------------------------------------");

            double totalSueldosBrutos = 0;
            double totalDescuentos = 0;
            double totalSueldosNetos = 0;

            for (int i = 0; i < numeroTrabajadores; i++)
            {
                int numeroTrabajador = i + 1;

                double[] horasTrabajadas = { 50, 34, 65, 88, 90, 45, 70, 75, 35, 45, 32, 12, 17, 45, 78 };
                char[] categorias = { 'A', 'B', 'A', 'B', 'C', 'C', 'A', 'D', 'A', 'D', 'B', 'C', 'A', 'A', 'B' };

                double horasTrabajadasActual = horasTrabajadas[i];
                char categoria = categorias[i];
                double tarifa = ObtenerTarifa(categoria);

                // Calcular Sueldo Bruto
                double sueldoBruto = horasTrabajadasActual * tarifa;

                // Calcular Descuento
                double descuento = (sueldoBruto > 2500) ? 0.20 * sueldoBruto : 0.15 * sueldoBruto;

                // Calcular Sueldo Neto
                double sueldoNeto = sueldoBruto - descuento;

                totalSueldosBrutos += sueldoBruto;
                totalDescuentos += descuento;
                totalSueldosNetos += sueldoNeto;

                Console.WriteLine($"| {numeroTrabajador,5} | {horasTrabajadasActual,9:F2} | {categoria,9} | {tarifa,6:F2} | {sueldoBruto,6:F2} | {descuento,6:F2} | {sueldoNeto,6:F2} |");
            }
           
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Total Sueldos Brutos: {totalSueldosBrutos:F2}");
            Console.WriteLine($"Total Descuentos: {totalDescuentos:F2}");
            Console.WriteLine($"Total Sueldos Netos: {totalSueldosNetos:F2}");
            Console.ReadKey();
        }

        static double ObtenerTarifa(char categoria)
        {
            switch (categoria)
            {
                case 'A':
                    return 21.0;
                case 'B':
                    return 19.5;
                case 'C':
                    return 17.0;
                case 'D':
                    return 15.5;
                default:
                    return 0;
            }
        }
    }
}
