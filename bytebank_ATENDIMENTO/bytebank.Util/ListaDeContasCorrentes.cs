﻿using bytebank.Modelos.Conta;

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
}
