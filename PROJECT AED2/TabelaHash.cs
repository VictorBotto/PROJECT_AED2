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

        // M�todo para calcular o hash de uma palavra
        private int GetHash(string palavra)
        {
            int hash = 0;

            foreach (char c in palavra.ToLower()) // Converte a palavra para min�sculas
            {
                hash += c; // Acumula os valores ASCII dos caracteres
            }

            return Math.Abs(hash % Tamanho); // Retorna o valor absoluto do m�dulo do hash pelo tamanho da tabela(usa Math.Abs para garantir que seja um valor positivo.
        }

        // M�todo para adicionar uma palavra � tabela hash
        public void Adicionar(string palavra)
        {
            if (!Contains(palavra)) // Verifica se a palavra j� est� na tabela
            {
                int index = GetHash(palavra); // Calcula o �ndice da palavra na tabela
                tabela[index].AdicionarPalavra(palavra); // Adiciona a palavra � lista encadeada correspondente
            }
        }

        // M�todo para verificar se a tabela cont�m uma palavra
        public bool Contains(string palavra)
        {
            int index = GetHash(palavra); // Calcula o �ndice da palavra na tabela
            return tabela[index].Contains(palavra); // Verifica se a palavra est� na lista encadeada correspondente
        }

        // M�todo para remover uma palavra da tabela hash
        public void Remover(string palavra)
        {
            int index = GetHash(palavra); // Calcula o �ndice da palavra na tabela
            tabela[index].RemoverPalavra(palavra); // Remove a palavra da lista encadeada correspondente
        }

        // M�todo para obter a lista encadeada em um �ndice espec�fico
        public ListaEncadeada GetListaEncadeadaAt(int index)
        {
            return tabela[index]; // Retorna a lista encadeada no �ndice especificado
        }
    }
}
