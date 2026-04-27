using server.models;

namespace server.services
{
    public interface ICategoryService
    {
        Category? createCategory(Category category);
        void deleteCategory(int id);
        IEnumerable<Category> getAllGiftCategories();
        Category? getCategoryById(int id);
        Category? updateCategory(Category category);
    }
}