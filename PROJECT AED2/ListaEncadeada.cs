namespace EditorDeTexto
{
    public class ListaEncadeada
    {
        private No cabeca;  // Referência para o primeiro nó da lista encadeada

        // Construtor que inicializa a cabeça da lista como nula
        public ListaEncadeada()
        {
            cabeca = null;
        }

        // Adiciona uma nova palavra à lista encadeada
        public void AdicionarPalavra(string palavra)
        {
            No no = new No(palavra);  // Cria um novo nó com a palavra fornecida
            if (cabeca == null)  // Se a lista estiver vazia
            {
                cabeca = no;  // O novo nó se torna a cabeça da lista
            }
            else
            {
                No atual = cabeca;  // Começa a partir da cabeça da lista
                while (atual.Next != null)  // Percorre a lista até encontrar o último nó
                {
                    atual = atual.Next;  // Avança para o próximo nó
                }
                atual.Next = no;  // Adiciona o novo nó ao final da lista
            }
        }

        // Verifica se a lista contém a palavra fornecida
        public bool Contains(string palavra)
        {
            No atual = cabeca;  // Começa a partir da cabeça da lista
            while (atual != null)  // Percorre a lista até o final
            {
                if (atual.Palavra.Equals(palavra, System.StringComparison.OrdinalIgnoreCase))  // Compara a palavra do nó atual com a palavra fornecida (ignorando maiúsculas/minúsculas)
                {
                    return true;  // Retorna verdadeiro se a palavra for encontrada
                }
                atual = atual.Next;  // Avança para o próximo nó
            }
            return false;  // Retorna falso se a palavra não for encontrada
        }

        // Propriedade que retorna a cabeça da lista
        public No Cabeca
        {
            get { return cabeca; }
        }
    }
}
