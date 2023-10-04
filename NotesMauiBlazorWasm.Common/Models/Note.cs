using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMauiBlazorWasm.Common.Models
{
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(75)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
    }
}
