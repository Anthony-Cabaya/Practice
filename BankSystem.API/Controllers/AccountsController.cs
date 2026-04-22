using BankSystem.DTOs;
using BankSystem.Entities;
using BankSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IBankAccountService _service;

        public AccountsController(IBankAccountService service)
        {
            _service = service;
        }

        [HttpPost("{id}/deposit")]
        public IActionResult Deposit(int id, [FromBody] TransactionDto dto)
        {
            var result = _service.Deposit(id, dto.Amount);

            return HandleResult(result);
        }

        [HttpPost("{id}/withdraw")]
        public IActionResult Withdraw(int id, [FromBody] TransactionDto dto)
        {
            var result = _service.Withdraw(id, dto.Amount);

            return HandleResult(result);
        }

        [HttpGet("{id}/balance")]
        public IActionResult ViewBalance(int id)
        {
            var result = _service.ViewBalance(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] CreateAccountDto dto)
        {
            var created = _service.CreateAccount(dto.Name, dto.AccountType);
            return Ok(created);
        }

        private IActionResult HandleResult(ServiceResult result)
        {
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
