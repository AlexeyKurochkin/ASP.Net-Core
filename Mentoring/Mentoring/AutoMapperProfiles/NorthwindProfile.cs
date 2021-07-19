using AutoMapper;
using Mentoring.Models;
using Mentoring.ViewModels;

namespace Mentoring.AutoMapperProfiles
{
	public class NorthwindProfile : Profile
	{
		public NorthwindProfile()
		{
			CreateMap<Category, CategoryViewModel>();
			CreateMap<Product, CreateEditProductViewModel>()
				.ForMember(m => m.Supplier, opt => opt.Ignore())
				.ForMember(m => m.Category, opt => opt.Ignore());
			CreateMap<Product, ProductsViewModel>()
				.ForMember(m => m.Supplier, opt => opt.MapFrom(s => s.Supplier.CompanyName))
				.ForMember(m => m.Category, opt => opt.MapFrom(s => s.Category.CategoryName));
		}
	}
}
