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

        /// <summary>
        /// The set commit mode.
        /// </summary>
        /// <param name="isDeferred">
        /// The is deferred.
        /// </param>
        void SetCommitMode(bool isDeferred);

        /// <summary>
        /// The commit.
        /// </summary>
        void Commit();
    }
}