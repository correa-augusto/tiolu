class Biblioteca2
{
    public List<Leitor> leitores = new List<Leitor>();

    public bool AdicionarLeitor(Leitor leitor)
    {
        if(leitores.Exists(l => l.Cpf == leitor.Cpf))
        {
            return false;
        }
        else
        {
            leitores.Add(leitor);
            return true;
        }
    }

    public void ListarLeitores()
    {
        leitores.ForEach(l => Console.WriteLine($"Nome: {l.Nome} | CPF: {l.Cpf}"));
    }

    public void ListarLeitorEspecifico(string cpf)
    {
        Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
        if (leitor != null)
        {
            Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf}");
            Console.WriteLine("Livros do leitor:");

            if (leitor.BuscarLivro().Any())
            {
              leitor.BuscarLivro().ForEach(livro => Console.WriteLine($"- {livro.Titulo} ({livro.AnoPublicacao})"));
            }
            else
            {
             Console.WriteLine("Nenhum livro cadastrado.");
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
    }



    public void RemoverLeitor(string cpf)
    {
        leitores.RemoveAll(l => l.Cpf == cpf);
    }

    public void EditarLeitor(string cpf)
    {
        Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
        if (leitor != null)
        {
            Console.Write($"Novo nome para {leitor.Nome}: ");
            string novoNome = Console.ReadLine();

            leitor.EditarNome(novoNome);
            Console.WriteLine("Leitor atualizado com sucesso!");
        }
        else
        {
             Console.WriteLine("Leitor não encontrado.");
        }
    }


    public void AdicionarLivrosAoLeitor(string cpf, Livro livro)
    {
        Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
        leitor.AdicionarLivro(livro);
    }

    public void EditarLivroDoLeitor(string cpf, string titulo)
    {
        Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
        Livro livro = leitor.BuscarLivro(titulo);

        if (livro != null)
        {
            Console.Write("Novo título: ");
            string novoTitulo = Console.ReadLine();

            Console.Write("Novo autor: ");
            string novoAutor = Console.ReadLine();

            Console.Write("Novo ano: ");
            int novoAno = int.Parse(Console.ReadLine());

            leitores.Remove(leitor);
            leitor.RemoverLivro(titulo);
            leitor.AdicionarLivro(new Livro(novoTitulo, novoAutor, novoAno));
            leitores.Add(leitor);
        }
    }

    public void RemoverLivroDoLeitor(string cpf, string titulo)
    {
        Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
        if (leitor != null)
        {
            leitor.RemoverLivro(titulo);
            Console.WriteLine($"Livro \"{titulo}\" removido do leitor {leitor.Nome}.");
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
    }   

     public void BuscarLivro(string titulo)
    {
        leitores.ForEach(l =>
        {
            if (l.ObterLivros().Any(livro => livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)))
                Console.WriteLine($"Leitor: {l.Nome} - CPF: {l.Cpf}");
        });
    }
}