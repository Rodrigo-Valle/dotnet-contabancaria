using System;

namespace DIO.Bank
{
    public class conta
    {
        public string Nome { get; set; } 
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }  

        public conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < this.Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo} reais.");

            return true;
            

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {this.Nome} é {this.Saldo} reais.");   
        }

        public void Transferir(double valorTransferencia, conta contaDestino)
        // ele vai tentar sacar o valor da transferencia, se conseguir faz o depositar
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " +this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }    
}