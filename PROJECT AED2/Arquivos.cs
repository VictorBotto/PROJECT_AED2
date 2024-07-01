using System;
using System.IO;

namespace EditorDeTexto
{
    //  Classe que lida com a leitura e escrita de arquivos
    public class Arquivos
    {
        // Carrega um dicionário de palavras a partir de um arquivo
        public string[] CarregarDicionario(string caminho)
        {
            if (File.Exists(caminho)) // Verifica de o arquivo existe.
            {
                return File.ReadAllLines(caminho); // Retorna as linhas do arquivo como um array de strings
            }
            else
            {
                return new string[0]; // Retorna um array vazio se o arquivo não existir
            }
        }

        // Salva um dicionário de palavras em um arquivo
        public void SalvarDicionario(string caminho, string[] palavras)
        {
            File.WriteAllLines(caminho, palavras);
        }

        // Carrega o conteúdo de um arquivo
        public string CarregarArquivo(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllText(caminho); // Retorna o conteúdo do arquivo como uma string
            }
            else
            {
                return string.Empty; // Retorna uma string vazia se o arquivo não existir
            }
        }

        // Salva o conteúdo em um arquivo
        public void SalvarArquivo(string caminho, string conteudo)
        {
            File.WriteAllText(caminho, conteudo);
        }

        // Cria um novo arquivo vazio
        public void CriarNovoArquivo(string caminho)
        {
            File.Create(caminho).Close(); // Cria um novo arquivo vazio
        }
    }
}
