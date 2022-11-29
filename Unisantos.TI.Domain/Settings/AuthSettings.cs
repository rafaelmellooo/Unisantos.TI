namespace Unisantos.TI.Domain.Settings;

public class AuthSettings
{
    public required string Secret { get; set; }
        
    public TimeSpan ExpiryTimeFrame { get; set; }
}