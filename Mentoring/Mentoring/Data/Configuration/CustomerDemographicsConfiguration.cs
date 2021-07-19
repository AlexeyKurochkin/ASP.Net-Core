using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentoring.Data.Configuration
{
	public class CustomerDemographicsConfiguration : IEntityTypeConfiguration<CustomerDemographics>
	{
		public void Configure(EntityTypeBuilder<CustomerDemographics> builder)
		{
			builder.HasKey(e => e.CustomerTypeId)
				.ForSqlServerIsClustered(false);

			builder.Property(e => e.CustomerTypeId)
				.HasColumnName("CustomerTypeID")
				.HasMaxLength(10)
				.ValueGeneratedNever();

			builder.Property(e => e.CustomerDesc).HasColumnType("ntext");
		}
	}
}
