using server.models;

namespace server.repositories
{
    public interface ICategoryRepository
    {
        Category createCategory(Category category);
        void deleteCategory(int id);
        IEnumerable<Category> getAllCategories();
        Category? getCategoryById(int id);
        Category? updateCategory(Category category);
    }
}