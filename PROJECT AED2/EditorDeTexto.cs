using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    //Anotacoes: MessageBox.Show usado para exibir uma mensagem na tela.

    public class EditorDeTexto
    {
        private TabelaHash dicionario;  // Estrutura de dados para armazenar palavras do dicionário
        private Arquivos arquivos;  // Instância da classe Arquivos para manipulação de arquivos
        private string caminhoArquivo;  // Armazena o caminho do arquivo atualmente aberto

        // Construtor que inicializa o dicionário e carrega o dicionário a partir de um arquivo
        public EditorDeTexto(string caminhoDicionario)
        {
            dicionario = new TabelaHash();  // Inicializa o dicionário
            arquivos = new Arquivos();  // Inicializa a instância de Arquivos
            CarregarDicionario(caminhoDicionario);  // Carrega as palavras do dicionário a partir do arquivo especificado
        }

        // Método privado para carregar palavras do dicionário a partir de um arquivo
        private void CarregarDicionario(string caminhoDicionario)
        {
            string[] palavras = arquivos.CarregarDicionario(caminhoDicionario);  // Carrega as palavras do arquivo
            foreach (string word in palavras)  // Para cada palavra carregada
            {
                dicionario.Adicionar(word.Trim());  // Adiciona a palavra ao dicionário, removendo espaços em branco nas extremidades
            }
        }

        // Método público para salvar o dicionário em um arquivo
        public void SalvarDicionario(string caminho)
        {
            arquivos.SalvarDicionario(caminho, dicionario);  // Salva o dicionário no arquivo especificado
        }

        // Método público para abrir um arquivo e retornar seu conteúdo
        public string AbrirArquivo(string caminho)
        {
            caminhoArquivo = caminho;  // Armazena o caminho do arquivo
            return arquivos.CarregarArquivo(caminhoArquivo);  // Carrega e retorna o conteúdo do arquivo
        }

        // Método público para salvar conteúdo no arquivo atualmente aberto
        public void SalvarArquivo(string conteudo)
        {
            if (string.IsNullOrEmpty(caminhoArquivo))
            {
                throw new InvalidOperationException("Nenhum arquivo aberto para salvar.");  // Lança uma exceção se nenhum arquivo estiver aberto
            }

            // Verifica se a palavra já existe no conteúdo atual do arquivo
            string conteudoAtual = arquivos.CarregarArquivo(caminhoArquivo);
            string[] palavrasAtuais = conteudoAtual.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palavra in conteudo.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (Array.Exists(palavrasAtuais, p => p.Equals(palavra, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"A palavra '{palavra}' já existe no arquivo.", "Palavra Existente", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mensagem na tela com informe de arquivo existente.
                    return; // Retorna sem salvar se encontrar uma palavra repetida
                }
            }

            arquivos.SalvarArquivo(caminhoArquivo, conteudo);  // Salva o conteúdo no arquivo
        }

        // Método público para validar o texto, verificando se cada palavra está no dicionário
        public void ValidarTexto(string texto)
        {
            string[] palavras = texto.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);  // Divide o texto em palavras, removendo entradas vazias
            foreach (string palavra in palavras)  // Para cada palavra no texto
            {
                if (!dicionario.Contains(palavra))  // Verifica se a palavra não está no dicionário
                {
                    DialogResult result = MessageBox.Show($"A palavra '{palavra}' não está no dicionário. Deseja adicioná-la?", "Adicionar Palavra", MessageBoxButtons.YesNo);  // Exibe uma caixa de diálogo perguntando se o usuário deseja adicionar a palavra
                    if (result == DialogResult.Yes)  // Se o usuário clicar em "Yes"
                    {
                        dicionario.Adicionar(palavra);  // Adiciona a palavra ao dicionário
                    }
                }
            }
        }

        // Método público para adicionar uma nova palavra ao dicionário
        public void AdicionarPalavra(string palavra)
        {
            dicionario.Adicionar(palavra); // Adiciona a palavra à tabela hash
        }

        // Método público para remover uma palavra do dicionário
        public void RemoverPalavra(string palavra)
        {
            dicionario.Remover(palavra); // Remove a palavra da tabela hash
        }

        // Método público para criar um novo arquivo
        public void CriarNovoArquivo(string caminho)
        {
            arquivos.CriarNovoArquivo(caminho); // Cria um novo arquivo
        }
    }
}
