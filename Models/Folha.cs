namespace PedroFranca.Models
{
    public class Folha
    {

        public Folha(float valorHora, int quantidadeHora, int mes, int ano, string funcionarioId)
        {
            Id = Guid.NewGuid().ToString();
            ValorHora = valorHora;
            QuantidadeHora = quantidadeHora;
            Mes = mes;
            Ano = ano;
            SalarioBruto = 0;
            ImpostoFgts = 0;
            ImpostoInss = 0;
            ImpostoIrrf = 0;
            SalarioLiquido = 0;
            FuncionarioId = funcionarioId;

        }

        public string Id { get; set; }
        
        public float ValorHora { get; set; }

        public int QuantidadeHora { get; set; }

        public int Mes {  get; set; }

        public int Ano { get; set; }

        public float SalarioBruto { get; set; }

        public float ImpostoIrrf { get; set; }

        public float ImpostoInss {  get; set; }

        public float ImpostoFgts { get; set; }

        public float SalarioLiquido { get; set; }

        public string FuncionarioId { get; set; }
    }

    public void calcularSalarioBruto(float ValorHora, int QuantidadeHora)
    {
        SalarioBruto = ValorHora * QuantidadeHora;
    }



}
