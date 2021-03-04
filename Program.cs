using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<conta> listconta = new List<conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        transferencia();
                        break;    

                    case "4":
                        Saque();
                        break; 

                    case "5":
                        depositar();
                        break;  

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();    
                }
                
                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();

        }

        private static void depositar()
        {
            Console.WriteLine("Deposito");
            Console.WriteLine();

            Console.WriteLine("Digite a conta para deposito: ");
            int contaDeposito = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listconta[contaDeposito].Depositar(valorDeposito);
        }

        private static void transferencia()
        {
            Console.WriteLine("Transferencia");
            Console.WriteLine();

            Console.WriteLine("Digite o numero da conta de debito: ");
            int contaDebito = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de credito:");
            int contaCredito = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferencia: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listconta[contaDebito].Transferir(valorTransferencia, listconta[contaCredito]);
        }

        private static void Saque()
        {
            Console.WriteLine("Saque");
            Console.WriteLine();

            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());
            
            listconta[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listconta.Count == 0)
            {
                Console.WriteLine("nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listconta.Count; i++)
            {
                conta conta = listconta[i];
                Console.WriteLine("##{0}", i);
                Console.WriteLine(conta);
            }

            
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para pessoa fisica ou 2 para pessoa juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Credito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            conta novaConta = new conta(nome: entradaNome, 
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito, 
                                        tipoConta: (TipoConta)entradaTipoConta);
            listconta.Add(novaConta); 
        }

        private static string ObterOpcaoUsuario()
        {
             
            Console.WriteLine();
            Console.WriteLine("****************************");
            Console.WriteLine("********  DIO BANK  ********");
            Console.WriteLine("****************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Listar contas");
            Console.WriteLine("2. Inserir nova Conta");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("C. Limpar tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }
    }
}
