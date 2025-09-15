using Gigsy2.Core.Entities.Artist;
using System.ComponentModel.DataAnnotations;

namespace Gigsy2.Core.Entities.Shared
{

    public partial class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Label { get; set; } = string.Empty;

        public string? Slug { get; set; }
        public int SortOrder { get; set; }

    }
}