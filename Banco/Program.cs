using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();


            while(opcaoUsuario.ToUpper()!= "X")
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
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break; 
                    case "C":
                        Console.Clear();
                        break;                 
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }    
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por Utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite a conta origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(ValorDeposito);


        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("digite o Valor a ser sacao: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(ValorDeposito);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta fisica ou 2 para conta juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(TipoConta: (TipoConta)entradaTipoConta,
                                        Saldo: entradaSaldo,
                                        Credito: entradaCredito,
                                        Nome: entradaNome);
            listContas.Add(novaConta);                                
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma Conta Encontrada.");
                return;
            }

            for(int i=0; i<listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao NW Bank");
            Console.WriteLine("Por favor informe a opção desejada:");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Insrir nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
