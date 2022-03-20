using Domain.Commands.Account;
using Domain.Contracts.Handlers;
using Domain.Handlers.Base;
using Domain.ViewModels.Account;
using Shared.Commands;

namespace Domain.Handlers
{
    public class AccountHandler : BaseHandler, IAccountHandler
    {
        public AccountHandler()
        {

        }

        public async Task<ResultCommand<TokenViewModel>> LoginAsync(LoginCommand command)
        {
            ResultCommand<TokenViewModel> resultCommand = new(false, "Falta implementar o método!", null);

            await Task.Delay(1000);




            return resultCommand;
        }



    }
}
