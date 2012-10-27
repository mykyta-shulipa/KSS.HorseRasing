namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System;

    public class UnitOfWork : IDisposable
    {

        /// <summary>
        /// The database context.
        /// </summary>
        private readonly EfContext _context;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
