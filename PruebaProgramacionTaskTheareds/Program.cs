using System.Collections.Concurrent;

namespace PruebaProgramacionTaskTheareds
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConcurrentQueue<int> numerosProcesados = new ConcurrentQueue<int>();

            Task tarea1 = CalcularCuadrados(1, 5, numerosProcesados);
            Task tarea2 = CalcularCuadrados(6, 10, numerosProcesados);

            Console.WriteLine("Procesando números en paralelo...\n");

            await Task.WhenAll(tarea1,tarea2);

            Console.WriteLine("\nProceso terminado.\n");

            Console.WriteLine("Resultados:");

            foreach (var numero in numerosProcesados)
            {
                Console.WriteLine(numero);
            }
        }

        static async Task CalcularCuadrados(
            int inicio,
            int fin,
            ConcurrentQueue<int> resultados)
        {
            for (int i = inicio; i <= fin; i++)
            {
                await Task.Delay(500);

                int cuadrado = i * i;

                resultados.Enqueue(cuadrado);

                Console.WriteLine($"Número: {i} -> Cuadrado: {cuadrado}");
            }
        }
    }
}
