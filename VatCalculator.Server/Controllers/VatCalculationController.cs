namespace VatCalculator.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using VatCalculator.Server.Models;
    using VatCalculator.Server.Services.Interfaces;

    /// <summary>
    /// VAT Calculator Controller.
    /// Handles API requests related to VAT calculations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VatCalculationController : ControllerBase
    {
        /// <summary>
        /// Service interface for VAT calculations.
        /// </summary>
        private readonly IVatCalculationService _vatCalculationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VatCalculationController"/> class.
        /// </summary>
        /// <param name="vatCalculationService">The VAT calculation service.</param>
        public VatCalculationController(IVatCalculationService vatCalculationService)
        {
            _vatCalculationService = vatCalculationService;
        }

        /// <summary>
        /// Handles the VAT calculation request.
        /// </summary>
        /// <param name="request">The calculation request body.</param>
        /// <returns>IActionResult containing the calculation result or an error response.</returns>
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
