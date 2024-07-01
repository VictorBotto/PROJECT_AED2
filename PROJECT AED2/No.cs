namespace EditorDeTexto
{
    public class No
    {
        // Atributo que armazena a palavra do n�
        public string Palavra { get; set; }

        // Atributo que armazena a refer�ncia para o pr�ximo n� na lista encadeada
        public No Next { get; set; }

        // Construtor que inicializa o n� com a palavra fornecida
        public No(string palavra)
        {
            this.Palavra = palavra;  // Inicializa a propriedade Palavra com o valor fornecido
            Next = null;  // Inicializa a refer�ncia para o pr�ximo n� como nula
        }
    }
}
