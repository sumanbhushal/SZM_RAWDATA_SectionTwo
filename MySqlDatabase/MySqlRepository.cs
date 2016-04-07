using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;

namespace MySqlDatabase
{
    public class MySqlRepository: IRepository
    {
        public IEnumerable<Post> GetAllDataFromPostTable()
        {
            using (var allPostDataFromDB = new StackOverflowContext())
            {
                return allPostDataFromDB.Posts.ToList();
            } 
        }

        /**********************
                    PostType
        ***********************/

        public IEnumerable<PostType> GetPostType()
        {
            using (var postTypeData = new StackOverflowContext())
            {
                return postTypeData.PostTypes.ToList();
            }
        } 
    }
}
