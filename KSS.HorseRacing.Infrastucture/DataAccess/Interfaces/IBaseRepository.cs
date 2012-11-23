namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    public interface IBaseRepository
    {
        /// <summary>
        /// The set context.
        /// </summary>
        /// <param name="context">
        /// The database context.
        /// </param>
        void SetContext(EfContext context);
    }
}