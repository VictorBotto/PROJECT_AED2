using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class EditorDeTexto
    {
        private TabelaHash dicionario;
        private Arquivos arquivos;
        private string caminhoArquivo;

        public TextEditor(string caminhoDicionario)
        {
            dicionario = new TabelaHash();
            arquivos = new Arquivos();
            CarregarDicionario(dicionarioPath);
        }

        private void CarregarDicionario(string caminhoDicionario)
        {
            string[] palavras = fileManager.Loaddicionario(caminho);
            foreach (string word in palavras)
            {
                dicionario.Add(word.Trim());
            }
        }

        public void SalvarDicionario(string caminho)
        {
            Arquivos.SalvarDicionario(caminho, dicionario);
        }

        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;
            return fileManager.LoadFile(caminhoArquivo);
        }

        public void SalvarArquivo(string conteudo)
        {
            fileManager.SaveFile(caminhoArquivo, conteudo);
        }

        public void ValidarTexto(string texto)
        {
            string[] palavras = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palavra in palavras)
            {
                if (!dicionario.Contains(palavra))
                {
                    DialogResult result = MessageBox.Show($"A palavra '{palavra}' não está no dicionário. Deseja adicioná-la?", "Adicionar Palavra", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dicionario.Add(word);
                    }
                }
            }
        }
    }
}
