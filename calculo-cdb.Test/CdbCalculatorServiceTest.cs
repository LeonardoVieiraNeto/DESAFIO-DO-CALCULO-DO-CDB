using calculo_cdb.Logica;

namespace calculo_cdb.Test;

[TestClass]
public class CdbCalculatorServiceTest
{
    [TestMethod]
    public void ExecutarCalculoCdb_Should_ReturnExpectedResult()
    {
            // Arrange
            ICdbCalculatorService cdbCalculatorService = new CdbCalculatorService();

            // Act
            var result = cdbCalculatorService.ExecutarCalculoCdb(5, 100);

            // Assert
            Assert.AreEqual(104.95540120180826, result.ResultadoBruto);
            Assert.AreEqual(81.3404359314014, result.ResultadoLiquido);
    }

    [TestMethod]
    public void CalcularImposto_Should_ReturnExpectedResult()
    {
            // Arrange
            ICdbCalculatorService cdbCalculatorService = new CdbCalculatorService();

            // Act
            var result = cdbCalculatorService.CalcularImposto(5, 100);

            // Assert
            Assert.AreEqual(22.5, result);
    }
}