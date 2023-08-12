using calculo_cdb.Logica;

namespace calculo_cdb.Test;

[TestClass]
public class CdbCalculatorServiceTest
{
    ICdbCalculatorService cdbCalculatorService = new CdbCalculatorService();    

   [TestInitialize]
    public void Setup()
    {
        cdbCalculatorService = new CdbCalculatorService();
    }


    [TestMethod]
    public void Test_ExecutarCalculoCdb_ResultadosValidos()
    {
        int qtdMeses = 12;
        double valorInicial = 1000;

        var resultado = cdbCalculatorService.ExecutarCalculoCdb(qtdMeses, valorInicial);

        Assert.IsNotNull(resultado);
        Assert.IsTrue(resultado.ResultadoBruto > valorInicial);
        Assert.IsTrue(resultado.ResultadoLiquido >= valorInicial);
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_ResultadosDiferentesParaDiferentesValoresIniciais()
    {
        // Arrange
        int qtdMeses = 12;
        double valorInicial1 = 1000;
        double valorInicial2 = 1500;

        // Act
        var resultado1 = cdbCalculatorService.ExecutarCalculoCdb(qtdMeses, valorInicial1);
        var resultado2 = cdbCalculatorService.ExecutarCalculoCdb(qtdMeses, valorInicial2);

        // Assert
        Assert.AreNotEqual(resultado1.ResultadoBruto, resultado2.ResultadoBruto);
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_QtdMesesNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.ExecutarCalculoCdb(-1, 1000));
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_ValorInicialNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.ExecutarCalculoCdb(12, -1000));
    }

     [TestMethod]
    public void Test_ExecutarCalculoCdb_QtdMesesMenorQueDois()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.ExecutarCalculoCdb(1, 1000));
    }
}