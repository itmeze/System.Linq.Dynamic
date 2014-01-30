using System.Collections.Generic;
using System.Data.Spatial;
using Xunit;

namespace System.Linq.Dynamic.Tests
{
	public class DbGeographyTests
	{
		[Fact]
		public void DistanceSearchShouldWork()
		{
			var warsaw = new Town() { Name = "Warsaw", Location = DbGeography.FromText("POINT(52.229718 21.012214)") };
			var lodz = new Town() { Name = "Lodz", Location = DbGeography.FromText("POINT(51.759304 19.455969)") };
			var berlin = new Town() { Name = "Berlin", Location = DbGeography.FromText("POINT(52.523206 13.410836)") };
			var towns = new List<Town>
			            {
				            warsaw,
				            lodz,
				            berlin
			            }.AsQueryable();

			var distance = warsaw.Location.Distance(lodz.Location);

			Assert.Equal(1, towns.Where("Location.Distance(@0) < 20000", warsaw.Location).Count());
			Assert.Equal(2, towns.Where("Location.Distance(@0) < 200000", warsaw.Location).Count());
			Assert.Equal(3, towns.Where("Location.Distance(@0) < 2000000", warsaw.Location).Count());
		}
	}
}