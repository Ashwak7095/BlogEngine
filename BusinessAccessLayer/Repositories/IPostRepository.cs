using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Repositories
{
    public interface IPostRepository
    {
        Task<List<PostModel>> GetPost();
        PostModel GetPostById(int Id);
        Task<PostModel> Post(PostModel postmodel);
        PostModel Update(PostModel postmodel);
        void DeleteById(int Id);
    }
}

