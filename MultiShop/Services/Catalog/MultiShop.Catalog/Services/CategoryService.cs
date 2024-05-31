using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            //MongoClient sınıfının bir örneği oluşturulur.
            //Bu, MongoDB sunucusuna bağlanmak için kullanılır ve
            //bağlantı dizesi _databaseSettings.ConnectionString parametresiyle sağlanır.
            var client = new MongoClient(_databaseSettings.ConnectionString);

            //GetDatabase yöntemi kullanılarak belirtilen adı
            //(_databaseSettings.DatabaseName) taşıyan bir veritabanı nesnesi elde edilir.
            var database = client.GetDatabase(_databaseSettings.DatabaseName);


            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCategoryDto> GetByIdCategoryDto(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
