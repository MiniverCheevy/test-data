using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voodoo.Messages;

namespace Voodoo.TestData.Models
{
	public class Target
	{
		public string Name { get; set; }
		public string ParentName { get; set; }

		public List<string> Tags { get; set; }

		public List<INameValuePair> MetaData { get; set; }

		public object GeneratedValue { get; set; }
	}
}
