using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBiblioteca
{
    class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public Emprestimo(DateTime dtEmprestimo)
        {
            this.dtEmprestimo = dtEmprestimo;
        }

        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }
        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }
    }
}
