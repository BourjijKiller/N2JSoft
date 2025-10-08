using System.ComponentModel.DataAnnotations;
using System.Net;

using DTO;

using Microsoft.AspNetCore.Mvc;

using Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// These routes needs the right to get expenses.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expensesService;
        private readonly ILogger<ExpenseController> _logger;

        /// <summary>
        /// Initializes a nex instance of the <see cref="ExpenseController"/> class.
        /// </summary>
        /// <param name="expensesService">The expense service</param>
        public ExpenseController(IExpenseService expensesService,
                                 ILogger<ExpenseController> logger)
        {
            _expensesService = expensesService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all the expenses
        /// </summary>
        /// <response code="200">The expense list is returned.</response>
        /// <returns>The expense list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDTO>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            _logger.LogInformation("ExpenseController.Get - Gets all the expenses");
            return Ok(_expensesService.GetAll());
        }

        /// <summary>
        /// Gets an expense.
        /// </summary>
        /// <param name="id">The expense's id</param>
        /// <response code="200">The expense is returned.</response>
        /// <response code="500">The expense was not found.</response>
        /// <returns>The expense</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ExpenseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [Route("{id}")]
        public IActionResult Get([Required] Guid id)
        {
            _logger.LogInformation($"ExpenseController.Get/{id} - Gets an expense");
            return Ok(_expensesService.GetById(id));
        }

        /// <summary>
        /// Create a new expense.
        /// </summary>
        /// <remarks>The category's, amount and description expense are required.</remarks>
        /// <param name="dto">The expense DTO</param>
        /// <returns>The new expense's id</returns>
        /// <response code="200">The creation is completed. The expense's id is returned.</response>
        /// <response code="422">The rules of expense are not valid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Create([Required] AddExpenseDTO dto)
        {
            _logger.LogInformation("ExpenseController.Create - Create a new expense");
            return Ok(await _expensesService.Create(dto));
        }
    }
}
