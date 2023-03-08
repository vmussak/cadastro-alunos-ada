namespace Ada.Aluno.Core;

public class Aluno : BaseEntity
{
    public Aluno(
        string nome,
        string cidade,
        string? nomeMae) : base()
    {
        this.Nome = nome;
        this.Cidade = cidade;
        this.NomeMae = nomeMae;
        this.Validate();
    }

    public Aluno() { }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cidade { get; set; }
    public string? NomeMae { get; set; }

    private void Validate()
    {
        if(string.IsNullOrWhiteSpace(this.Nome))
        {
            Messages.Add($"O {nameof(Nome)} deve ser preenchido");
        }

        if (string.IsNullOrWhiteSpace(this.Cidade))
        {
            Messages.Add("A Cidade deve ser preenchido");
        }

        IsValid = !Messages.Any();
    }
}

