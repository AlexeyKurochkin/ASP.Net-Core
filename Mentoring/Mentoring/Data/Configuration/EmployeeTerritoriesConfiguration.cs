using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentoring.Data.Configuration
{
	public class EmployeeTerritoriesConfiguration : IEntityTypeConfiguration<EmployeeTerritories>
	{
		public void Configure(EntityTypeBuilder<EmployeeTerritories> builder)
		{
			builder.HasKey(e => new { e.EmployeeId, e.TerritoryId })
				.ForSqlServerIsClustered(false);

			builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

			builder.Property(e => e.TerritoryId)
				.HasColumnName("TerritoryID")
				.HasMaxLength(20);

			builder.HasOne(d => d.Employee)
				.WithMany(p => p.EmployeeTerritories)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeTerritories_Employees");

			builder.HasOne(d => d.Territory)
				.WithMany(p => p.EmployeeTerritories)
				.HasForeignKey(d => d.TerritoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeTerritories_Territories");
		}
	}
}
