namespace calculo_cdb.Logica;

public class CdbCalculatorService : ICdbCalculatorService
{
    public ResultadoCdbCalculo ExecutarCalculoCdb(int qtdMeses, double ValorInicial)
    {
        if (ValorInicial <= 0)
        {
            throw new ArgumentException("O valor inicial deve ser um valor monetário positivo.");
        }

        if (qtdMeses <= 1)
        {
            throw new ArgumentException("O prazo em meses, deve ser maior que 1(um).");
        }

        var resultados = new List<double>();
        var valorResultadoBruto = 0.0;

        const double cdi = 0.009; 
        const double taxaBancoSobreCdi = 1.08;

        for (int i = 0; i < qtdMeses; i++)
        {
            var resultadoMesAnterior = (i == 0 && resultados.Count == 0) ? ValorInicial : resultados[i - 1] ;
            var resultadoMes = resultadoMesAnterior * (1 + (cdi * taxaBancoSobreCdi));
            
            resultados.Add(resultadoMes);
        }

        valorResultadoBruto = resultados[resultados.Count - 1];

        var lucro = valorResultadoBruto - ValorInicial;

        var valorImposto = CalcularImposto(qtdMeses, lucro);

        double valorResultadoLiquido = ValorInicial + (lucro - valorImposto);

        var result = new ResultadoCdbCalculo { ResultadoBruto = resultados[resultados.Count - 1], ResultadoLiquido = valorResultadoLiquido  };

        return result;
    }

    public double CalcularImposto(int qtdMeses, double valorResultadoBruto)
    {
        if (valorResultadoBruto <= 0)
        {
            throw new ArgumentException("O valor do resultado bruto deve ser um valor monetário positivo.");
        }

        if (qtdMeses <= 1)
        {
            throw new ArgumentException("O prazo em meses, deve ser maior que 1(um).");
        }

        double valorImposto = 0.0;

        var taxasImposto = new Dictionary<int, double>
        {
            { 6, 0.225 },  // Até 6 meses: 22.5% de imposto
            { 12, 0.20 },  // Até 12 meses: 20% de imposto
            { 24, 0.175 }, // Até 24 meses: 17.5% de imposto
            { int.MaxValue, 0.15 } // Acima de 24 meses: 15% de imposto
        };

        double taxaImposto = taxasImposto.First(kv => qtdMeses <= kv.Key).Value;

        valorImposto = valorResultadoBruto * taxaImposto;

        return valorImposto;
    }
}
