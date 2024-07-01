using System.Collections.Generic;
using System.Linq;

namespace EditorDeTexto
{
    public class TabelaHash
    {
        private HashSet<string> palavras; // Estrutura de dados para armazenar as palavras �nicas

        public TabelaHash()
        {
            palavras = new HashSet<string>();
        }

        public void Adicionar(string palavra)
        {
            palavras.Add(palavra.ToLower()); // Adiciona a palavra em min�sculas para garantir a unicidade
        }

        public void Remover(string palavra)
        {
            palavras.Remove(palavra.ToLower()); // Remove a palavra em min�sculas
        }

        public bool Contains(string palavra)
        {
            return palavras.Contains(palavra.ToLower()); // Verifica se a palavra est� presente, ignorando mai�sculas/min�sculas
        }

        public string[] ObterPalavras()
        {
            return palavras.ToArray(); // Retorna todas as palavras como um array de strings
        }
    }
}
