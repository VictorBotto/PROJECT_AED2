using System;
using System.Windows.Forms;

namespace EditorDeTexto
{
    // Classe repons�vel por iniciar a aplica��o
    static class Program
    {
        [STAThread] // Atributo que indica que o m�todo Main ser� executado em uma thread de STA (Single Threaded Apartment)
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita o estilo visual do sistema operacional
            Application.SetCompatibleTextRenderingDefault(false); // Define o estilo de renderiza��o de texto padr�o
            Application.Run(new MainForm()); // Inicia o formul�rio principal da aplica��o
        }
    }
}
