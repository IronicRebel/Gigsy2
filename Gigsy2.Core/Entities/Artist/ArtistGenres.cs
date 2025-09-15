using Gigsy2.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistGenres
    {
        [Key]
        public Guid ArtistGenreId { get; set; }

        [Required]
        public Guid ArtistProfileLuId { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        // Navigation
        public ArtistProfile ArtistProfile { get; set; } = default!;
        public Genre Genre { get; set; } = default!;

    }
}
