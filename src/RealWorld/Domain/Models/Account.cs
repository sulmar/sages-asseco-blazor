namespace Domain.Models;

public class Account : BaseEntity
{
    public required string Number { get; set; }
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; }

    public Account()
    {
        Status = AccountStatus.Opened;
    }
}

public enum AccountStatus
{
    Opened,
    Locked,
    Closed
}