using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

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
}

TestaArrayDeContasCorrentes();