using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;

namespace MySqlDatabase
{
    public class MySqlRepository: IRepository
    {
        /*----------------------
            Posts
        ----------------------*/

        public IEnumerable<Post> GetPosts(int limit, int offset)
        {
            using (var dbPost = new StackOverflowContext())
            {
                return dbPost.Posts
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();

            }
        }

        public int GetNumberOfPosts()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Posts.Count();
            }
        }

        public IEnumerable<Post> GetAllMatchPostsWithKeyword(string keyword)
        {
            using (var db = new StackOverflowContext())
            {
                var matchResult = db.Posts
                    .Where(p => p.Title.Contains(keyword))
                    .ToList();


                return matchResult;

                //return db.Posts.Take(10).ToList();
            }
        }

        /*----------------------
            Annotation
        ----------------------*/
        public IEnumerable<Annotation> GetAnnotions(int limit, int offset)
        {
            using (var database = new StackOverflowContext())
            {
                return database.Annotations
                    .OrderBy(a => a.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfAllAnnotation()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Annotations.Count();
            }
        }


        public Annotation FindAnnotationById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                return database.Annotations.FirstOrDefault(a => a.Id == id);
            }
            {

            }
        }

        public bool InsertNewAnnotation(Annotation annotation)
        {
            using (var database = new StackOverflowContext())
            {
                database.Annotations.Add(annotation);
                database.SaveChanges();
                return true;

            }
        }

        
        /*---------------------
                Comment
            ----------------------*/
        public IEnumerable<Comment> GetComments(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Comments
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();

            }
        }

        public int GetNumberOfComments()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Comments.Count();
            }
        }

        /*---------------------------------
                      Search History
            ------------------------------*/
        public IEnumerable<SearchHistory> GetAllSearchHistory(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.SearchHisotries
                    .OrderBy(sh => sh.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberofSearchHistory()
        {
            using (var db = new StackOverflowContext())
            {
                return db.SearchHisotries.Count();
            }
        }

        /*-----------------------
                Tags
        ------------------------*/
        public IEnumerable<Tag> GetTags(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Tags
                    .OrderBy(t => t.PostId)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfTags()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Tags.Count();
            }
        }
        /*-----------------------
                User
        -----------------------*/
        public IEnumerable<User> GetAllUserData(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Users
                    .OrderBy(u => u.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfUser()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Users.Count();
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
