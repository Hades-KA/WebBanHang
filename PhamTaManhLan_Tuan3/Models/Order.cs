using System.ComponentModel.DataAnnotations;

namespace PhamTaManhLan_Tuan3.Models
{
	public class Order
	{
		[Key] // Đánh dấu Id là khóa chính
		public int Id { get; set; }

		public DateTime OrderDate { get; set; }
		public string CustomerName { get; set; }
		public decimal TotalAmount { get; set; }
	}

}
