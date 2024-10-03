namespace VatCalculator.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using VatCalculator.Server.Models;
    using VatCalculator.Server.Services.Interfaces;

    /// <summary>
    /// VAT Calculator COntroller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VatCalculationController : ControllerBase
    {
        private readonly IVatCalculationService _vatCalculationService;

        public VatCalculationController(IVatCalculationService vatCalculationService)
        {
            _vatCalculationService = vatCalculationService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculationRequest request)
        {
            try
            {
                var result = _vatCalculationService.CalculateAmounts(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
