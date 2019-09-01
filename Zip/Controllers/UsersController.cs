using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zip.Domain.Contracts;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;

namespace Zip.Controllers
{
    // TODO add exception filter attrib
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            try
            {
                var user = await _userService.Create(request);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserSummaryModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(nameof(id));

            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("{id}/account")]
        [ProducesResponseType(typeof(UserDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount(Guid id, CreateAccountRequest request)
        {
            try
            {
                var userDetails = await _userService.CreateAccount(id, request);
                return Ok(userDetails);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(Paged<UserSummaryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var pagedUsers = await _userService.GetAll(pageSize, pageNumber);
                return Ok(pagedUsers);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
