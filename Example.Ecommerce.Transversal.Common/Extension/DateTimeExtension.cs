namespace Example.Ecommerce.Transversal.Common.Extension
{
    public static class DateTimeExtension
    {
        public static DateTime DateTimeZoneInfo(this DateTime datetime)
        {
            if (datetime.Hour is 0 && datetime.Minute is 0 && datetime.Second is 0)
                datetime = datetime.Date + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            string timeZone = "SA Pacific Standard Time";
            if (!TimeZoneInfo.Local.Id.Equals(timeZone)) timeZone = "America/Bogota";

            return TimeZoneInfo.ConvertTime(datetime, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }
    }
}