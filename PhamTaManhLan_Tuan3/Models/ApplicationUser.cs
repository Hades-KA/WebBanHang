using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhamTaManhLan_Tuan3.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FullName { get; set; }

		public string? Address { get; set; }

		public int? Age { get; set; } // Sửa kiểu dữ liệu thành int?
	}
}
