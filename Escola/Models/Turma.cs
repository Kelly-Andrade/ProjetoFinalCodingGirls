namespace Escola.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual List<Aluno> Aluno { internal get; set; }
    }
}

/* CREATE TABLE Turma(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nome VARCHAR(20) NOT NULL,
    Ativo BIT NOT NULL
);*/