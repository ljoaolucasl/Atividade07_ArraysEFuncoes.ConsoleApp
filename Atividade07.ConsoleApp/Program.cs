using System.Linq;

namespace Atividade07.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numerosInteiros = { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6 };
            bool opcaoInvalidaContinua = false;
            bool continua = true;

            int numeroMaior, numeroMenor;
            double valorMedioNumeros = 0;
            int[] numerosNegativos;
            int[] numerosOrdenados = new int[16];

            Array.Copy(numerosInteiros, numerosOrdenados, 16);
            Array.Sort(numerosOrdenados);

            while (continua)
            {
                GerarSequenciaNumeros(numerosInteiros);

                MenuOpcoes();

                numerosInteiros = ExecutarOpcaoEscolhida(numerosInteiros, numerosOrdenados, ref opcaoInvalidaContinua, ref continua);

                if (opcaoInvalidaContinua)
                    continue;

                Console.ReadLine();
            }
        }

        private static int[] ExecutarOpcaoEscolhida(int[] numerosInteiros, int[] numerosOrdenados, ref bool opcaoInvalidaContinua, ref bool continua)
        {
            Console.Write("\nDigite o número da opção escolhida: ");
            int opcaoEscolhida = ValidarNumero();
            opcaoInvalidaContinua = false;

            switch (opcaoEscolhida)
            {
                case 1: GerarNumeroMaior(numerosInteiros); break;
                case 2: GerarNumeroMenor(numerosInteiros); break;
                case 3: GerarValorMedio(numerosInteiros); break;
                case 4: GerarTresNumerosMaiores(numerosOrdenados); break;
                case 5: GerarNumerosNegativos(numerosInteiros); break;
                case 6: numerosInteiros = RemoverUltimoNumeroSequencia(numerosInteiros); break;
                case 7: continua = false; Console.WriteLine("\nFinalizando aplicação..."); break;
                default: opcaoInvalidaContinua = true; break;
            }
            return numerosInteiros;
        }

        private static void MenuOpcoes()
        {
            Console.WriteLine("\nEscolha uma das opções abaixo:");
            Console.WriteLine("\n(1)Gerar número maior");
            Console.WriteLine("(2)Gerar número menor");
            Console.WriteLine("(3)Gerar valor médio");
            Console.WriteLine("(4)Gerar os três números maiores");
            Console.WriteLine("(5)Gerar os números negativos");
            Console.WriteLine("(6)Remover o último número da sequência");
            Console.WriteLine("(7)Sair do programa");
        }

        private static int ValidarNumero()
        {
            bool validarNumero;
            int numero;

            string entrada = Console.ReadLine();

            validarNumero = int.TryParse(entrada, out numero);

            if (!validarNumero) { return 0; }
            else { return numero; }
        }

        private static int[] RemoverUltimoNumeroSequencia(int[] numerosInteiros)
        {

            int posicaoArray;
            int numeroRemover = 0;

            do
            {
                Console.Write("\nQual a posição do número que deseja remover? ");
                numeroRemover = ValidarNumero();

                posicaoArray = Array.FindIndex(numerosInteiros, numero => numero == numeroRemover);

                if (posicaoArray == -1)
                {
                    Console.WriteLine("\nNão existe esse número na sequência");
                }

            } while (posicaoArray == -1);

            Console.WriteLine("Removendo...");

            numerosInteiros[posicaoArray] = 100;

            return numerosInteiros;
        }

        private static void GerarNumerosNegativos(int[] numerosInteiros)
        {
            int[] numerosNegativos = Array.FindAll(numerosInteiros, numero => numero < 0);
            Console.Write($"\nos negativos são: ");
            Console.WriteLine(string.Join(", ", numerosNegativos));
        }

        private static void GerarTresNumerosMaiores(int[] numerosOrdenados)
        {
            Console.Write("\nOs três números maiores são: ");
            Console.WriteLine(string.Join(", ", numerosOrdenados.Skip(13)));
        }

        private static void GerarValorMedio(int[] numerosInteiros)
        {
            double valorMedioNumeros = numerosInteiros.Average();
            Console.WriteLine($"\nO valor médio é: {valorMedioNumeros}");
        }

        private static void GerarNumeroMenor(int[] numerosInteiros)
        {
            int numeroMenor = numerosInteiros.Min();
            Console.WriteLine($"\nO número menor é: {numeroMenor}");
        }

        private static void GerarNumeroMaior(int[] numerosInteiros)
        {
            int numeroMaior = numerosInteiros.Max();
            Console.WriteLine($"\nO número maior é: {numeroMaior}");
        }

        private static void GerarSequenciaNumeros(int[] numerosInteiros)
        {
            Console.Clear();
            Console.Write("Os números são: ");

            foreach (int numero in numerosInteiros)
            {
                if (numero != 100) { Console.Write($" {numero}"); }
            }
            Console.WriteLine($"\nOs {numerosInteiros.Length - 1} números foram gerados!");
        }
    }
}