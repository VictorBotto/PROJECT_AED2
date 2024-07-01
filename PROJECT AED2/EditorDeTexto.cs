using System;
using System.IO;

namespace EditorDeTexto
{
    // Classe que representa um editor de texto
    public class EditorDeTexto
    {
        private string caminhoArquivo; // Caminho do arquivo que est� sendo editado
        private Dicionario dicionario; // Dicion�rio de palavras


        // Construtor da classe que cria um novo Dicionario.
        public EditorDeTexto(string caminhoDicionario) 
        {
            dicionario = new Dicionario(caminhoDicionario);
        }

        // M�todo que retorna o dicion�rio
        public Dicionario ObterDicionario()
        {
            return dicionario;
        }
        // M�todo que abre um arquivo
        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            return File.ReadAllText(caminhoArquivo);
        }
         // M�todo que salva o conte�do do arquivo
        public void SalvarArquivo(string conteudo)
        {
            if (!string.IsNullOrEmpty(caminhoArquivo))
            {
                File.WriteAllText(caminhoArquivo, conteudo);
            }
        }
        // M�todo que cria um novo arquivo
        public void CriarNovoArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            File.Create(caminhoArquivo).Dispose();
        }
        // M�todo que retorna o conte�do do arquivo
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
