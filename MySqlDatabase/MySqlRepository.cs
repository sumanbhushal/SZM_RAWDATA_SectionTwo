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
        }

        public bool InsertNewAnnotation(Annotation annotation)
        {
            using (var database = new StackOverflowContext())
            {
                try
                {
                    database.Annotations.Add(annotation);
                    database.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateAnnotation(Annotation annotation)
        {
            using (var database = new StackOverflowContext())
            {
                try
                {
                    database.Entry(annotation).State = EntityState.Modified;
                    database.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteAnnotationById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                Annotation annotation = database.Annotations.Find(id);
                if (annotation != null)
                {
                    try
                    {
                        database.Annotations.Remove(annotation);
                        database.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return false;
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


        public SearchHistory FindSearchHistoryById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                return database.SearchHisotries.FirstOrDefault(sh => sh.Id == id);
            }
        }

        public bool InsertNewSearchHistory(SearchHistory searchHisotry)
        {
            using (var database = new StackOverflowContext())
            {
                try
                {
                    database.SearchHisotries.Add(searchHisotry);
                    database.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteSearchHistoryById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                SearchHistory searchHistory = database.SearchHisotries.Find(id);
                if (searchHistory != null)
                {
                    try
                    {
                        database.SearchHisotries.Remove(searchHistory);
                        database.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
                return false;
            }
        }

        public bool DeleteAllSearchHistories()
        {

            using (var database = new StackOverflowContext())
            {
                try
                {
                    database.Database.ExecuteSqlCommand("TRUNCATE TABLE searchhistory");
                    database.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

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
