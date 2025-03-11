using System.ComponentModel.DataAnnotations;

namespace PhamTaManhLan_Tuan3.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[StringLength(100, ErrorMessage = "Tên sản phẩm không được quá 100 ký tự")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Giá sản phẩm không được để trống")]
		[Range(1, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Ảnh sản phẩm không được để trống")]
		public string ImageUrl { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public bool IsAvailable { get; set; }
	}
}
