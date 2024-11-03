namespace Lab.Domain.Repositories
{
    /// <summary>
    /// Interface genérica para ações de escrita na base de dados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriteOnlyRepository<T>
    {
        public Task<T> Create(T obj);
        public Task<T> Update(T obj);
    }
}
