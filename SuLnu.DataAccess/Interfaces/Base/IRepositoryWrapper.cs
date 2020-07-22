namespace SuLnu.DataAccess.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IEducationRepository Education { get; }
        void Save();
    }
}
