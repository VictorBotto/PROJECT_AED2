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
        private EditorDeTexto EditorDeTexto;

        public MainForm()
        {
            EditorDeTexto = new EditorDeTexto("dictionary.txt");

            textBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill
            };

            openButton = new Button
            {
                Text = "Abrir",
                Dock = DockStyle.Top
            };
            openButton.Click += OpenButton_Click;

            saveButton = new Button
            {
                Text = "Salvar",
                Dock = DockStyle.Top
            };
            saveButton.Click += SaveButton_Click;

            validateButton = new Button
            {
                Text = "Validar",
                Dock = DockStyle.Top
            };
            validateButton.Click += ValidateButton_Click;

            Controls.Add(textBox);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(validateButton);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string conteudo = EditorDeTexto.AbrirArquivo(openFileDialog.FileName);
                textBox.Text = conteudo;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            EditorDeTexto.SalvarArquivo(textBox.Text);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            EditorDeTexto.ValidarTexto(textBox.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            EditorDeTexto.SalvarDicionario("dictionary.txt");
        }
    }
}
