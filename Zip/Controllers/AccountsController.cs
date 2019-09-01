using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zip.Domain.Contracts;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;

namespace Zip.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paged<AccountModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var pagedUsers = await _accountService.Get(pageSize, pageNumber);
                return Ok(pagedUsers);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
