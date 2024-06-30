namespace EditorDeTexto
{
    public class TabelaHash
    {
        // Constante que define o tamanho da tabela hash
        private const int Tamanho = 100;

        // Array de listas encadeadas para armazenar as palavras
        private ListaEncadeada[] tabela;

        // Construtor que inicializa a tabela hash
        public TabelaHash()
        {
            tabela = new ListaEncadeada[Tamanho];  // Inicializa o array com o tamanho definido
            for (int i = 0; i < Tamanho; i++)  // Para cada posi��o no array
            {
                tabela[i] = new ListaEncadeada();  // Inicializa uma nova lista encadeada
            }
        }

        // M�todo privado que calcula o hash de uma palavra
        private int GetHash(string palavra)
        {
            int hash = 0;
            foreach (char c in palavra.ToLower())  // transforma cada caractere da palavra em min�sculas
            {
                hash += c;  // Adiciona o valor ASCII do caractere ao hash
            }
            return hash % Tamanho;  // Retorna o hash modulado pelo tamanho da tabela
        }

        // M�todo p�blico para adicionar uma palavra � tabela hash
        public void Adicionar(string palavra)
        {
            int index = GetHash(palavra);  // Calcula o �ndice da palavra na tabela
            tabela[index].AdicionarPalavra(palavra);  // Adiciona a palavra � lista encadeada no �ndice calculado
        }

        // M�todo p�blico para verificar se a tabela cont�m uma palavra
        public bool Contains(string palavra)
        {
            int index = GetHash(palavra);  // Calcula o �ndice da palavra na tabela
            return tabela[index].Contains(palavra);  // Verifica se a lista encadeada no �ndice cont�m a palavra
        }

        // M�todo p�blico para obter a lista encadeada em um �ndice espec�fico
        public ListaEncadeada GetListaEncadeadaAt(int index)
        {
            return tabela[index];  // Retorna a lista encadeada no �ndice especificado
        }
    }
}
