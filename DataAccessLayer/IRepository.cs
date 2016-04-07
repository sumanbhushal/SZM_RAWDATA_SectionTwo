using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository
    {
        IEnumerable<Post> GetAllDataFromPostTable();

        /**********************
                    PostType
        ***********************/
        IEnumerable<PostType> GetPostType();
    }
}
