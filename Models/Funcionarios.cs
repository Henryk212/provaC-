public class Funcionarios {

    public Funcionarios(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Id = Guid.NewGuid().ToString();


    }

    public string? Id { get; set; }

    public string? Nome { get; set; }

    public string Cpf { get; set; }



}