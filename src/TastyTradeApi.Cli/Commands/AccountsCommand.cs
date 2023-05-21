namespace TastyTradeApi.Cli.Commands;

internal class AccountsCommand : AuthenticatedCommandBase
{
    internal AccountsCommand() : base("accounts", "Gets information regarding your accounts")
    {
        AddCommand(new AccountsListCommand());
        AddCommand(new AccountsStatusCommand());
        AddCommand(new AccountsPositionLimitCommand());
        AddCommand(new AccountsTotalFeesCommand());
    }
}
