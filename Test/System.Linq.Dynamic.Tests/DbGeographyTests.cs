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
			var warsaw = new Town() {Name = "Warsaw", Location = DbGeography.FromText("POINT(52.14 21.1)")};
			var lodz = new Town() {Name = "Lodz", Location = DbGeography.FromText("POINT(51.47 19.28)")};
			var berlin = new Town() {Name = "Berlin", Location = DbGeography.FromText("POINT(52.31 13.23)")};
			var towns = new List<Town>
			            {
				            warsaw,
				            lodz,
				            berlin
			            }.AsQueryable();

			Assert.Equal(1, towns.Where("Location.Distance(@0) < 200000", warsaw.Location).Count());
		}
	}
}