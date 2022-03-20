using Domain.Commands.Account;
using Domain.ViewModels.Account;
using Shared.Commands;

namespace Domain.Contracts.Handlers
{
    public interface IAccountHandler
    {
        Task<ResultCommand<TokenViewModel>> LoginAsync(LoginCommand command);

    }
}
