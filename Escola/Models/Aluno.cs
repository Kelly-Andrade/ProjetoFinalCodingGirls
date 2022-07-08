namespace Escola.Models
{
    public class Aluno
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime Data_Nascimento { get; set; }
		public char Sexo { get; set; }
		public int Total_Faltas { get; set; }


		public int Turma_Id { get; set; }

		public virtual Turma Turma { internal get; set; }
    }
}
/*CREATE TABLE Aluno(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Data_Nascimento DATETIME NOT NULL,
	Sexo CHAR(1) NOT NULL,
	Turma_Id INT FOREIGN KEY REFERENCES Turma(Id) NOT NULL,
	Total_Faltas INT NOT NULL
);

*/