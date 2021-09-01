using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GalleryImage
    {
        [Key]
        public int GalleryImageId { get; set; }

        [StringLength(100)]
        public string GalleryImageName { get; set; }

        [StringLength(500)]
        public string GalleryImagePath { get; set; }
    }
}
