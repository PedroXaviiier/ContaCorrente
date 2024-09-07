using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    public class Menu
    {
        public void IniciarMenu()
        {
            Conta conta = new Conta();
            int opcao;
            do
            {
                
                Console.WriteLine("Digite 1 para criar um usuário\n" +
                                  "Digite 2 para fazer um saque\n" +
                                  "Digite 3 para fazer um depósito\n" +
                                  "Digite 4 para fazer uma transferência\n" +
                                  "Digite 5 para visualizar sua conta\n" +
                                  "Digite 6 para sair\n");
                opcao = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(" ");

                switch (opcao)
                {
                    case 1:
                        if (conta.Nome != null) 
                        {
                            Console.WriteLine("voce ja possui uma conta\n");
                            break;
                        }
                        else 
                        {
                            conta = new Conta();
                            conta = conta.CriarConta();
                            break;
                        }
                        

                    case 2:
                        if (conta.Nome != null)
                        {
                            Movimentacao valorDoSaque = new Movimentacao();

                            Console.WriteLine("Informe o valor do saque: ");
                            valorDoSaque.Valor = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(" ");
                            conta.Saque(valorDoSaque, conta);

                            break;

                        }
                        else
                        {
                            Console.WriteLine("Voce não possui uma conta \n");
                            break;
                        }

                    case 3:
                        if (conta.Nome != null)
                        {
                            Movimentacao valorDoDeposito = new Movimentacao();


                            Console.WriteLine("Informe o valor do Deposito: ");
                            valorDoDeposito.Valor = Convert.ToInt32(Console.ReadLine());
                            conta.Deposito(valorDoDeposito, conta);

                            break;

                        }
                        else
                        {
                            Console.WriteLine("Voce não possui uma conta \n");
                            break;
                        }

                    case 4:
                        if (conta.Nome != null)
                        {
                            //favor mudar caminho para o do seu usuario/disco
                            JsonReader leitorJson = new JsonReader();
                            List<Conta> contasList = new List<Conta>();

                            contasList = leitorJson.JsonFileReader("C:\\Users\\phxav\\source\\repos\\ContaCorrente\\ContaCorrente\\json\\Conta1.json");
                            contasList = leitorJson.JsonFileReader("C:\\Users\\phxav\\source\\repos\\ContaCorrente\\ContaCorrente\\json\\Conta2.json");
                            contasList = leitorJson.JsonFileReader("C:\\Users\\phxav\\source\\repos\\ContaCorrente\\ContaCorrente\\json\\Conta3.json");
                            contasList = leitorJson.JsonFileReader("C:\\Users\\phxav\\source\\repos\\ContaCorrente\\ContaCorrente\\json\\Conta4.json");


                            Movimentacao valorDaTransferencia = new Movimentacao();
                            string nomeContaDestinataria;

                            Console.WriteLine("Informe o valor da transferencia: ");
                            valorDaTransferencia.Valor = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Informe o nome do destinatario: ");
                            nomeContaDestinataria = Console.ReadLine();

                            conta.Transferencia(contasList, valorDaTransferencia, nomeContaDestinataria, conta);

                            break;

                        }
                        else
                        {
                            Console.WriteLine("Voce não possui uma conta \n");
                            break;
                        }

                    case 5:
                        if (conta != null)
                        {
                            conta.mostrarSaldo();
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Voce não possui uma conta \n");
                            break;
                        }


                    case 6: break;

                    default:
                        Console.WriteLine("opcao invalida \n");
                        break;


                }

            } while (opcao != 6);

        }
    }
}
