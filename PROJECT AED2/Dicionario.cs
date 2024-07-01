using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class Dicionario
    {
        private HashSet<string> palavras;
        private string caminhoArquivo;

        public Dicionario(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
            palavras = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            CarregarDicionario();
        }

        private void CarregarDicionario()
        {
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    palavras.Add(linha.Trim());
                }
            }
        }

        public bool ExistePalavra(string palavra)
        {
            return palavras.Contains(palavra);
        }

        public void AdicionarPalavra(string palavra)
        {
            if (!palavras.Contains(palavra))
            {
                palavras.Add(palavra);
                SalvarDicionario();
            }
        }

        public void RemoverPalavra(string palavra)
        {
            if (palavras.Contains(palavra))
            {
                palavras.Remove(palavra);
                SalvarDicionario();
            }
        }

        public List<string> ValidarTexto(string texto, out List<string> palavrasEncontradas)
        {
            string[] palavrasTexto = texto.Split(new char[] { ' ', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> palavrasNaoEncontradas = new List<string>();
            palavrasEncontradas = new List<string>();

            foreach (string palavra in palavrasTexto)
            {
                if (!ExistePalavra(palavra))
                {
                    palavrasNaoEncontradas.Add(palavra);
                }
                else
                {
                    palavrasEncontradas.Add(palavra);
                }
            }

            return palavrasNaoEncontradas;
        }

        public void SalvarDicionario()
        {
            try
            {
                File.WriteAllLines(caminhoArquivo, palavras);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o dicionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
