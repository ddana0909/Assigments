using System;
using System.Collections.Generic;

namespace MusicStore.Models
{
	public class DisplayOption
	{
		public string PageSize { get; set; }
		public string NameToSearch { get; set; }
		public string SortField { get; set; }
		public string SortOrder { get; set; }
		public int? Page { get; set; }

		public int CurrentSize { get; private set; }
		public int GetPageNumber { get { return Page ?? 1; } }
		public IEnumerable<string> SizeList { get { return new List<string> {"All", "10", "5", "3"}; }}

		public void Init()
		{
			if (NameToSearch != null)
			{
				Page = 1;
			}

			if (String.Compare(PageSize, "all", StringComparison.OrdinalIgnoreCase) == 0 || PageSize == null)
			{
				CurrentSize = 100;
			}
			else
			{
				CurrentSize = Convert.ToInt32(PageSize);
			}
		}

		public void UpdateSortOrder()
		{
			SortOrder = SortOrder == "asc" ? "desc" : "asc";
		}
	}
}