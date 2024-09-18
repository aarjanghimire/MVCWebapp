namespace MVCWebapp.Repositories.GenericRepositories
{
    public interface IGenericRepositories
    {
        Task<List<T>> SelectAll<T>() where T : class;
        Task<T> SelectbyId<T>(int id) where T : class;
        Task UpdatebyId<T>(int id, T instance) where T : class;
        Task Create<T>(T instance) where T : class;
    }
}
