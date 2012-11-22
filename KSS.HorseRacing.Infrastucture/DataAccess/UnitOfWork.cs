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

        private IHorseRepository _horseRepository;

        private IJockeyRepository _jockeyRepository;

        private IRaceRepository _raceRepository;

        private IRoleRepository _roleRepository;

        private IRacerRepository _racerRepository;

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

        public IHorseRepository Horse
        {
            get
            {
                _horseRepository = IoC.Resolve<IHorseRepository>();
                _horseRepository.SetContext(_context);
                return _horseRepository;
            }
        }

        public IJockeyRepository Jockey
        {
            get
            {
                _jockeyRepository = IoC.Resolve<IJockeyRepository>();
                _jockeyRepository.SetContext(_context);
                return _jockeyRepository;
            }
        }

        public IRaceRepository Race
        {
            get
            {
                _raceRepository = IoC.Resolve<IRaceRepository>();
                _raceRepository.SetContext(_context);
                return _raceRepository;
            }
            set
            {
                _raceRepository = value;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                _roleRepository = IoC.Resolve<IRoleRepository>();
                _roleRepository.SetContext(_context);
                return _roleRepository;
            }
        }

        public IRacerRepository Racer
        {
            get
            {
                _racerRepository = IoC.Resolve<IRacerRepository>();
                _racerRepository.SetContext(_context);
                return _racerRepository;
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
