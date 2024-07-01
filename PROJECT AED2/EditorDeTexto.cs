using System;
using System.IO;

namespace EditorDeTexto
{
    // Classe que representa um editor de texto
    public class EditorDeTexto
    {
        private string caminhoArquivo; // Caminho do arquivo que está sendo editado
        private Dicionario dicionario; // Dicionário de palavras


        // Construtor da classe que cria um novo Dicionario.
        public EditorDeTexto(string caminhoDicionario) 
        {
            dicionario = new Dicionario(caminhoDicionario);
        }

        // Método que retorna o dicionário
        public Dicionario ObterDicionario()
        {
            return dicionario;
        }
        // Método que abre um arquivo
        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            return File.ReadAllText(caminhoArquivo);
        }
         // Método que salva o conteúdo do arquivo
        public void SalvarArquivo(string conteudo)
        {
            if (!string.IsNullOrEmpty(caminhoArquivo))
            {
                File.WriteAllText(caminhoArquivo, conteudo);
            }
        }
        // Método que cria um novo arquivo
        public void CriarNovoArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            File.Create(caminhoArquivo).Dispose();
        }
        // Método que retorna o conteúdo do arquivo
        public string ObterConteudo()
        {
            if (!string.IsNullOrEmpty(caminhoArquivo))
            {
                return File.ReadAllText(caminhoArquivo);
            }
            return string.Empty;
        }
    }
}
