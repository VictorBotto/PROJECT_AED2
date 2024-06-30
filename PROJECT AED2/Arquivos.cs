using System.IO;

namespace EditorDeTexto
{
    public class Arquivos
    {
        public string CarregarArquivo(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllText(caminho);
            }
            return string.Empty;
        }

        public void SalvarArquivo(string caminho, string conteudo)
        {
            File.WriteAllText(caminho, conteudo);
        }

        public string[] CarregarDicionario(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllLines(caminho);
            }
            return new string[0];
        }

        public void SalvarDicionario(string caminho, TabelaHash dicionario)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                for (int i = 0; i < 100; i++)
                {
                    ListaEncadeada list = dictionary.GetListaEncadeadaAt(i);
                    No atual = list.Cabeca;
                    while (atual != null)
                    {
                        writer.WriteLine(atual.Palavra);
                        atual = atual.Next;
                    }
                }
            }
        }
    }
}
