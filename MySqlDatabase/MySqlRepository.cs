﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using MySql.Data.MySqlClient;

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
                    .Where(p => p.Title.Contains(keyword) || p.Body.Contains(keyword))
                    .ToList();
                return matchResult;

                //return db.Posts.Take(10).ToList();
            }
        }

        public IEnumerable<Post> GetPostDetailsByPostId(int id)
        {
            using (var database = new StackOverflowContext())
            {
                var postDetails = database.Posts
                    .Include("Users")
                    .Include("PostType")
                    .Where(p => p.Id == id)
                    .ToList();
                return postDetails;
            }
        }

        public IEnumerable<Post> GetAnswerPostByPostId(int id)
        {
            using (var database = new StackOverflowContext())
            {
                var answersByPostId = database.Posts
                    .Where(pa => pa.ParentId == id && pa.PostTypeId == 2)
                    .ToList();
                return answersByPostId;
            }
        }

        public IEnumerable<Post> GetAnswersByPostId(int postId, int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                var answersByPostId = db.Posts
                    .Where(pa => pa.ParentId == postId && pa.PostTypeId == 2)
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
                return answersByPostId;
            }
        }

        public int GetNumberOfAnswerByPostId(int postId)
        {
            using (var db = new StackOverflowContext())
            {
                var numberAnswersByPostId = db.Posts
                    .Where(pa => pa.ParentId == postId && pa.PostTypeId == 2)
                    .Count();
                return numberAnswersByPostId;
            }
        }

        public bool MarkPost(int id)
        {
            using (var database = new StackOverflowContext())
            {
                var postData = database.Posts.FirstOrDefault(p => p.Id == id);
                if (postData == null) return false;

                if(postData.Mark == 1)
                {
                    postData.Mark = 0;
                    database.SaveChanges();
                    return true;
                }else
                {
                    postData.Mark = 1;
                    database.SaveChanges();
                    return true;
                }
            }
        }

        /*----------------------
            Annotation
        ----------------------*/
        public IEnumerable<Annotation> GetAnnotions(int limit, int offset)
        {
            using (var database = new StackOverflowContext())
            {
                return database.Annotations.Include("Post")
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


        public IEnumerable<Annotation> FindAnnotationById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                return database.Annotations.Include("Post")
                    .Where(a => a.Id == id)
                    .ToList();
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
                    annotation.Post = database.Posts.FirstOrDefault(x => x.Id == annotation.PostId);
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
                var dbAnnotation = database.Annotations.FirstOrDefault(a => a.Id == annotation.Id);
                if (dbAnnotation == null) return false;

                try
                {
                    //database.Entry(annotation).State = EntityState.Modified;
                    dbAnnotation.PostId = annotation.PostId;
                    dbAnnotation.CommentId = annotation.CommentId;
                    dbAnnotation.AnnotationDescription = annotation.AnnotationDescription;
                    dbAnnotation.AnnotationCreateDate = annotation.AnnotationCreateDate;
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

        public IEnumerable<Comment> FindCommentById(int id)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Comments
                    .Where(c => c.Id == id)
                    .ToList();
            }
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId, int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                var commentsByPostId = db.Comments
                    .Where(ctp => ctp.PostId == postId)
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
                return commentsByPostId;
            }
        }

        public int GetNumberOfCommentsByPostId(int postId)
        {
            using (var db = new StackOverflowContext())
            {
                var numberCommentsByPostId = db.Comments
                    .Where(ctp => ctp.PostId == postId)
                    .Count();
                return numberCommentsByPostId;
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


        public IEnumerable<SearchHistory> FindSearchHistoryById(int id)
        {
            using (var database = new StackOverflowContext())
            {
                return database.SearchHisotries
                    .Where(sh => sh.Id == id)
                    .ToList();
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

        public IEnumerable<Tag> FindTagsByPostId(int postid)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Tags
                    .Where(lp => lp.PostId == postid)
                    .ToList();
            }
        }

        public IEnumerable<Tag> GetTagsByPostId(int postId, int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                var tagsByPostId = db.Tags
                    .Where(tg => tg.PostId == postId)
                    .OrderBy(p => p.PostId)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
                return tagsByPostId;
            }
        }

        public int GetNumberOfTagsByPostId(int postId)
        {
            using (var db = new StackOverflowContext())
            {
                var numberTagsByPostId = db.Tags
                    .Where(tg => tg.PostId == postId)
                    .Count();
                return numberTagsByPostId;
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

        public IEnumerable<User> FindUserDetailById(int id)
        {
            using (var db = new StackOverflowContext())
            {
                return db.Users
                    .Where(u => u.Id == id)
                    .ToList();
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

        public IEnumerable<PostType> FindPostTypeById(int id)
        {
            using (var db = new StackOverflowContext())
            {
                return db.PostTypes
                    .Where(pt => pt.Id == id)
                    .ToList();
            }
        }


        /**********************
                 LinkToPost
        ***********************/
        public IEnumerable<LinkPost> GetLinkToPost(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts
                    .OrderBy(lp => lp.PostId)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfLinkPosts()
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts.Count();
            }
        }

        public IEnumerable<LinkPost> FindLinkToPostByPostId(int postId)
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts
                    .Where(lp => lp.PostId == postId)
                    .ToList();
            }
        }

        /**********************
               Marked Post
       ***********************/
        public IEnumerable<Post> GetAllMakedPosts(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                var markedPosts = db.Posts
                    .Where(p => p.Mark == 1)
                    .OrderBy(mp => mp.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
                return markedPosts;
            }
        }

        public int GetNumberOfMarkedPosts()
        {
            using (var db = new StackOverflowContext())
            {
                return db.Posts
                    .Where(mp => mp.Mark == 1)
                    .Count();
            }
        }

        public bool UnMarkPost(int id)
        {
            using (var database = new StackOverflowContext())
            {
                var markedPost = database.Posts.FirstOrDefault(p => p.Id == id);
                if (markedPost == null) return false;

                try
                {
                    markedPost.Mark = 0;
                    database.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Search> GetAllPostsWithSearchKeyword(string keyword, int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {

                var p = new MySqlParameter("@p", MySqlDbType.String) { Value = keyword };
                var l = new MySqlParameter("@l", MySqlDbType.Int32) { Value = limit };
                var o = new MySqlParameter("@o", MySqlDbType.Int32) { Value = offset };
                var matchResult = db.Database.SqlQuery<Search>("call searchProcedure(@p, @l, @o)", p, l, o);
                var x = matchResult.ToList();
                return x;
            }
        }

        public int GetNumberOfSearchPosts(string keyword)
        {
            using (var db = new StackOverflowContext())
            {

                var p = new MySqlParameter("@p", MySqlDbType.VarChar) { Value = keyword };
                var matchResult = db.Database.SqlQuery<Search>("call searchTotalProcedure(@p)", p);
                var numberofSearchResutl = matchResult.Count();
                return numberofSearchResutl;
            }
        }
    }
}
