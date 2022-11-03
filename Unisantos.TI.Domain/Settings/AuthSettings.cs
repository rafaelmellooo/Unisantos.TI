namespace Unisantos.TI.Domain.Settings;

public class AuthSettings
{
    public string Secret { get; set; }
        
    public TimeSpan ExpiryTimeFrame { get; set; }
}