using System.Linq;

namespace Atividade07.ConsoleApp
{
    internal class Program
    {
        static int[] numerosInteiros = new int[10];

        static void Main(string[] args)
        {
            ObterNumerosSequencia();

            bool opcaoInvalidaContinua = false;
            bool continua = true;

            while (continua)
            {
                GerarSequenciaNumeros();

                MenuOpcoes();

                ExecutarOpcaoEscolhida(ref opcaoInvalidaContinua, ref continua);

                if (opcaoInvalidaContinua)
                    continue;

                Console.ReadLine();
            }
        }

        private static void ObterNumerosSequencia()
        {
            for (int i = 0; i < numerosInteiros.Length; i++)
            {
                Console.Write($"Digite o {i + 1}° da sequência: ");
                int numeroInserido = ValidarNumero();

                numerosInteiros[i] = numeroInserido;
            }
        }

        private static void GerarSequenciaNumeros()
        {
            Console.Clear();
            Console.Write("Os números são: ");

            Console.WriteLine(string.Join(", ", numerosInteiros));

            Console.WriteLine($"\nOs {numerosInteiros.Length} números foram gerados!");
        }

        private static void MenuOpcoes()
        {
            Console.WriteLine("\nEscolha uma das opções abaixo:");
            Console.WriteLine("\n(1)Gerar número maior");
            Console.WriteLine("(2)Gerar número menor");
            Console.WriteLine("(3)Gerar valor médio");
            Console.WriteLine("(4)Gerar os três números maiores");
            Console.WriteLine("(5)Gerar os números negativos");
            Console.WriteLine("(6)Remover um número da sequência");
            Console.WriteLine("(7)Sair do programa");
        }

        private static void GerarNumeroMaior()
        {
            int numeroMaior = numerosInteiros.Max();
            Console.WriteLine($"\nO número maior é: {numeroMaior}");
        }

        private static void GerarNumeroMenor()
        {
            int numeroMenor = numerosInteiros.Min();
            Console.WriteLine($"\nO número menor é: {numeroMenor}");
        }

        private static void GerarValorMedio()
        {
            double valorMedioNumeros = Math.Round(numerosInteiros.Average(), 2);
            Console.WriteLine($"\nO valor médio é: {valorMedioNumeros}");
        }

        private static void GerarTresNumerosMaiores()
        {
            int[] numerosOrdenados = new int[numerosInteiros.Length];

            Array.Copy(numerosInteiros, numerosOrdenados, numerosInteiros.Length);
            Array.Sort(numerosOrdenados);

            Console.Write("\nOs três números maiores são: ");
            Console.WriteLine(string.Join(", ", numerosOrdenados.Skip(numerosInteiros.Length - 3)));
        }

        private static void GerarNumerosNegativos()
        {
            int[] numerosNegativos = Array.FindAll(numerosInteiros, numero => numero < 0);
            Console.Write($"\nos negativos são: ");
            Console.WriteLine(string.Join(", ", numerosNegativos));
        }

        private static void RemoverNumeroEscolhidoSequencia()
        {
            int posicaoArray, numeroRemover = 0;

            do
            {
                Console.Write("\nQual o número que deseja remover? ");
                numeroRemover = ValidarNumero();

                posicaoArray = Array.FindIndex(numerosInteiros, numero => numero == numeroRemover);

                if (posicaoArray == -1)
                    Console.WriteLine("\nNão existe esse número na sequência");

            } while (posicaoArray == -1);

            Console.WriteLine("Removendo...");

            for (int i = posicaoArray; i < numerosInteiros.Length - 1; i++)
            {
                numerosInteiros[i] = numerosInteiros[i + 1];
            }

            Array.Resize(ref numerosInteiros, numerosInteiros.Length - 1);
        }

        private static void ExecutarOpcaoEscolhida(ref bool opcaoInvalidaContinua, ref bool continua)
        {
            Console.Write("\nDigite o número da opção escolhida: ");
            int opcaoEscolhida = ValidarNumero();
            opcaoInvalidaContinua = false;

            switch (opcaoEscolhida)
            {
                case 1: GerarNumeroMaior(); break;
                case 2: GerarNumeroMenor(); break;
                case 3: GerarValorMedio(); break;
                case 4: GerarTresNumerosMaiores(); break;
                case 5: GerarNumerosNegativos(); break;
                case 6: RemoverNumeroEscolhidoSequencia(); break;
                case 7: continua = false; Console.WriteLine("\nFinalizando aplicação..."); break;
                default: opcaoInvalidaContinua = true; break;
            }
        }

        private static int ValidarNumero()
        {
            bool validarNumero;
            int numero;

            do {
                string entrada = Console.ReadLine();

                validarNumero = int.TryParse(entrada, out numero);

            } while (!validarNumero);

            return numero;
        }
    }
}