using System;


namespace Banco
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private string Nome {get; set;}

        public Conta(TipoConta TipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta=TipoConta;
            this.Saldo=Saldo;
            this.Credito=Credito;
            this.Nome=Nome;
        }

        public bool Sacar(double valorSaque)
        {
            // validação do saldo suficiete
            if(this.Saldo - valorSaque< (this.Credito *-1)){
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "TipoConta "+ this.TipoConta + " | ";
            retorno += "Nome "+ this.Nome + " | ";
            retorno += "Saldo "+ this.Saldo + " | ";
            retorno += "Credito "+ this.Credito + " | ";
            return retorno;
        }

    }
}