using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EditorDeTexto
{
    //Classe responsável por criar a interface gráfica do programa
    public class MainForm : Form
    {
        private RichTextBox textBox;
        private TextBox newWordBox;
        private Button openButton;
        private Button saveButton;
        private Button validateButton;
        private Button addWordButton;
        private Button removeWordButton;
        private Button newFileButton;
        private EditorDeTexto editorDeTexto;
        private Dicionario dicionario;
        private SplitContainer splitContainer;

        private bool arquivoAberto = false;

        public MainForm()
        {
            editorDeTexto = new EditorDeTexto("dictionary.txt"); // Nome do arquivo de dicionário
            dicionario = editorDeTexto.ObterDicionario(); // Carregar dicionário

            textBox = new RichTextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = false
            };

            newWordBox = new TextBox
            {
                Text = "Digite a nova palavra",
                ForeColor = SystemColors.GrayText,
                Dock = DockStyle.Bottom,
                Margin = new Padding(10),
                Enabled = false
            };
            newWordBox.GotFocus += NewWordBox_GotFocus;
            newWordBox.LostFocus += NewWordBox_LostFocus;

            openButton = new Button
            {
                Text = "Abrir",
                Width = 100
            };
            openButton.Click += OpenButton_Click;

            saveButton = new Button
            {
                Text = "Salvar Arquivo",
                Width = 100,
                Enabled = false
            };
            saveButton.Click += SaveButton_Click;

            validateButton = new Button
            {
                Text = "Validar",
                Width = 100,
                Enabled = false
            };
            validateButton.Click += ValidateButton_Click;

            addWordButton = new Button
            {
                Text = "Adicionar Palavra",
                Width = 100,
                Enabled = false
            };
            addWordButton.Click += AddWordButton_Click;

            removeWordButton = new Button
            {
                Text = "Remover Palavra",
                Width = 100,
                Enabled = false
            };
            removeWordButton.Click += RemoveWordButton_Click;

            newFileButton = new Button
            {
                Text = "Novo Arquivo",
                Width = 100
            };
            newFileButton.Click += NewFileButton_Click;

            FlowLayoutPanel topButtonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            topButtonPanel.Controls.Add(openButton);
            topButtonPanel.Controls.Add(saveButton);
            topButtonPanel.Controls.Add(newFileButton);

            FlowLayoutPanel bottomButtonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            bottomButtonPanel.Controls.Add(validateButton);
            bottomButtonPanel.Controls.Add(addWordButton);
            bottomButtonPanel.Controls.Add(removeWordButton);

            splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                Panel1MinSize = 100,
                Panel2MinSize = 100
            };

            splitContainer.Panel1.Controls.Add(topButtonPanel);
            splitContainer.Panel2.Controls.Add(textBox);
            splitContainer.Panel2.Controls.Add(newWordBox);
            splitContainer.Panel2.Controls.Add(bottomButtonPanel);

            Controls.Add(splitContainer);
        }

        private void NewWordBox_GotFocus(object sender, EventArgs e)
        {
            if (newWordBox.Text == "Digite a nova palavra")
            {
                newWordBox.Text = string.Empty;
                newWordBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void NewWordBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newWordBox.Text))
            {
                newWordBox.Text = "Digite a nova palavra";
                newWordBox.ForeColor = SystemColors.GrayText; 
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string conteudo = editorDeTexto.AbrirArquivo(openFileDialog.FileName);
                textBox.Text = conteudo;
                arquivoAberto = true;
                AtualizarEstadoBotoes();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!arquivoAberto)
                return;

            editorDeTexto.SalvarArquivo(textBox.Text);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            if (!arquivoAberto)
                return;

            List<string> palavrasNaoEncontradas = dicionario.ValidarTexto(textBox.Text, out List<string> palavrasEncontradas);

            if (palavrasNaoEncontradas.Any())
            {
                string mensagem = $"As seguintes palavras não estão no dicionário:\n\n";
                mensagem += string.Join("\n", palavrasNaoEncontradas);
                mensagem += "\n\nDeseja adicionar essas palavras ao dicionário?";

                DialogResult result = MessageBox.Show(mensagem, "Palavras não encontradas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (string palavra in palavrasNaoEncontradas)
                    {
                        dicionario.AdicionarPalavra(palavra);
                    }
                }
            }
            else
            {
                MessageBox.Show("Texto validado. Todas as palavras estão no dicionário.", "Validação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DestacarPalavrasEncontradas(palavrasEncontradas);
        }

        private void AddWordButton_Click(object sender, EventArgs e)
        {
            string novaPalavra = newWordBox.Text.Trim();
            if (!string.IsNullOrEmpty(novaPalavra) && novaPalavra != "Digite a nova palavra")
            {
                if (!dicionario.ExistePalavra(novaPalavra))
                {
                    dicionario.AdicionarPalavra(novaPalavra);
                    MessageBox.Show($"A palavra '{novaPalavra}' foi adicionada ao dicionário.", "Palavra Adicionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newWordBox.Text = string.Empty;
                    AtualizarPalavrasNoTextBox();
                }
                else
                {
                    MessageBox.Show($"A palavra '{novaPalavra}' já existe no dicionário.", "Palavra Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void RemoveWordButton_Click(object sender, EventArgs e)
        {
            string palavraParaRemover = newWordBox.Text.Trim();
            if (!string.IsNullOrEmpty(palavraParaRemover) && palavraParaRemover != "Digite a nova palavra")
            {
                if (dicionario.ExistePalavra(palavraParaRemover))
                {
                    dicionario.RemoverPalavra(palavraParaRemover);
                    MessageBox.Show($"A palavra '{palavraParaRemover}' foi removida do dicionário.", "Palavra Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newWordBox.Text = string.Empty;
                    AtualizarPalavrasNoTextBox();
                }
                else
                {
                    MessageBox.Show($"A palavra '{palavraParaRemover}' não foi encontrada no dicionário.", "Palavra Não Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void NewFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editorDeTexto.CriarNovoArquivo(saveFileDialog.FileName);
                textBox.Text = string.Empty;
                arquivoAberto = true;
                AtualizarEstadoBotoes();
            }
        }

        private void AtualizarEstadoBotoes()
        {
            saveButton.Enabled = arquivoAberto;
            validateButton.Enabled = arquivoAberto;
            addWordButton.Enabled = arquivoAberto;
            removeWordButton.Enabled = arquivoAberto;
            newWordBox.Enabled = arquivoAberto;
        }

        private void AtualizarPalavrasNoTextBox()
        {
            textBox.Text = editorDeTexto.ObterConteudo();
        }

        private void DestacarPalavrasEncontradas(List<string> palavrasEncontradas)
        {
            textBox.SelectAll();
            textBox.SelectionBackColor = Color.White;

            foreach (string palavra in palavrasEncontradas)
            {
                int startIndex = 0;
                while ((startIndex = textBox.Text.IndexOf(palavra, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    textBox.Select(startIndex, palavra.Length);
                    textBox.SelectionBackColor = Color.Yellow;
                    startIndex += palavra.Length;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            dicionario.SalvarDicionario();
        }
    }
}
