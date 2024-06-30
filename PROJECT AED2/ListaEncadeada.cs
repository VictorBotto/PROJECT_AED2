namespace EditorDeTexto
{
    public class ListaEncadeada
    {
        private No cabeca;

        public ListaEncadeada()
        {
            cabeca = null;
        }

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
        }

        public No Cabeca
        {
            get { return Cabeca; }
        }
    }
}
