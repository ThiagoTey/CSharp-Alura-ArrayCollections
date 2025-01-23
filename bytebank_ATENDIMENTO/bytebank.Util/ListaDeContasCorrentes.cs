using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        VerificarCapacidade(_proximaPosicao + 1);
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }

    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if(_itens.Length >= tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando tamanho necessário");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }

    public ContaCorrente VerificarContaComMaiorSaldo()
    {
        double maiorSaldo = _itens.Max(item => item.Saldo);
        ContaCorrente conta = _itens.First(item => item.Saldo == maiorSaldo);

        return conta;
    }

    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }
        for (int i = indiceItem; i < _proximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _proximaPosicao--;
        _itens[_proximaPosicao] = null;
    }

    public void ExibirLista()
    {
        for(int i = 0; i < _proximaPosicao;i++)
        {
            Console.WriteLine($" - {i} - Conta : {_itens[i].Conta} - Agencia : {_itens[i].Numero_agencia}");
        }
    }

    public ContaCorrente RecuperarContaNoIndice(int indice)
    {
        if(indice < 0 || indice > _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }

        return _itens[indice];
    }

    public int Tamanho 
    {
        get
        {
            return _proximaPosicao;
        }
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaNoIndice(indice);
        }
    }
}
