namespace EditorDeTexto
{
    public class No
    {
        public string Palavra { get; set; }
        public No Next { get; set; }

        public No(string palavra)
        {
            this.Palavra = palavra;
            Next = null;
        }
    }
}