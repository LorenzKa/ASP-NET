public static class ExtensionMethods
{
    private static readonly long DatetimeMinTimeTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
    public static long ToJavaScriptMilliseconds(this DateTime dt)
    {
        var summerTimeEnd = new DateTime(dt.Year, 10, 30);
        while (summerTimeEnd.DayOfWeek != DayOfWeek.Sunday) summerTimeEnd = summerTimeEnd.AddDays(-1);
        var summerTimBegin = new DateTime(dt.Year, 3, 31);
        while (summerTimBegin.DayOfWeek != DayOfWeek.Sunday) summerTimBegin = summerTimBegin.AddDays(-1);

        int hours = dt > summerTimBegin && dt < summerTimeEnd ? 2 : 1;

        return (long)((dt.AddHours(-hours).Ticks - DatetimeMinTimeTicks) / 10000);
    }
}