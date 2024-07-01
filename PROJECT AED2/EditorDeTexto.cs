using System;
using System.IO;

namespace EditorDeTexto
{
    public class EditorDeTexto
    {
        private string caminhoArquivo;
        private Dicionario dicionario;

        public EditorDeTexto(string caminhoDicionario)
        {
            dicionario = new Dicionario(caminhoDicionario);
        }

        public Dicionario ObterDicionario()
        {
            return dicionario;
        }

        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            return File.ReadAllText(caminhoArquivo);
        }

        public void SalvarArquivo(string conteudo)
        {
            if (!string.IsNullOrEmpty(caminhoArquivo))
            {
                File.WriteAllText(caminhoArquivo, conteudo);
            }
        }

        public void CriarNovoArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            File.Create(caminhoArquivo).Dispose();
        }

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
