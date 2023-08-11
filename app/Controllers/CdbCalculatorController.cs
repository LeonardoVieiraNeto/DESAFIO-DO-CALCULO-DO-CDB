using Microsoft.AspNetCore.Mvc;
using calculo_cdb.Logica;

namespace calculo_cdb.AngularApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbCalculatorController : ControllerBase
{
    public class CalculoInput
    {
        public int QtdMeses { get; set; }
        public double ValorInicial { get; set; }
    }

    private readonly ILogger<CdbCalculatorController> _logger;
    private readonly ICdbCalculatorService _cdbCalculatorService;

    public CdbCalculatorController(ILogger<CdbCalculatorController> logger, ICdbCalculatorService cdbCalculatorService)
    {
        _logger = logger;
        _cdbCalculatorService = cdbCalculatorService;
    }

    [HttpPost]
    public CdbCalculator CalcularCdb([FromBody] CalculoInput input)
    {
        var resultadoCdb = _cdbCalculatorService.ExecutarCalculoCdb(input.QtdMeses, input.ValorInicial);

        return new CdbCalculator
        {
            ResultadoBruto = resultadoCdb.ResultadoBruto,
            ResultadoLiquido = resultadoCdb.ResultadoLiquido
        };
    }
}
