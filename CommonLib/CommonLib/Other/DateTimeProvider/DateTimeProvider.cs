namespace CommonLib.Other.DateTimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrent() => DateTime.Now;
    public DateTimeOffset GetCurrentOffset() => DateTimeOffset.UtcNow;
}