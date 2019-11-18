using System.Collections.Generic;

namespace Player.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVm
    {
        public IList<CategoryDto> Categories { get; set; }

        public int Count { get; set; }
    }
}
