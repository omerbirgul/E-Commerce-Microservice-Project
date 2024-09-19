using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos
{
    public class ResultCategorySlideDto
    {
        public string CategorySlideId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
