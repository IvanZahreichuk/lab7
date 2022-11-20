using Lab07.Problem_4._Telephony.Interfaces;

namespace Lab07.Problem_4._Telephony.Models;

public class Smartphone : ICallable, IBrowseable
{
    public string Calling(string number)
    {
        return number.Any(x => char.IsDigit(x)) 
            ? $"Calling... {number}" 
            : "Invalid number!";
    }

    public string Browsing(string url)
    {
        return url.Any(x => char.IsDigit(x)) 
            ? "Invalid URL!" 
            : $"Browsing: {url}!";
    }
}