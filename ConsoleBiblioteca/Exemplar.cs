using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBiblioteca
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
        }

        public int Tombo { get => tombo; set => tombo = value; }
        public List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public bool Emprestar()
        {
            try
            {
                if (Disponivel())
                {
                    emprestimos.Add(new Emprestimo(DateTime.Now));
                    return true;
                }
                else
                {
                    return false;
                }

            } 
            catch
            {
                return false;
            }
        }

        public bool Devolver()
        {
            try
            {
                if (!Disponivel() && emprestimos.Count > 0)
                {
                    emprestimos[emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Disponivel()
        {
            if (emprestimos.Count > 0)
                return emprestimos[emprestimos.Count - 1].DtDevolucao != null;
            else
                return true;
        }

        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}
