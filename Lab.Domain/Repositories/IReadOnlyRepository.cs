namespace Lab.Domain.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(object id);
    }
}
