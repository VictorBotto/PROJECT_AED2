namespace EditorDeTexto
{
    public class ListaEncadeada
    {
<<<<<<< Updated upstream
        private No cabeca;
=======
        private No cabeca; // Referência para o primeiro nó da lista encadeada
>>>>>>> Stashed changes

        public ListaEncadeada()
        {
            cabeca = null; // Inicializa a cabeça da lista como nula
        }

<<<<<<< Updated upstream
        public void AdicionarPalavra(string palavra)
        {
            No no = new No(palavra);
            if (cabeca == null)
            {
                cabeca = no;
            }
            else
            {
                No atual = cabeca;
                while (atual.Next != null)
                {
                    atual = atual.Next;
                }
                atual.Next = no;
            }
        }

        public bool Contains(string palavra)
        {
            No atual = Cabeca;
            while (atual != null)
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                atual = atual.Next;
            }
            return false;
=======
        // Método para adicionar uma nova palavra à lista encadeada
        public void AdicionarPalavra(string palavra)
        {
            No no = new No(palavra); // Cria um novo nó com a palavra fornecida
            if (cabeca == null) // Se a lista estiver vazia
            {
                cabeca = no; // O novo nó se torna a cabeça da lista
            }
            else
            {
                No atual = cabeca; // Começa a partir da cabeça da lista
                while (atual.Next != null) // Percorre a lista até encontrar o último nó
                {
                    atual = atual.Next; // Avança para o próximo nó
                }
                atual.Next = no; // Adiciona o novo nó ao final da lista
            }
        }

        // Método para verificar se a lista contém a palavra fornecida
        public bool Contains(string palavra)
        {
            No atual = cabeca; // Começa a partir da cabeça da lista
            while (atual != null) // Percorre a lista até o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase)) // Compara a palavra do nó atual com a palavra fornecida
                {
                    return true; // Retorna verdadeiro se a palavra for encontrada
                }
                atual = atual.Next; // Avança para o próximo nó
            }
            return false; // Retorna falso se a palavra não for encontrada
        }

        // Método para remover uma palavra da lista encadeada
        public void RemoverPalavra(string palavra)
        {
            No atual = cabeca; // Começa a partir da cabeça da lista
            No anterior = null; // Referência para o nó anterior

            while (atual != null) // Percorre a lista até o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase)) // Compara a palavra do nó atual com a palavra fornecida
                {
                    if (anterior == null) // Se o nó a ser removido for a cabeça da lista
                    {
                        cabeca = atual.Next; // A cabeça passa a ser o próximo nó
                    }
                    else
                    {
                        anterior.Next = atual.Next; // O nó anterior aponta para o próximo nó, removendo o nó atual da lista
                    }
                    return;
                }
                anterior = atual; // Atualiza o nó anterior
                atual = atual.Next; // Avança para o próximo nó
            }
>>>>>>> Stashed changes
        }

        public No Cabeca
        {
            get { return Cabeca; }
        }
    }
}
