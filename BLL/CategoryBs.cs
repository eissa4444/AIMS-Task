using DAL;

namespace BLL
{
    public class CategoryBs
    {
        private CategoryRepository categoryRepository;

        public CategoryBs()
        {
            categoryRepository = new CategoryRepository();
        }
    }
}
