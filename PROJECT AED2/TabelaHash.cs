using System.Collections.Generic;

namespace EditorDeTexto
{
    // Classe que representa uma tabela hash
    public class TabelaHash
    {
        private ListaEncadeada[] tabela; // Array de listas encadeadas que vai ser responsável para tratar colisões
        private int tamanho; // Tamanho da tabela

        // Construtor da classe que inicializa a tabela hash
        public TabelaHash(int tamanho)
        {
            this.tamanho = tamanho; 
            tabela = new ListaEncadeada[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                tabela[i] = new ListaEncadeada();
            }
        }
        // Método que gera um índice para a palavra (função HASH)
        private int GerarIndice(string palavra)
        {
            int hash = 0;
            foreach (char c in palavra)
            {
                hash += c;
            }
            return hash % tamanho;
        }
        // Método que adiciona uma palavra na tabela hash
        public void Adicionar(string palavra)
        {
            int indice = GerarIndice(palavra);
            tabela[indice].AdicionarPalavra(palavra);
        }
        // Método que remove uma palavra da tabela hash
        public void Remover(string palavra)
        {
            int indice = GerarIndice(palavra);
            tabela[indice].RemoverPalavra(palavra);
        }
        // Método que verifica se a palavra está na tabela hash
        public bool Contains(string palavra)
        {
            int indice = GerarIndice(palavra);
            return tabela[indice].Contains(palavra);
        }
        // Método que retorna todas as palavras da tabela hash
        public string[] ObterPalavras()
        {
            List<string> todasPalavras = new List<string>();
            foreach (var lista in tabela)
            {
                No atual = lista.Cabeca;
                while (atual != null)
                {
                    todasPalavras.Add(atual.Palavra);
                    atual = atual.Next;
                }
            }
            return todasPalavras.ToArray();
        }
    }
}
