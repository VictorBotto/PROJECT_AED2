namespace EditorDeTexto
{
    // Classe que representa um n� de uma lista encadeada
    public class ListaEncadeada
    {
        private No cabeca;

        public ListaEncadeada()
        {
            cabeca = null;
        }
        // M�todo que adiciona uma palavra na lista encadeada
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
        // M�todo que verifica se a palavra est� na lista encadeada
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

        // M�todo que remove uma palavra da lista encadeada
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

        // Propriedade que retorna o n� cabe�a da lista encadeada
        public No Cabeca
        {
            get { return cabeca; }
        }
    }
}
