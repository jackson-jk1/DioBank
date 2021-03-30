using System;
using System.Collections.Generic;


namespace DIO.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
           	string opcaoUsuario = Menu();

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

				opcaoUsuario = Menu();
			}
        }

        private static void Depositar()
        {
             Console.WriteLine("Digite o numero da conta");  
             int indiceConta = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o valor do deposito");  
              double deposito = double.Parse(Console.ReadLine());

              listContas[indiceConta].Depositar(deposito);
        }

        private static void Transferir()
        {
             Console.WriteLine("Digite o numero da conta");  
             int indiceOrigen = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o numero da conta");  
             int indiceDestino = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o valor do Transferido");  
             double valor = double.Parse(Console.ReadLine());

             listContas[indiceOrigen].Transferir(valor, listContas[indiceDestino]);
        }
        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta");  
             int indiceConta = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o valor do saque");  
              double saque = double.Parse(Console.ReadLine());

              listContas[indiceConta].Sacar(saque);
        }

        private static void ListarContas()
        {
            if(listContas.Count == 0 ) 
            {
              Console.WriteLine("Não ha contas cadastradas");  
              return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ",i);
                Console.WriteLine(conta);

            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("digite 1 para conta fisica ou 2 para juridica");
            int tipo = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            String nome = Console.ReadLine();

        
            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito inicial: ");
            double credito = double.Parse(Console.ReadLine());

            Conta NovaConta = new Conta(
            tipoConta: (TipoConta)tipo,
            credito:credito,
            saldo:saldo,
            nome:nome);

            listContas.Add(NovaConta);
         }


        private static string Menu(){
         Console.WriteLine();
         Console.WriteLine("Achou que era um banco comun mas que pena por que era o DIO BANK ao seu dispor");
         Console.WriteLine("HOHO você vai informar a opção desejada");

         Console.WriteLine("1- Listar contas");
         Console.WriteLine("2- Inserir nova conta");
         Console.WriteLine("3- Transferir");
         Console.WriteLine("4- Sacar");
         Console.WriteLine("5- Depositar");
         Console.WriteLine("C- Limpar tela");
         Console.WriteLine("X- Sair");
         Console.WriteLine();

          
        string escolha = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return escolha;
        }
    }
}
