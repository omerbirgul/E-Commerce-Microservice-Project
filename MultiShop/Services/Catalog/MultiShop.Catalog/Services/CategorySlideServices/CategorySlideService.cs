using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategorySlideDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategorySlideServices
{
    public class CategorySlideService : ICategorySlideService
    {
        private readonly IMongoCollection<CategorySlide> _categorySlideCollection;
        private readonly IMapper _mapper;

        public CategorySlideService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categorySlideCollection = database.GetCollection<CategorySlide>(_databaseSettings.CategorySlideCollectionName);
            _mapper = mapper;
        }

        public Task CategorySlideStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task CategorySlideStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateCategorySlideAsync(CreateCategorySlideDto createCategorySlideDto)
        {
            var values = _mapper.Map<CategorySlide>(createCategorySlideDto);
            await _categorySlideCollection.InsertOneAsync(values);

        }

        public async Task DeleteCategorySlideAsync(string id)
        {
            await _categorySlideCollection.DeleteOneAsync(x => x.CategorySlideId == id);
        }

        public async Task<List<ResultCategorySlideDto>> GetAllCategorySlideAsync()
        {
            var values = await _categorySlideCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategorySlideDto>>(values);
        }

        public async Task<GetByIdCategorySlideDto> GetByIdCategorySlideAsync(string id)
        {
            var values = await _categorySlideCollection.Find<CategorySlide>(x => x.CategorySlideId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategorySlideDto>(values);
        }

        public async Task UpdateCategorySlideAsync(UpdateCategorySlideDto updateCategorySlideDto)
        {
            var values = _mapper.Map<CategorySlide>(updateCategorySlideDto);
            await _categorySlideCollection.FindOneAndReplaceAsync(x => x.CategorySlideId == updateCategorySlideDto.CategorySlideId, values);
        }
    }
}
