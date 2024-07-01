namespace EditorDeTexto
{
    public class No
    {
        // Atributo que armazena a palavra do nó
        public string Palavra { get; set; }

        // Atributo que armazena a referência para o próximo nó na lista encadeada
        public No Next { get; set; }

        // Construtor que inicializa o nó com a palavra fornecida
        public No(string palavra)
        {
            this.Palavra = palavra;  // Inicializa a propriedade Palavra com o valor fornecido
            Next = null;  // Inicializa a referência para o próximo nó como nula
        }
    }
}
