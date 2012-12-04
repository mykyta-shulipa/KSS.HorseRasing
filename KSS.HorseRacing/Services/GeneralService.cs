namespace KSS.HorseRacing.Services
{
    using System;

    public class GeneralService
    {
        public string GetDateTimeStringForDatepicker(DateTime dateTime)
        {
            return dateTime.ToShortDateString().Replace('/', '-');
        }
    }
}