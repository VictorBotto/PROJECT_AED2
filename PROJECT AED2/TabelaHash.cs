using System;

namespace EditorDeTexto
{
    public class TabelaHash
    {
        private const int Tamanho = 100; // Define o tamanho da tabela hash
        private ListaEncadeada[] tabela; // Array de listas encadeadas para armazenar as palavras

        public TabelaHash()
        {
            tabela = new ListaEncadeada[Tamanho]; // Inicializa o array de listas encadeadas
            for (int i = 0; i < Tamanho; i++)
            {
                tabela[i] = new ListaEncadeada(); // Inicializa cada lista encadeada
            }
        }

        // Método para calcular o hash de uma palavra
        private int GetHash(string palavra)
        {
            int hash = 0;

            foreach (char c in palavra.ToLower()) // Converte a palavra para minúsculas
            {
                hash += c; // Acumula os valores ASCII dos caracteres
            }

            return Math.Abs(hash % Tamanho); // Retorna o valor absoluto do módulo do hash pelo tamanho da tabela(usa Math.Abs para garantir que seja um valor positivo.
        }

        // Método para adicionar uma palavra à tabela hash
        public void Adicionar(string palavra)
        {
            if (!Contains(palavra)) // Verifica se a palavra já está na tabela
            {
                int index = GetHash(palavra); // Calcula o índice da palavra na tabela
                tabela[index].AdicionarPalavra(palavra); // Adiciona a palavra à lista encadeada correspondente
            }
        }

        // Método para verificar se a tabela contém uma palavra
        public bool Contains(string palavra)
        {
            int index = GetHash(palavra); // Calcula o índice da palavra na tabela
            return tabela[index].Contains(palavra); // Verifica se a palavra está na lista encadeada correspondente
        }

        // Método para remover uma palavra da tabela hash
        public void Remover(string palavra)
        {
            int index = GetHash(palavra); // Calcula o índice da palavra na tabela
            tabela[index].RemoverPalavra(palavra); // Remove a palavra da lista encadeada correspondente
        }

        // Método para obter a lista encadeada em um índice específico
        public ListaEncadeada GetListaEncadeadaAt(int index)
        {
            return tabela[index]; // Retorna a lista encadeada no índice especificado
        }
    }
}
