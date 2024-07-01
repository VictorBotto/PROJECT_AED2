using System;
using System.IO;

namespace EditorDeTexto
{
    public class Arquivos
    {
        public string[] CarregarDicionario(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllLines(caminho);
            }
            else
            {
                return new string[0]; // Retorna um array vazio se o arquivo não existir
            }
        }

        public void SalvarDicionario(string caminho, string[] palavras)
        {
            File.WriteAllLines(caminho, palavras);
        }

        public string CarregarArquivo(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllText(caminho);
            }
            else
            {
                return string.Empty; // Retorna uma string vazia se o arquivo não existir
            }
        }

        public void SalvarArquivo(string caminho, string conteudo)
        {
            File.WriteAllText(caminho, conteudo);
        }

        public void CriarNovoArquivo(string caminho)
        {
            File.Create(caminho).Close(); // Cria um novo arquivo vazio
        }
    }
}
