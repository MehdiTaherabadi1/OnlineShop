using OnlineShop.Application.Contracts;

namespace OnlineShop.Application.Helpers;

public class Guard
{
    public static void CheckValidOrderPlacementPeriod(int from, int to)
    {
        var currentTime = DateTime.Now.TimeOfDay;
        if (currentTime < TimeSpan.FromHours(from) || currentTime > TimeSpan.FromHours(to))
        {
            throw new Exception(PersianLexicon.Error_UnValidOrdeRplacementPeriod);
        }
    }
}
