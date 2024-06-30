namespace EditorDeTexto
{
    public class ListaEncadeada
    {
        private No cabeca;  // Refer�ncia para o primeiro n� da lista encadeada

        // Construtor que inicializa a cabe�a da lista como nula
        public ListaEncadeada()
        {
            cabeca = null;
        }

        // Adiciona uma nova palavra � lista encadeada
        public void AdicionarPalavra(string palavra)
        {
            No no = new No(palavra);  // Cria um novo n� com a palavra fornecida
            if (cabeca == null)  // Se a lista estiver vazia
            {
                cabeca = no;  // O novo n� se torna a cabe�a da lista
            }
            else
            {
                No atual = cabeca;  // Come�a a partir da cabe�a da lista
                while (atual.Next != null)  // Percorre a lista at� encontrar o �ltimo n�
                {
                    atual = atual.Next;  // Avan�a para o pr�ximo n�
                }
                atual.Next = no;  // Adiciona o novo n� ao final da lista
            }
        }

        // Verifica se a lista cont�m a palavra fornecida
        public bool Contains(string palavra)
        {
            No atual = cabeca;  // Come�a a partir da cabe�a da lista
            while (atual != null)  // Percorre a lista at� o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase))  // Compara a palavra do n� atual com a palavra fornecida (ignorando mai�sculas/min�sculas)
                {
                    return true;  // Retorna verdadeiro se a palavra for encontrada
                }
                atual = atual.Next;  // Avan�a para o pr�ximo n�
            }
            return false;  // Retorna falso se a palavra n�o for encontrada
        }

        // Propriedade que retorna a cabe�a da lista
        public No Cabeca
        {
            get { return cabeca; }
        }
    }
}
