using Domain.Commands.Account;
using Domain.Contracts.Handlers;
using Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;
using Shared.Resources;
using Shared.Util;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("NetCorePolicy")]
    public class AccountController : BaseController
    {
        private readonly IAccountHandler _accountHandler;

        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
        }

        /// <summary>
        /// Realiza o login da aplicação Front-end
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">Retorno com sucesso.</response>
        /// <response code="400">Retorno sem sucesso.</response>  
        [AllowAnonymous]
        [HttpPost("v1/Login")]
        [ProducesResponseType(typeof(ResultCommand<TokenViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultCommand<dynamic>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            ResultCommand<TokenViewModel> resultCommand = new();

            if (ModelState.IsValid == false)
            {
                resultCommand.Message = ResourceResultAPI.InvalidParameters.Replace("{phrase}", "Não foi possível realizar o login")
                    .FormatHtmlMessage(GetModelStateErrors(ModelState));
            }
            else
            {
                resultCommand = await _accountHandler.LoginAsync(command);
            }

            return ReturnResultAPI(resultCommand);
        }



    }
}
