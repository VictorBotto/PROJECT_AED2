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
            foreach (string palavra in palavras)
            {
                dicionario.Adicionar(palavra.Trim());
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
            if (string.IsNullOrEmpty(caminhoArquivo))
            {
                MessageBox.Show("Nenhum arquivo aberto para salvar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        public void AdicionarPalavra(string palavra)
        {
            dicionario.Adicionar(palavra);
        }

        public void RemoverPalavra(string palavra)
        {
            dicionario.Remover(palavra);
        }

        public bool PalavraExisteNoDicionario(string palavra)
        {
            return dicionario.Contains(palavra);
        }

        public void CriarNovoArquivo(string caminho)
        {
            arquivos.CriarNovoArquivo(caminho);
        }

        public string ObterConteudo()
        {
            return arquivos.CarregarArquivo(caminhoArquivo);
        }
    }
}
