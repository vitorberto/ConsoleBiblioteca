using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBiblioteca
{
    class Livros
    {
        private List<Livro> acervo = new List<Livro>();

        internal List<Livro> Acervo { get => acervo; set => acervo = value; }

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(int id)
        {
            return Acervo.Find(livro => livro.Isbn == id);
        }

        public void MostraLivros()
        {
            TableBuilder.PrintLine();
            TableBuilder.PrintRow("Identificador", "Titulo", "Autor", "Editora");
            TableBuilder.PrintLine();
            foreach (Livro livro in acervo)
            {
                TableBuilder.PrintRow(livro.Isbn.ToString(), livro.Titulo, livro.Autor, livro.Editora);
            }
            TableBuilder.PrintLine();
        }

    }
}
