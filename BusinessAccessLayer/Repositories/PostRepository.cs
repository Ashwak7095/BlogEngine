using DataAccessLayer;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly BlogDBContext _dbContext;

        public PostRepository(BlogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PostModel>> GetPost()
        {
            try
            {
                var query = "select * from PostModel";
                return await _dbContext.PostModels.FromSqlRaw<PostModel>(query).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public PostModel GetPostById(int Id)
        {
            try
            {
                return _dbContext.PostModels.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<PostModel> Post(PostModel postmodel)
        {

            try
            {
                PostModel postModel = new PostModel()
                {
                    Id = postmodel.Id,
                    Title = postmodel.Title,
                    Description = postmodel.Description,
                    PublishDate = postmodel.PublishDate
                };
                await _dbContext.PostModels.AddAsync(postModel);
                await _dbContext.SaveChangesAsync();
                return postModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
    
        }
        public PostModel Update(PostModel postmodel)
        {
            try
            {
                _dbContext.PostModels.Update(postmodel);
                _dbContext.SaveChanges();
                return postmodel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void DeleteById(int Id)
        {
            var getPostDetailsById = GetPostById(Id);
            _dbContext.PostModels.Remove(getPostDetailsById);
            _dbContext.SaveChanges();
        }

       
    }
        
}
