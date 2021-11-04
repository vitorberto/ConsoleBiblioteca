using System;

namespace ConsoleBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            Livros livros = new Livros();

            do
            {
                Console.Clear();
                TableBuilder.PrintLine();
                TableBuilder.PrintRowNC("0. Sair");
                TableBuilder.PrintRowNC("1. Adicionar livro");
                TableBuilder.PrintRowNC("2. Pesquisar livro (sintético)");
                TableBuilder.PrintRowNC("3. Pesquisar livro (analítico)");
                TableBuilder.PrintRowNC("4. Adicionar exemplar");
                TableBuilder.PrintRowNC("5. Registrar empréstimo");
                TableBuilder.PrintRowNC("6. Registrar devolução");
                TableBuilder.PrintLine();
                Console.Write("Sua escolha: ");

                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        string titulo, autor, editora;
                        Console.Clear();

                        Console.WriteLine("Digite os dados do livro");
                        Console.Write("Titulo: ");
                        titulo = Console.ReadLine();

                        Console.Write("Autor: ");
                        autor = Console.ReadLine();

                        Console.Write("Editora: ");
                        editora = Console.ReadLine();

                        livros.Adicionar(new Livro(livros.Acervo.Count + 1, titulo, autor, editora));
                        break;
                    case 2:
                        int identificador;
                        Livro resultado;

                        Console.Clear();
                        livros.MostraLivros();
                        Console.Write("Digite o identificador do livro para pesquisa: ");
                        identificador = int.Parse(Console.ReadLine());

                        resultado = livros.Pesquisar(identificador);
                        if (resultado != null)
                        {
                            Console.Clear();
                            TableBuilder.PrintRow("Identificador", "Titulo", "Autor", "Editora", "Disponíveis", "Emprestados", "Porcentagem");
                            TableBuilder.PrintLine();
                            TableBuilder.PrintRow(resultado.Isbn.ToString(), resultado.Titulo.ToString(), resultado.Autor.ToString(), resultado.Editora.ToString(), resultado.QtdeDisponiveis().ToString(), resultado.QtdeEmprestimos().ToString(), resultado.PercDisponibilidade().ToString());
                            TableBuilder.PrintLine();
                        }
                        else
                        {
                            Console.WriteLine("Nenhum livro encontrado");
                        }

                        Console.ReadLine();
                        break;
                    case 3:
                        int identificador2;
                        Livro resultado2;

                        Console.Clear();
                        livros.MostraLivros();
                        Console.Write("Digite o identificador do livro para pesquisa: ");
                        identificador2 = int.Parse(Console.ReadLine());

                        resultado2 = livros.Pesquisar(identificador2);
                        if (resultado2 != null)
                        {
                            Console.Clear();
                            TableBuilder.PrintLine();
                            TableBuilder.PrintRow("Identificador", "Titulo", "Autor", "Editora", "Disponíveis", "Emprestados", "Porcentagem");
                            TableBuilder.PrintLine();
                            TableBuilder.PrintRow(resultado2.Isbn.ToString(), resultado2.Titulo.ToString(), resultado2.Autor.ToString(), resultado2.Editora.ToString(), resultado2.QtdeDisponiveis().ToString(), resultado2.QtdeEmprestimos().ToString(), resultado2.PercDisponibilidade().ToString());
                            TableBuilder.PrintLine();

                            Console.WriteLine();
                            TableBuilder.PrintRowNC("Exemplares");
                            TableBuilder.PrintLine();

                            if (resultado2.Exemplares.Count > 0)
                            {
                                TableBuilder.PrintRow("Tombo", "Qtd. Emprestimos", "disponivel");
                                TableBuilder.PrintLine();
                                foreach (Exemplar exemplar in resultado2.Exemplares)
                                {
                                    TableBuilder.PrintRow(exemplar.Tombo.ToString(), exemplar.QtdeEmprestimos().ToString(), exemplar.Disponivel() ? "sim" : "não");
                                    TableBuilder.PrintLine();

                                    if (exemplar.Emprestimos.Count > 0)
                                    {
                                        TableBuilder.PrintRow("Emprestimos do tombo " + exemplar.Tombo);
                                        TableBuilder.PrintLine();
                                        TableBuilder.PrintRow("Emprestimo", "Devolução");
                                        foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                                        {
                                            TableBuilder.PrintRow(emprestimo.DtEmprestimo.ToString(), emprestimo.DtDevolucao.ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nenhum emprestimo encontrado");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("nenhum exemplar encontrado");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum livro encontrado");
                        }

                        Console.ReadLine();

                        break;
                    case 4:
                        int identificadorAddExemplar;
                        Livro resultadoAddExemplar;

                        Console.Clear();
                        livros.MostraLivros();
                        Console.Write("Digite o identificador do livro para adicionar exemplar: ");
                        identificadorAddExemplar = int.Parse(Console.ReadLine());

                        resultadoAddExemplar = livros.Pesquisar(identificadorAddExemplar);
                        if (resultadoAddExemplar != null)
                        {
                            resultadoAddExemplar.adicionarExemplar();
                            Console.WriteLine("Exemplar adicionado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado");
                        }
                        break;
                    case 5:
                        int identificadorAddEmprestimo;
                        Livro resultadoAddEmprestimo;

                        Console.Clear();
                        livros.MostraLivros();
                        Console.Write("Digite o identificador do livro para emprestimo: ");
                        identificadorAddEmprestimo = int.Parse(Console.ReadLine());
                        resultadoAddEmprestimo = livros.Pesquisar(identificadorAddEmprestimo);
                        if (resultadoAddEmprestimo.Exemplares.Count > 0)
                        {
                            TableBuilder.PrintRow("Tombo", "Qtd. Emprestimos", "disponivel");
                            TableBuilder.PrintLine();
                            foreach (Exemplar exemplar in resultadoAddEmprestimo.Exemplares)
                            {
                                TableBuilder.PrintRow(exemplar.Tombo.ToString(), exemplar.QtdeEmprestimos().ToString(), exemplar.Disponivel() ? "sim" : "não");
                                TableBuilder.PrintLine();

                                if (exemplar.Emprestimos.Count > 0)
                                {
                                    TableBuilder.PrintRow("Emprestimos do tombo " + exemplar.Tombo);
                                    TableBuilder.PrintLine();
                                    TableBuilder.PrintRow("Emprestimo", "Devolução");
                                    foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                                    {
                                        TableBuilder.PrintRow(emprestimo.DtEmprestimo.ToString(), emprestimo.DtDevolucao.ToString());
                                    }
                                }
                            }

                            Console.Write("Digite o tombo do exemplar: ");
                            int tombo = int.Parse(Console.ReadLine());
                            Exemplar resultadoExemplar = resultadoAddEmprestimo.Exemplares.Find(ex => ex.Tombo == tombo);

                            bool emprestou = resultadoExemplar.Emprestar();
                            if (emprestou)
                            {
                                Console.WriteLine("Exemplar emprestado com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Exemplar indisponível para emprestimo");
                            }

                            Console.ReadLine();
                        }

                        break;
                    case 6:
                        int identificadorDevolucao;
                        Livro resultadoDevolucao;

                        Console.Clear();
                        livros.MostraLivros();
                        Console.Write("Digite o identificador do livro para fazer a devolucao: ");
                        identificadorDevolucao = int.Parse(Console.ReadLine());
                        resultadoDevolucao = livros.Pesquisar(identificadorDevolucao);

                        if (resultadoDevolucao.Exemplares.Count > 0)
                        {
                            TableBuilder.PrintRow("Tombo", "Qtd. Emprestimos", "disponivel");
                            TableBuilder.PrintLine();
                            foreach (Exemplar exemplar in resultadoDevolucao.Exemplares)
                            {
                                TableBuilder.PrintRow(exemplar.Tombo.ToString(), exemplar.QtdeEmprestimos().ToString(), exemplar.Disponivel() ? "sim" : "não");
                                TableBuilder.PrintLine();

                                if (exemplar.Emprestimos.Count > 0)
                                {
                                    TableBuilder.PrintRow("Emprestimos do tombo " + exemplar.Tombo);
                                    TableBuilder.PrintLine();
                                    TableBuilder.PrintRow("Emprestimo", "Devolução");
                                    foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                                    {
                                        TableBuilder.PrintRow(emprestimo.DtEmprestimo.ToString(), emprestimo.DtDevolucao.Year != 1 ? emprestimo.DtDevolucao.ToString() : "Não devolvido ainda");
                                    }

                                    Console.Write("Digite o tombo do exemplar: ");
                                    int tombo = int.Parse(Console.ReadLine());
                                    Exemplar resultadoExemplar = resultadoDevolucao.Exemplares.Find(ex => ex.Tombo == tombo);

                                    bool devolveu = resultadoExemplar.Devolver();
                                    if (devolveu)
                                    {
                                        Console.WriteLine("Exemplar devolvido com sucesso");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Exemplar não foi emprestado");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nenhum emprestimo encontrado");
                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("Nenhum exemplar encontrado");
                        }
                        break;
                }
            } while (escolha != 0);
        }

    }
}
