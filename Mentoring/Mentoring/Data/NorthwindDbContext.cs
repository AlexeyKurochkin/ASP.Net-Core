using System.Reflection;
using Mentoring.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentoring.Data
{
	public class NorthwindDbContext : DbContext
	{
		public NorthwindDbContext()
		{
		}

		public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
		public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
		public virtual DbSet<OrderDetails> OrderDetails { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Region> Region { get; set; }
		public virtual DbSet<Shipper> Shippers { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<Territory> Territories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
