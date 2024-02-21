using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MediaFile
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileType { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
