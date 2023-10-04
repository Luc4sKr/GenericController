namespace GenericController.Appliction.API.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        List<T> GetAll();
        Task<T> GetById(Guid id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
