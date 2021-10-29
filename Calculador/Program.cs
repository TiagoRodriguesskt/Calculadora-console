using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; //O valor padrão é "não é um número", que usamos se uma operação, como divisão, puder resultar em um erro.

            // Use uma instrução switch para fazer as contas.
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    // Peça ao usuário para inserir um divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Retorne o texto para uma entrada de opção incorreta.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Exibe o título como o aplicativo de calculadora do console C #.
            Console.WriteLine("\nCalculadora C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variáveis ​​e defina como vazio.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Peça ao usuário para digitar o primeiro número.
                Console.Write("Digite um número e pressione Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                // Peça ao usuário para digitar o segundo número.
                Console.Write("Digite outro número e pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Peça ao usuário para escolher uma operadora.
                Console.WriteLine("Escolha uma operadora da lista a seguir:");
                Console.WriteLine("\t+ - Soma");
                Console.WriteLine("\t- - Subtração");
                Console.WriteLine("\t* - Multiplicação");
                Console.WriteLine("\t/ - Divição");
                Console.Write("Sua opção? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não! Ocorreu uma exceção ao tentar fazer as contas. \n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Aguarde a resposta do usuário antes de fechar.
                Console.Write("Pressione 'n' e Enter para sair do aplicativo ou pressione Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Espaçamento de linha amigável.
            }
            return;
        }
    }
}