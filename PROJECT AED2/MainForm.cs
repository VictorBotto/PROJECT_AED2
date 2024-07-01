using System;
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

        public MainForm()
        {
            editorDeTexto = new EditorDeTexto("dictionary.txt");

            textBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill
            };

            newWordBox = new TextBox
            {
                Text = "Digite a nova palavra",
                Dock = DockStyle.Bottom,
                Margin = new Padding(10)
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
                Width = 100
            };
            saveButton.Click += SaveButton_Click;

            validateButton = new Button
            {
                Text = "Validar",
                Width = 100
            };
            validateButton.Click += ValidateButton_Click;

            addWordButton = new Button
            {
                Text = "Adicionar Palavra",
                Width = 100
            };
            addWordButton.Click += AddWordButton_Click;

            removeWordButton = new Button
            {
                Text = "Remover Palavra",
                Width = 100
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
            }
        }

        private void NewWordBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newWordBox.Text))
            {
                newWordBox.Text = "Digite a nova palavra";
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string conteudo = editorDeTexto.AbrirArquivo(openFileDialog.FileName);
                textBox.Text = conteudo;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            editorDeTexto.SalvarArquivo(textBox.Text);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            editorDeTexto.ValidarTexto(textBox.Text);
        }

        private void AddWordButton_Click(object sender, EventArgs e)
        {
            string novaPalavra = newWordBox.Text.Trim();
            if (!string.IsNullOrEmpty(novaPalavra))
            {
                if (!editorDeTexto.PalavraExisteNoDicionario(novaPalavra))
                {
                    editorDeTexto.AdicionarPalavra(novaPalavra);
                    MessageBox.Show($"A palavra '{novaPalavra}' foi adicionada ao dicionário.", "Palavra Adicionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newWordBox.Text = "Digite a nova palavra";
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
            if (!string.IsNullOrEmpty(palavra))
            {
                if (editorDeTexto.PalavraExisteNoDicionario(palavra))
                {
                    editorDeTexto.RemoverPalavra(palavra);
                    MessageBox.Show($"A palavra '{palavra}' foi removida do dicionário.", "Palavra Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newWordBox.Text = "Digite a nova palavra";
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
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            editorDeTexto.SalvarDicionario("dictionary.txt");
        }
    }
}
