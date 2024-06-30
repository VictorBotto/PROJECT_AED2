namespace EditorDeTexto
{
    public class TabelaHash
    {
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

        private int GetHash(string palavra)
        {
            int hash = 0;
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
        }
    }
}
