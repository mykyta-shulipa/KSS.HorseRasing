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
                if (_userRepository == null)
                {
                    _userRepository = IoC.Resolve<IUserRepository>();
                    _userRepository.SetContext(_context);
                }

                return _userRepository;
            }
        }

        public IHorseRepository Horse
        {
            get
            {
                if (_horseRepository == null)
                {
                    _horseRepository = IoC.Resolve<IHorseRepository>();
                    _horseRepository.SetContext(_context);
                }

                return _horseRepository;
            }
        }

        public IJockeyRepository Jockey
        {
            get
            {
                if (_jockeyRepository == null)
                {
                    _jockeyRepository = IoC.Resolve<IJockeyRepository>();
                    _jockeyRepository.SetContext(_context);
                }

                return _jockeyRepository;
            }
        }

        public IRaceRepository Race
        {
            get
            {
                if (_raceRepository == null)
                {
                    _raceRepository = IoC.Resolve<IRaceRepository>();
                    _raceRepository.SetContext(_context);
                }

                return _raceRepository;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = IoC.Resolve<IRoleRepository>();
                    _roleRepository.SetContext(_context);
                }

                return _roleRepository;
            }
        }

        public IRacerRepository Racer
        {
            get
            {
                if (_racerRepository == null)
                {
                    _racerRepository = IoC.Resolve<IRacerRepository>();
                    _racerRepository.SetContext(_context);
                }

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
