using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBiblioteca
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares = new List<Exemplar>();

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }

        public void adicionarExemplar()
        {
            Exemplares.Add(new Exemplar(exemplares.Count + 1));
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            int count = 0;
            foreach(Exemplar exemplar in Exemplares)
            {
                if (exemplar.Disponivel())
                    count++;
            }

            return count;
        }

        public int QtdeEmprestimos()
        {
            int count = 0;
            foreach(Exemplar exemplar in Exemplares)
            {
                if (!exemplar.Disponivel())
                    count++;
            }

            return count;
        }

        public double PercDisponibilidade()
        {
            try
            {
                return QtdeDisponiveis() / QtdeExemplares() * 100;
            }
            catch
            {
                return 0;
            }
        }
    }
}
