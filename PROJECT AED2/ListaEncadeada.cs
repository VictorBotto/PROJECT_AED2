namespace EditorDeTexto
{
    public class ListaEncadeada
    {
<<<<<<< Updated upstream
        private No cabeca;
=======
        private No cabeca; // Refer�ncia para o primeiro n� da lista encadeada
>>>>>>> Stashed changes

        public ListaEncadeada()
        {
            cabeca = null; // Inicializa a cabe�a da lista como nula
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
        // M�todo para adicionar uma nova palavra � lista encadeada
        public void AdicionarPalavra(string palavra)
        {
            No no = new No(palavra); // Cria um novo n� com a palavra fornecida
            if (cabeca == null) // Se a lista estiver vazia
            {
                cabeca = no; // O novo n� se torna a cabe�a da lista
            }
            else
            {
                No atual = cabeca; // Come�a a partir da cabe�a da lista
                while (atual.Next != null) // Percorre a lista at� encontrar o �ltimo n�
                {
                    atual = atual.Next; // Avan�a para o pr�ximo n�
                }
                atual.Next = no; // Adiciona o novo n� ao final da lista
            }
        }

        // M�todo para verificar se a lista cont�m a palavra fornecida
        public bool Contains(string palavra)
        {
            No atual = cabeca; // Come�a a partir da cabe�a da lista
            while (atual != null) // Percorre a lista at� o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase)) // Compara a palavra do n� atual com a palavra fornecida
                {
                    return true; // Retorna verdadeiro se a palavra for encontrada
                }
                atual = atual.Next; // Avan�a para o pr�ximo n�
            }
            return false; // Retorna falso se a palavra n�o for encontrada
        }

        // M�todo para remover uma palavra da lista encadeada
        public void RemoverPalavra(string palavra)
        {
            No atual = cabeca; // Come�a a partir da cabe�a da lista
            No anterior = null; // Refer�ncia para o n� anterior

            while (atual != null) // Percorre a lista at� o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase)) // Compara a palavra do n� atual com a palavra fornecida
                {
                    if (anterior == null) // Se o n� a ser removido for a cabe�a da lista
                    {
                        cabeca = atual.Next; // A cabe�a passa a ser o pr�ximo n�
                    }
                    else
                    {
                        anterior.Next = atual.Next; // O n� anterior aponta para o pr�ximo n�, removendo o n� atual da lista
                    }
                    return;
                }
                anterior = atual; // Atualiza o n� anterior
                atual = atual.Next; // Avan�a para o pr�ximo n�
            }
>>>>>>> Stashed changes
        }

        public No Cabeca
        {
            get { return Cabeca; }
        }
    }
}
