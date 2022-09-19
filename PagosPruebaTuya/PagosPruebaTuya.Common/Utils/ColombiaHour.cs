namespace PagosPruebaTuya.Common.Utils
{
    public static class ColombiaHour
    {
        public static DateTime GetDate()
        {
            return DateTime.UtcNow.AddHours(-5);
        }
    }
}
