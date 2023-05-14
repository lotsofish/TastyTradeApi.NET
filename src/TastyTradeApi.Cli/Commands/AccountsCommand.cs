namespace TastyTradeApi.Cli.Commands;

public class AccountsCommand : AuthenticatedCommandBase
{

    public AccountsCommand() : base("accounts", "Gets information regarding your accounts")
    {
        AddCommand(new AccountsListCommand());
        AddCommand(new AccountsStatusCommand());
    }
}
