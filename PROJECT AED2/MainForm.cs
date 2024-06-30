using System;
using System.IO;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public class MainForm : Form
    {
        private TextBox textBox;
        private Button openButton; // abrir arquivo de dicionario
        private Button saveButton; //botão para salvar palavras escritas
        private Button validateButton; //botão para validar palavras escritas
        private Button newDictionaryButton; //botão para criar novo dicionário
        private EditorDeTexto EditorDeTexto; //botão para editar dicionário selecionado

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
                Text = "Abrir Dicionário",
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

            newDictionaryButton = new Button // Botão para criar novo dicionário
            {
                Text = "Novo Dicionário",
                Dock = DockStyle.Top
            };
            newDictionaryButton.Click += NewDictionaryButton_Click;

            Controls.Add(textBox);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(validateButton);
            Controls.Add(newDictionaryButton); // Adiciona o novo botão à interface
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
            try
            {
                EditorDeTexto.SalvarArquivo(textBox.Text);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            EditorDeTexto.ValidarTexto(textBox.Text);
        }

        private void NewDictionaryButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos de Texto|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string novoCaminho = saveFileDialog.FileName;
                CriarNovoDicionario(novoCaminho);
            }
        }

        private void CriarNovoDicionario(string caminho)
        {
            // Cria um novo arquivo de texto vazio
            using (StreamWriter writer = File.CreateText(caminho))
            {
                // Escreve um conteúdo inicial opcional, se necessário
            }

            // Atualiza o EditorDeTexto com o novo arquivo
            EditorDeTexto = new EditorDeTexto(caminho);

            // Limpa o textBox, se desejado
            textBox.Text = string.Empty;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            EditorDeTexto.SalvarDicionario("dictionary.txt");
        }
    }
}
