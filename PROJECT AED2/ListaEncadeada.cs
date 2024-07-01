namespace EditorDeTexto
{
    // Classe que representa um nó de uma lista encadeada
    public class ListaEncadeada
    {
        private No cabeca;

        public ListaEncadeada()
        {
            cabeca = null;
        }
        // Método que adiciona uma palavra na lista encadeada
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
        // Método que verifica se a palavra está na lista encadeada
        public bool Contains(string palavra)
        {
            No atual = cabeca;
            while (atual != null)
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                atual = atual.Next;
            }
            return false;
        }

        // Método que remove uma palavra da lista encadeada
        public void RemoverPalavra(string palavra)
        {
            No atual = cabeca;
            No anterior = null;

            while (atual != null)
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase))
                {
                    if (anterior == null)
                    {
                        cabeca = atual.Next;
                    }
                    else
                    {
                        anterior.Next = atual.Next;
                    }
                    return;
                }
                anterior = atual;
                atual = atual.Next;
            }
        }

        // Propriedade que retorna o nó cabeça da lista encadeada
        public No Cabeca
        {
            get { return cabeca; }
        }
    }
}
