namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System;

    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;

    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly EfContext _context;

        private IUserRepository _userRepository;

        public UnitOfWork()
        {            
            _context = IoC.Resolve<EfContext>();
        }

        public IUserRepository User
        {
            get
            {
                _userRepository = IoC.Resolve<IUserRepository>();
                _userRepository.SetContext(_context);
                return _userRepository;
            }
        }

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
