using Mentoring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentoring.Data.Configuration
{
	public class RegionConfiguration : IEntityTypeConfiguration<Region>
	{
		public void Configure(EntityTypeBuilder<Region> builder)
		{
			builder.HasKey(e => e.RegionId)
				.ForSqlServerIsClustered(false);

			builder.Property(e => e.RegionId)
				.HasColumnName("RegionID")
				.ValueGeneratedNever();

			builder.Property(e => e.RegionDescription)
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}
