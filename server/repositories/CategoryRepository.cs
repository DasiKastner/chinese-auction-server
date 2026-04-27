using server.models;

namespace server.repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ChineseSaleDbContext _context;
        public CategoryRepository(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> getAllCategories()
        {
            Console.WriteLine("bbbb");
            return _context.Category.ToList();
        }
        public Category createCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }
        public Category? updateCategory(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
            return getCategoryById(category.Id);
        }
        public void deleteCategory(int id)
        {
            Category? category = getCategoryById(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }

        }
        public Category? getCategoryById(int id)
        {
            Category? category = _context.Category.FirstOrDefault(c => c.Id == id);
            return category;
        }
    }
}

