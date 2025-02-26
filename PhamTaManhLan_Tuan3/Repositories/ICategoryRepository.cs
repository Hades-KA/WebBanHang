using PhamTaManhLan_Tuan3.Models;

namespace PhamTaManhLan_Tuan3.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id); // Cho phép trả về null
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
