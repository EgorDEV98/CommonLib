namespace CommonLib.Other.DateTimeProvider;

public interface IDateTimeProvider
{
    public DateTime GetCurrent();
    public DateTimeOffset GetCurrentOffset();
}