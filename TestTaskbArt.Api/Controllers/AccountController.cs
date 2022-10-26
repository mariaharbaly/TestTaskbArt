using Microsoft.AspNetCore.Mvc;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(CreateAccountRequest createAccountRequest)
    {
        var account = await _accountService.CreateAccountAsync(createAccountRequest);
        return Ok(account);
    }

    [HttpGet("AllInfo")]
    [ProducesResponseType(typeof(IEnumerable<AccountResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllInfo()
    {
        var account = await _accountService.GetAccountAllInfoAsync();
        return Ok(account);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ContactResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> LinkToAccount(string accountName, string contactEmail)
    {
        await _accountService.LinkContact(accountName, contactEmail);
        return Ok();
    }
}