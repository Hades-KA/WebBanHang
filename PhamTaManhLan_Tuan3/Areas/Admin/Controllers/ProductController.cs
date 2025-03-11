﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Threading.Tasks;
using PhamTaManhLan_Tuan3.Models;
using PhamTaManhLan_Tuan3.Repositories;

namespace PhamTaManhLan_Tuan3.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productRepository.GetAllAsync();
			return View(products);
		}

		public async Task<IActionResult> Add()
		{
			ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(Product product, IFormFile imageUrl)
		{
			ModelState.Remove("ImageUrl");

			if (ModelState.IsValid)
			{
				if (imageUrl != null)
				{
					product.ImageUrl = await SaveImage(imageUrl);
				}

				await _productRepository.AddAsync(product);
				return RedirectToAction(nameof(Index));
			}

			ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name", product.CategoryId);
			return View(product);
		}

		public async Task<IActionResult> Update(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name", product.CategoryId);
			return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, Product product, IFormFile imageUrl)
		{
			ModelState.Remove("ImageUrl");

			if (id != product.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var existingProduct = await _productRepository.GetByIdAsync(id);
				if (existingProduct == null)
				{
					return NotFound();
				}

				if (imageUrl != null)
				{
					product.ImageUrl = await SaveImage(imageUrl);
				}
				else
				{
					product.ImageUrl = existingProduct.ImageUrl;
				}

				existingProduct.Name = product.Name;
				existingProduct.Price = product.Price;
				existingProduct.Description = product.Description;
				existingProduct.CategoryId = product.CategoryId;
				existingProduct.ImageUrl = product.ImageUrl;

				await _productRepository.UpdateAsync(existingProduct);
				return RedirectToAction(nameof(Index));
			}

			ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name", product.CategoryId);
			return View(product);
		}

		private async Task<string> SaveImage(IFormFile image)
		{
			var savePath = Path.Combine("wwwroot/images", image.FileName);
			using (var fileStream = new FileStream(savePath, FileMode.Create))
			{
				await image.CopyToAsync(fileStream);
			}
			return "/images/" + image.FileName;
		}

		public async Task<IActionResult> Delete(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			await _productRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Display(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}
	}
}
