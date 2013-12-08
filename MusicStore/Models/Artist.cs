using System.ComponentModel;
using System.Collections.Generic;

namespace MusicStore.Models
{
	public class Artist
	{
		public Artist()
		{
			Albums = new HashSet<Album>();
		}

		public int ArtistId { get; set; }

		[DisplayName("Artist")]
		public string Name { get; set; }

		public virtual ICollection<Album> Albums { get; set; }
	}
}
