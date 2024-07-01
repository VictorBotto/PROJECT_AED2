using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EditorDeTexto
{
    // Classe que representa um dicionário de palavras
    public class Dicionario
    {
        private TabelaHash palavras; // Tabela hash que armazena as palavras
        private string caminhoArquivo;

        public Dicionario(string caminhoArquivo, int tamanhoTabelaHash = 100)
        {
            this.caminhoArquivo = caminhoArquivo;
            palavras = new TabelaHash(tamanhoTabelaHash);
            CarregarDicionario();
        }

        // Método que carrega o dicionário a partir de um arquivo
        private void CarregarDicionario()
        {
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    palavras.Adicionar(linha.Trim());
                }
            }
        }
        // Método que verifica se a palavra existe no dicionário
        public bool ExistePalavra(string palavra)
        {
            return palavras.Contains(palavra);
        }
        // Método que adiciona uma palavra no dicionário
        public void AdicionarPalavra(string palavra)
        {
            if (!palavras.Contains(palavra))
            {
                palavras.Adicionar(palavra);
                SalvarDicionario();
            }
        }

        // Método que remove uma palavra do dicionário
        public void RemoverPalavra(string palavra)
        {
            if (palavras.Contains(palavra))
            {
                palavras.Remover(palavra);
                SalvarDicionario();
            }
        }

        // Método que valida o texto e retorna as palavras não encontradas
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

        // Método que salva o dicionário em um arquivo
        public void SalvarDicionario()
        {
            try
            {
                File.WriteAllLines(caminhoArquivo, palavras.ObterPalavras());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o dicionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
