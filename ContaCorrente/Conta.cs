using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente
{
    public class Conta
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public int Id { get; set; }
        public float Saldo { get; set; }
        public float Limite { get; set; }
        public List<Movimentacao> HistoricoDeMovimentacoes { get; set; }




        public Conta CriarConta()
        {
            Conta conta = new Conta();
            Console.WriteLine("Informe seu primeiro nome: ");
            conta.Nome = Console.ReadLine();

            Console.WriteLine("Informe seu sobrenome: ");
            conta.Sobrenome = Console.ReadLine();

            Console.WriteLine("Informe seu CPF(000.000.000-00): ");
            conta.CPF = Console.ReadLine();

            Console.WriteLine(" ");

            conta.Id = new Random().Next(998) + 1000;
            conta.Limite = 500;
            conta.Saldo = 1000;
            conta.HistoricoDeMovimentacoes = new List<Movimentacao>();
            return conta;
        }


        public void Deposito(Movimentacao valorDeposito, Conta conta)
        {
            conta.Saldo += valorDeposito.Valor;
        }


        public void Saque(Movimentacao valorDeSaque, Conta conta)
        {
            Movimentacao movimentacao = new Movimentacao();

            if (valorDeSaque.Valor > (conta.Saldo + conta.Limite))
            {
                Console.WriteLine("Saque excede o limite de saldo+limite disponível \n");
            }

            else if (valorDeSaque.Valor <= conta.Saldo)
            {
                movimentacao.Valor = valorDeSaque.Valor;
                movimentacao.Credito = false;

                conta.Saldo -= valorDeSaque.Valor;
                conta.HistoricoDeMovimentacoes.Add(movimentacao);

            }

            else if (valorDeSaque.Valor > Saldo)
            {
                movimentacao.Valor = valorDeSaque.Valor;
                movimentacao.Credito = true;

                valorDeSaque.Valor -= conta.Saldo;
                conta.Saldo = 0;
                conta.Limite -= valorDeSaque.Valor;
                conta.HistoricoDeMovimentacoes.Add(movimentacao);
            }


        }

        public void Transferencia(List<Conta> ContasCadastradas, Movimentacao valorTransferencia, string nome, Conta contaRemetente)
        {
            

            Saque(valorTransferencia, contaRemetente);

            foreach (Conta conta in ContasCadastradas)
            {
                if (conta.Nome.ToLower() == nome.ToLower())
                {
                    conta.Saldo += valorTransferencia.Valor;
                }
            }
            
        }



        public void mostrarSaldo()
        {
            Console.WriteLine("Titular: \n" + Nome + Sobrenome + "\n" +
            "Saldo: R$" + Saldo + "\n" +
            "Limite: R$" + Limite + "\n" +
            "ID: " + Id + "\n" +
            "Historico: \n");

            if (this.HistoricoDeMovimentacoes.Count > 0)
            {
                foreach (Movimentacao movimentacao in this.HistoricoDeMovimentacoes)
                {
                    Console.WriteLine(movimentacao);
                }
            }

            else
            {
                {
                    Console.WriteLine("sem movimentacoes\n");
                }


            }


        }
    }
}
