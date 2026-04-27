using server.models;
using server.repositories;

namespace server.services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public IEnumerable<Category> getAllGiftCategories()
        {
            try
            {
                Console.WriteLine("aaa");
                return _categoryRepository.getAllCategories();
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Failed to get categories", ex);
                return null;
            }
        }
        public Category? getCategoryById(int id)
        {
            try
            {
                return _categoryRepository.getCategoryById(id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Failed to get categories", ex);
                return null;
            }
        }
        public Category? createCategory(Category category)
        {
            try
            {
                return _categoryRepository.createCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to add category {category.CategoryName}", ex);
                return null;
            }
        }
        public Category? updateCategory(Category category)
        {
            try
            {
                return _categoryRepository.updateCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to update category", ex);
                return null;
            }
        }
        public void deleteCategory(int id)
        {
            try
            {
                _categoryRepository.deleteCategory(id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Failed to dalete category", ex);
            }
        }
    }
}
