using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class MainForm : Form
    {
        private TextBox textBox;
        private Button openButton;
        private Button saveButton;
        private Button validateButton;
        private Button newWordButton;
        private Button removeWordButton;
        private Button newFileButton;
        private EditorDeTexto editorDeTexto;

        public MainForm()
        {
            editorDeTexto = new EditorDeTexto("dictionary.txt");

            textBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill
            };

            openButton = new Button
            {
                Text = "Abrir"
            };
            openButton.Click += OpenButton_Click;

            saveButton = new Button
            {
                Text = "Salvar"
            };
            saveButton.Click += SaveButton_Click;

            validateButton = new Button
            {
                Text = "Validar"
            };
            validateButton.Click += ValidateButton_Click;

            newWordButton = new Button
            {
                Text = "Adicionar Palavra"
            };
            newWordButton.Click += NewWordButton_Click;

            removeWordButton = new Button
            {
                Text = "Remover Palavra"
            };
            removeWordButton.Click += RemoveWordButton_Click;

            newFileButton = new Button
            {
                Text = "Novo Arquivo"
            };
            newFileButton.Click += NewFileButton_Click;

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft
            };

            buttonPanel.Controls.Add(openButton);
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(validateButton);
            buttonPanel.Controls.Add(newWordButton);
            buttonPanel.Controls.Add(removeWordButton);
            buttonPanel.Controls.Add(newFileButton);

            Controls.Add(textBox); // Adicionando o textBox ao formulário
            Controls.Add(buttonPanel); // Adicionando o buttonPanel ao formulário
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

        private void NewWordButton_Click(object sender, EventArgs e)
        {
            string novaPalavra = Microsoft.VisualBasic.Interaction.InputBox("Digite a nova palavra:", "Adicionar Palavra", "");
            if (!string.IsNullOrEmpty(novaPalavra))
            {
                editorDeTexto.AdicionarPalavra(novaPalavra);
            }
        }

        private void RemoveWordButton_Click(object sender, EventArgs e)
        {
            string palavra = Microsoft.VisualBasic.Interaction.InputBox("Digite a palavra a ser removida:", "Remover Palavra", "");
            if (!string.IsNullOrEmpty(palavra))
            {
                editorDeTexto.RemoverPalavra(palavra);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(563, 346);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}
