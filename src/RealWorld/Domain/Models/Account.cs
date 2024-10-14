namespace Domain.Models;

public class Account : BaseEntity
{
    public string Number { get; set; }
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; }
}


public enum AccountStatus
{
    Opened,
    Locked,
    Closed
}