using System;

namespace EditorDeTexto
{
    public class TabelaHash
    {
<<<<<<< Updated upstream
        private const int Tamanho = 100;
        private ListaEncadeada[] tabela;

        public TabelaHash()
        {
            tabela = new ListaEncadeada[Tamanho];
            for (int i = 0; i < Tamanho; i++)
            {
                tabela[i] = new ListaEncadeada();
            }
        }

=======
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
>>>>>>> Stashed changes
        private int GetHash(string palavra)
        {
            const int primo = 31; // N�mero primo para a fun��o de hash
            int hash = 0;
<<<<<<< Updated upstream
            foreach (char c in palavra.ToLower())
            {
                hash += c;
            }
            return hash % Tamanho;
        }

        public void Adicionar(string palavra)
        {
            int index = GetHash(palavra);
            tabela[index].Add(palavra);
        }

        public bool Contains(string palavra)
        {
            int index = GetHash(palavra);
            return tabela[index].Contains(palavra);
        }

        public ListaEncadeada GetListaEncadeadaAt(int index)
        {
            return tabela[index];
=======

            foreach (char c in palavra.ToLower()) // Converte a palavra para min�sculas
            {
                hash = hash * primo + c; // Calcula o hash acumulando os valores ASCII dos caracteres
            }

            return Math.Abs(hash % Tamanho); // Retorna o hash modulado pelo tamanho da tabela
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
>>>>>>> Stashed changes
        }
    }
}
