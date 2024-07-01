using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class MainForm : Form
    {
        private TextBox textBox;
        private TextBox newWordBox;
        private Button openButton;
        private Button saveButton;
        private Button validateButton;
        private Button addWordButton;
        private Button removeWordButton;
        private Button newFileButton;
        private EditorDeTexto editorDeTexto;
        private SplitContainer splitContainer;

        private bool arquivoAberto = false;

        public MainForm()
        {
            editorDeTexto = new EditorDeTexto("dictionary.txt");

            textBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true
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

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            buttonPanel.Controls.Add(openButton);
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(validateButton);
            buttonPanel.Controls.Add(addWordButton);
            buttonPanel.Controls.Add(removeWordButton);
            buttonPanel.Controls.Add(newFileButton);

            splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                Panel1MinSize = 100,
                Panel2MinSize = 100
            };

            splitContainer.Panel1.Controls.Add(buttonPanel);
            splitContainer.Panel2.Controls.Add(textBox);
            splitContainer.Panel2.Controls.Add(newWordBox);

            Controls.Add(splitContainer);
        }

        private void NewWordBox_GotFocus(object sender, EventArgs e)
        {
            if (newWordBox.Text == "Digite a nova palavra")
            {
                newWordBox.Text = string.Empty;
                newWordBox.ForeColor = SystemColors.WindowText; // Restaura a cor do texto para preto
            }
        }

        private void NewWordBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newWordBox.Text))
            {
                newWordBox.Text = "Digite a nova palavra";
                newWordBox.ForeColor = SystemColors.GrayText; // Define a cor do texto como cinza
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
            string conteudoAtualizado = editorDeTexto.ObterConteudo();
            textBox.Text = conteudoAtualizado;
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            if (!arquivoAberto)
                return;

            editorDeTexto.ValidarTexto(textBox.Text);
        }

        private void AddWordButton_Click(object sender, EventArgs e)
        {
            string novaPalavra = newWordBox.Text.Trim();
            if (!string.IsNullOrEmpty(novaPalavra) && novaPalavra != "Digite a nova palavra")
            {
                if (!editorDeTexto.PalavraExisteNoDicionario(novaPalavra))
                {
                    editorDeTexto.AdicionarPalavra(novaPalavra);
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
            string palavra = newWordBox.Text.Trim();
            if (!string.IsNullOrEmpty(palavra) && palavra != "Digite a nova palavra")
            {
                if (editorDeTexto.PalavraExisteNoDicionario(palavra))
                {
                    editorDeTexto.RemoverPalavra(palavra);
                    MessageBox.Show($"A palavra '{palavra}' foi removida do dicionário.", "Palavra Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newWordBox.Text = string.Empty;
                    AtualizarPalavrasNoTextBox();
                }
                else
                {
                    MessageBox.Show($"A palavra '{palavra}' não existe no dicionário.", "Palavra Não Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string conteudoAtualizado = editorDeTexto.ObterConteudo();
            textBox.Text = conteudoAtualizado;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            editorDeTexto.SalvarDicionario("dictionary.txt");
        }
    }
}
