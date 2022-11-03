namespace Unisantos.TI.Core.Helpers;

public static class RandomHelpers
{
    public static string RandomString(int length)
    {
        var random = new Random();

        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        return new string(Enumerable.Repeat(chars, length).Select(c => c[random.Next(c.Length)]).ToArray());
    }
}