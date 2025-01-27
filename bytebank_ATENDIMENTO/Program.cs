using System.Collections;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays de objetos

Array amostra = new double[5];
amostra.SetValue(1.1, 0);
amostra.SetValue(5, 1);
amostra.SetValue(7.2, 2);
amostra.SetValue(9.4, 3);
amostra.SetValue(4.4, 4);
amostra.SetValue(6.9, 4);

void TestsMediana(Array array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Array para cálculo está vazio ou nulo");
        return;
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Mediana = {mediana}");
}

//TestsMediana(amostra);

double[] arrayDouble = { 1.1, 5.5, 7.8, 7.7, 10 };

void CalculaMedeia(double[] array)
{
    array.Average();
}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-D"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-E"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-E"));

    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

//TestaArrayDeContasCorrentes();

#endregion 

#region Teste lista contacorrentea
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaDeContas2.AddRange(_listaDeContas3);
#endregion

List<ContaCorrente> _listaDeContas = new()
{
    new ContaCorrente(123, "123456-X") {Saldo=100 ,Titular = new Cliente{Cpf="11111", Nome="cuza"}},
    new ContaCorrente(100, "123456-Z") {Saldo=200, Titular = new Cliente{Cpf="12345", Nome="cuzi"}},
    new ContaCorrente(100, "123456-W") {Saldo=1512, Titular = new Cliente{Cpf="33333", Nome="cuzu"}}
};
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception execao)
            {
                throw new ByteBankException(execao.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverConta();
                    break;
                case '4':
                    OrdernarContas();
                    break;
                case '5':
                    PesquisarConta();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    catch (ByteBankException execao)
    {
        Console.WriteLine($"{execao.Message}");
    }
    

}

void PesquisarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===    PESQUISAR CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2)CPF TITULAR ou  (3) Nº AGÊNCIA : ");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.Write("Informe o número da Conta: ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.Write("Informe o CPF do Titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                Console.WriteLine(consultaCpf.ToString());
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.Write("Informe o Nº da Agência: ");
                int _numeroAgencia = int.Parse(Console.ReadLine());
                List<ContaCorrente> contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                ExibirListaDeContas(contasPorAgencia);
                Console.ReadKey();
                break;
            }
        default:
            Console.WriteLine("Opção não implementada.");
            break;
    }
}

void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
{
    if (contasPorAgencia == null)
    {
        Console.WriteLine("Consulta não retornou dados...");
        return;
    }

    foreach (ContaCorrente item in contasPorAgencia)
    {
        Console.WriteLine(item.ToString());
    }
}

List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    //var consulta = ( from conta in _listaDeContas where conta.Numero_agencia == numeroAgencia select conta).ToList();
    return _listaDeContas.Where(conta => conta.Numero_agencia.Equals(numeroAgencia)).ToList();
}

ContaCorrente ConsultaPorCPFTitular(string? cpf)
{
    ContaCorrente conta = _listaDeContas.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();
    return conta;
}

ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
{
    ContaCorrente conta = _listaDeContas.Where(conta => conta.Conta.Equals(numeroConta)).FirstOrDefault();
    return conta;
}

void OrdernarContas()
{
    _listaDeContas.Sort();
    Console.WriteLine("Lista Ordenado com sucesso!");
    Console.ReadKey();
}

void RemoverConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = _listaDeContas.Where(conta => conta.Conta.Equals(numeroConta)).FirstOrDefault();
    
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine(" ... Conta para remoção não encontrada ...");
    }
    Console.ReadKey();
}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   LISTA DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }

    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine(item.ToString()); 
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Infome nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Infome CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Infome Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}

AtendimentoCliente();