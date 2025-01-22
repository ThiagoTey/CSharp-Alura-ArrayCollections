Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(1.1, 0);
amostra.SetValue(5, 1);
amostra.SetValue(7.2, 2);
amostra.SetValue(9.4, 3);
amostra.SetValue(4.4, 4);
amostra.SetValue(6.9, 4);

void TestsMediana(Array array)
{
    if(array == null || array.Length==0)
    {
        Console.WriteLine("Array para cálculo está vazio ou nulo");
        return;
    }

    double[] numerosOrdenados = (double [])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho %2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio]  + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Mediana = {mediana}");
}

TestsMediana(amostra);