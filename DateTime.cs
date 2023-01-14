namespace CommonExtensions
{
    class DateTime
    {
        //TODO
        public static DateTimeOffset ParseDateExactForTimeZone(string dateTime, TimeZoneInfo timezone)
        {
            var parsedDateLocal = DateTimeOffset.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            var tzOffset = timezone.GetUtcOffset(parsedDateLocal.DateTime);
            var parsedDateTimeZone = new DateTimeOffset(parsedDateLocal.DateTime, tzOffset);
            return parsedDateTimeZone;
        }
    }
}