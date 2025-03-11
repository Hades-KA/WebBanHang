using PhamTaManhLan_Tuan3.Models;

namespace PhamTaManhLan_Tuan3.Repositories
{
    public interface IProductRepository
    {
		Task<IEnumerable<Product>> GetAllAsync();  // Lấy danh sách sản phẩm
		Task<Product> GetByIdAsync(int id);  // Lấy sản phẩm theo ID
		Task AddAsync(Product product);  // Thêm sản phẩm
		Task UpdateAsync(Product product);  // Cập nhật sản phẩm
		Task DeleteAsync(int id);  // Xóa sản phẩm
	}
}
