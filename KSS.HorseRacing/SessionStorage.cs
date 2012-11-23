namespace KSS.HorseRacing
{
    using System.Web;

    public class SessionStorage
    {
        public const string LOGIN_MESSAGE = "login-message";

        /// <summary>
        /// The add value with key.
        /// </summary>
        /// <param name="key">
        /// The key for parameter.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void AddValueWithKey(string key, string value)
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="key">
        /// The key for parameter.
        /// </param>
        /// <returns>
        /// The System.String.
        /// </returns>
        private string getValue(string key)
        {
            var value = string.Empty;
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null)
            {
                value = HttpContext.Current.Session[key].ToString();
            }

            return value;
        }

        /// <summary>
        /// The get value and clear after.
        /// </summary>
        /// <param name="key">
        /// The key for parameter.
        /// </param>
        /// <returns>
        /// The System.String.
        /// </returns>
        public string GetValueAndClearAfter(string key)
        {
            var value = getValue(key);
            clearValue(key);
            return value;
        }

        /// <summary>
        /// The clear value.
        /// </summary>
        /// <param name="key">
        /// The key for parameter.
        /// </param>
        private void clearValue(string key)
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Add(key, string.Empty);
            }
        }
    }
}