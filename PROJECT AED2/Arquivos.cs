using System.IO;

namespace EditorDeTexto
{
    public class Arquivos
    {
        // Carrega o conteúdo de um arquivo como uma string
        public string CarregarArquivo(string caminho)
        {
            if (File.Exists(caminho))  // Verifica se o arquivo existe
            {
                return File.ReadAllText(caminho);  // Lê e retorna todo o conteúdo do arquivo
            }
            return string.Empty;  // Retorna uma string vazia se o arquivo não existir
        }

        // Salva o conteúdo em um arquivo, adicionando ao conteúdo existente
        public void SalvarArquivo(string caminho, string conteudo)
        {
            using (StreamWriter writer = new StreamWriter(caminho, true))  // Abre um StreamWriter para escrever no arquivo (true para adicionar ao final)
            {
                writer.WriteLine(conteudo);  // Escreve o conteúdo no arquivo, adicionando ao final
            }
        }

        // Carrega todas as linhas de um arquivo como um array de strings
        public string[] CarregarDicionario(string caminho)
        {
            if (File.Exists(caminho))  // Verifica se o arquivo existe
            {
                return File.ReadAllLines(caminho);  // Lê todas as linhas do arquivo e retorna como um array de strings
            }
            return new string[0];  // Retorna um array vazio se o arquivo não existir
        }

        // Salva o dicionário (TabelaHash) em um arquivo, adicionando novas palavras ao conteúdo existente
        public void SalvarDicionario(string caminho, TabelaHash dicionario)
        {
            using (StreamWriter writer = new StreamWriter(caminho, true))  // Abre um StreamWriter para escrever no arquivo (true para adicionar ao final)
            {
                for (int i = 0; i < 100; i++)  // Presume que o dicionário tem 100 listas encadeadas
                {
                    ListaEncadeada list = dicionario.GetListaEncadeadaAt(i);  // Obtém a lista encadeada na posição i
                    No atual = list.Cabeca;  // Começa na cabeça da lista encadeada
                    while (atual != null)  // Percorre todos os nós da lista encadeada
                    {
                        writer.WriteLine(atual.Palavra);  // Escreve a palavra do nó atual no arquivo
                        atual = atual.Next;  // Avança para o próximo nó
                    }
                }
            }
        }
    }
}
