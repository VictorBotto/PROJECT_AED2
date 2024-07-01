using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    // Classe reponsável por iniciar a aplicação
    static class Program
    {
        [STAThread] // Atributo que indica que o método Main será executado em uma thread de STA (Single Threaded Apartment)
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita o estilo visual do sistema operacional
            Application.SetCompatibleTextRenderingDefault(false); // Define o estilo de renderização de texto padrão
            Application.Run(new MainForm()); // Inicia o formulário principal da aplicação
        }
    }
}
