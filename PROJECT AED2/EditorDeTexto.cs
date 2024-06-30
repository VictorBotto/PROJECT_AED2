using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class EditorDeTexto
    {
        private TabelaHash dicionario;
        private Arquivos arquivos;
        private string caminhoArquivo;

        public EditorDeTexto(string caminhoDicionario)
        {
            dicionario = new TabelaHash();
            arquivos = new Arquivos();
            CarregarDicionario(caminhoDicionario);
        }

        private void CarregarDicionario(string caminhoDicionario)
        {
            string[] palavras = arquivos.CarregarDicionario(caminhoDicionario);
            foreach (string word in palavras)
            {
                dicionario.Adicionar(word.Trim());
            }
        }

        public void SalvarDicionario(string caminho)
        {
            arquivos.SalvarDicionario(caminho, dicionario);
        }

        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            return arquivos.CarregarArquivo(caminhoArquivo);
        }

        public void SalvarArquivo(string conteudo)
        {
            arquivos.SalvarArquivo(caminhoArquivo, conteudo);
        }

        public void ValidarTexto(string texto)
        {
            string[] palavras = texto.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palavra in palavras)
            {
                if (!dicionario.Contains(palavra))
                {
                    DialogResult result = MessageBox.Show($"A palavra '{palavra}' não está no dicionário. Deseja adicioná-la?", "Adicionar Palavra", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dicionario.Adicionar(palavra);
                    }
                }
            }
        }
    }
}
