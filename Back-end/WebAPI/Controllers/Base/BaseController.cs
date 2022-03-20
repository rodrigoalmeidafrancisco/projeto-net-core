using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Commands;

namespace WebAPI.Controllers.Base
{
    public class BaseController : BaseTokenController
    {
        public BaseController()
        {

        }

        protected IActionResult ReturnResultAPI<T>(ResultCommand<T> command)
        {
            if (command.Success == false)
            {
                //Requisição não realizada com sucesso - 400 (Bad Request).
                return BadRequest(command);
            }

            //Requisição realizada com sucesso - 200 (Ok).
            return Ok(command);
        }

        protected IEnumerable<string> GetModelStateErrors(ModelStateDictionary modelState)
        {
            List<string> listResult = new();

            IEnumerable<ModelError> listaErros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in listaErros)
            {
                var mensagem = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                listResult.Add(mensagem);
            }

            return listResult;
        }

    }
}
