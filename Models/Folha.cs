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

        public void calcularSalarioBruto(float ValorHora, int QuantidadeHora)
        {
            SalarioBruto = ValorHora * QuantidadeHora;
        }

        public void calcularImpostoInss(float SalarioBruto)
        {
            if (SalarioBruto <= 16893.72)
            {
                ImpostoInss = SalarioBruto * 0.08f;
            }
            else if (SalarioBruto > 16893.72 && SalarioBruto <= 2822.90)
            {
                ImpostoInss = SalarioBruto * 0.09f;
            }
            else if (SalarioBruto > 2822.90 && SalarioBruto <= 5645.81)
            {
                ImpostoInss = SalarioBruto * 0.11f;
            }
            else if (SalarioBruto > 5645.81)
            {
                ImpostoInss = 621.03f;
            }
            
        }

        public void calcularImpostoFgts(float SalarioBruto)
        {
            ImpostoFgts = SalarioBruto * 0.08f;
        }

        public void calcularImpostoIrrf(float SalarioBruto)
        {
             if (SalarioBruto <= 1903.98)
            {
                ImpostoInss = 0;
            }
            else if (SalarioBruto > 1903.98 && SalarioBruto <= 2826.65)
            {
                ImpostoInss = 142.80f;
            }
            else if (SalarioBruto > 2826.65 && SalarioBruto <= 3751.05)
            {
                ImpostoInss = 354.80f;
            }
            else if (SalarioBruto > 3751.05 && SalarioBruto <= 4664.68)
            {
                ImpostoInss = 636.13f;
            }
            else if (SalarioBruto > 4664.68)
            {
                ImpostoInss = 869.36f;
            }
        }
    }






}
