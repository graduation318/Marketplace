using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface IUserProvider : IBaseProvider<User>
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
        public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}