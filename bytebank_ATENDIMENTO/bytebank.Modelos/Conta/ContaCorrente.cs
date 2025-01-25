namespace bytebank.Modelos.Conta
{
	public class ContaCorrente : IComparable<ContaCorrente>
	{
		private int _numero_agencia;

		private string _conta;

		private double saldo;

		public Cliente Titular { get; set; }

		public string Nome_Agencia { get; set; }

		public int Numero_agencia
		{
			get
			{
				return _numero_agencia;
			}
			set
			{
				if (value > 0)
				{
					_numero_agencia = value;
				}
			}
		}

		public string Conta
		{
			get
			{
				return _conta;
			}
			set
			{
				if (value != null)
				{
					_conta = value;
				}
			}
		}

		public double Saldo
		{
			get
			{
				return saldo;
			}
			set
			{
				if (!(value < 0.0))
				{
					saldo = value;
				}
			}
		}

		public static int TotalDeContasCriadas { get; set; }

		public bool Sacar(double valor)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			return true;
		}

		public void Depositar(double valor)
		{
			if (!(valor < 0.0))
			{
				saldo += valor;
			}
		}

		public bool Transferir(double valor, ContaCorrente destino)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			destino.saldo += valor;
			return true;
		}

		public ContaCorrente(int numero_agencia, string conta)
		{
			Numero_agencia = numero_agencia;
			Conta = conta;
			TotalDeContasCriadas += 1;
			Titular = new Cliente();
		}

		public override string ToString()
		{

			return $" === DADOS DA CONTA === \n" +
				   $"Número da Conta : {this.Conta} \n" +
				   $"Titular da Conta: {this.Titular.Nome} \n" +
				   $"CPF do Titular  : {this.Titular.Cpf} \n" +
				   $"Profissão do Titular: { this.Titular.Profissao}";
		}

        public int CompareTo(ContaCorrente? outro)
        {
            if( outro == null)
			{
				return 1;
			} 
			return this.Numero_agencia.CompareTo(outro.Numero_agencia);
        }
    }

}