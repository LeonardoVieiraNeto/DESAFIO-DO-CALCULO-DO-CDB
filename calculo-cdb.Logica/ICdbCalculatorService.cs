namespace calculo_cdb.Logica;

public interface ICdbCalculatorService 
{
    ResultadoCdbCalculo ExecutarCalculoCdb(int qtdMeses, double ValorInicial);
    double CalcularImposto(int qtdMeses, double valorResultadoBruto);
}
