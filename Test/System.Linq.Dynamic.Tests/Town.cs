using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Linq.Dynamic.Tests
{
    public class Town
	{
		public string Name { get; set; }
		public DbGeography Location { get; set; }
	}
}
