using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Service.Catalog.Models;
using FreeCourse.Service.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;

namespace FreeCourse.Service.Catalog.Services
{
    internal class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionStrings);
            IMongoDatabase dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            // var categories = await (await _categoryCollection.FindAsync(ct => true)).ToListAsync();
            var categories = await _categoryCollection.Find(ct => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(c => c.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}