using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{

    static void Main()
    {

        int mov = 0;
        int indice = -1;

        Random r = new Random();
        int num = 0;

        Stopwatch stopwatch = new Stopwatch();

        int[] vetor25 = Enumerable.Range(1, 25)
                                  .OrderBy(x => r.Next())
                                  .ToArray();

        int[] vetor250 = Enumerable.Range(1, 250)
                                   .OrderBy(x => r.Next())
                                   .ToArray();

        stopwatch.Start();

        Console.WriteLine("Escolha o vetor de 25 ou 250 posições");
        Console.WriteLine("[1] - 25 posições");
        Console.WriteLine("[2] - 250 posições");
        Console.Write(">>> ");
        int escolha1 = int.Parse(Console.ReadLine());

        int[] vetor;

        switch (escolha1)
        {

            case 1:

                vetor = vetor25;
                break;

            case 2:

                vetor = vetor250;
                break;

            default:

                Console.WriteLine("Opção inválida");
                return;

        }

        Console.Clear();
        Console.WriteLine("Vetor selecionado:");
        Console.WriteLine($"{string.Join(" ", vetor)}\n");

        Console.WriteLine("Escolha sua pesquisa ");
        Console.WriteLine("[1] - Pesquisa Sequencial");
        Console.WriteLine("[2] - Pesquisa Binária");
        Console.Write(">>> ");
        int escolha2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha um número da lista: ");
        num = int.Parse(Console.ReadLine());

        switch (escolha2)
        {
            case 1:

                indice = Sequencial(vetor, num, ref mov);

                if (indice != -1)
                {

                    Console.WriteLine($"Número {num} encontrado no índice {indice}.");

                }
                else
                {

                    Console.WriteLine($"Número {num} não encontrado no vetor.");

                }

                Console.WriteLine($"Número de movimentos (comparações) realizados: {mov}");
                break;

            case 2:

                int[] ordenado = (int[])vetor.Clone();
                Array.Sort(ordenado);

                Console.WriteLine($"\nVetor recém ordenado:");
                Console.WriteLine($"{string.Join(" ", ordenado)}");

                indice = Binaria(ordenado, num, ref mov);

                if (indice != -1)
                {

                    Console.WriteLine($"Número {num} encontrado no índice {indice}.");

                }

                else
                {

                    Console.WriteLine($"Número {num} não encontrado no vetor ordenado.");

                }

                Console.WriteLine($"Número de movimentos realizados: {mov}");

                break;

            default:

                Console.WriteLine("Opção inválida");

                break;
        }

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;

        Console.WriteLine($"\nMilissegundos: {elapsed.TotalMilliseconds} ms");
        Console.WriteLine($"Segundos: {elapsed.TotalSeconds} s");

    }

    static int Sequencial(int[] vetor, int num, ref int mov)
    {
        for (int i = 0; i < vetor.Length; i++)
        {

            mov++;
            if (vetor[i] == num)
                return i;

        }
        return -1;
    }

    static int Binaria(int[] vetor, int num, ref int mov)
    {
        int left = 0;
        int right = vetor.Length - 1;

        while (left <= right)
        {
            mov++;
            int mid = left + (right - left) / 2;

            if (vetor[mid] == num)
            {

                return mid;

            }
            else if (vetor[mid] < num)
            {

                left = mid + 1;

            }
            else
            {
                right = mid - 1;

            }
        }

        return -1;
    }
}
