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
        /*----------------------
               Posts
       ------------------------*/
        IEnumerable<Post> GetPosts(int limit, int offset);
        int GetNumberOfPosts();
        IEnumerable<Post> GetAllMatchPostsWithKeyword(string keyword);

        /*----------------------
                Annotation
        ------------------------*/
        IEnumerable<Annotation> GetAnnotions(int limit, int offset);
        int GetNumberOfAllAnnotation();
        Annotation FindAnnotationById(int id);
        bool InsertNewAnnotation(Annotation annotation);
        bool UpdateAnnotation(Annotation annotation);
        bool DeleteAnnotationById(int id);


        /*-----------------------
                Comment
        -------------------------*/
        IEnumerable<Comment> GetComments(int limit, int offset);
        int GetNumberOfComments();

        /*-------------------------
                SearchHistory
         -------------------------*/

        IEnumerable<SearchHistory> GetAllSearchHistory(int limit, int offset);
        int GetNumberofSearchHistory();
        SearchHistory FindSearchHistoryById(int id);
        bool InsertNewSearchHistory(SearchHistory searchHisotry);
        bool DeleteSearchHistoryById(int id);
        bool DeleteAllSearchHistories();

        /*---------------------
            Tags
            ---------*/
        IEnumerable<Tag> GetTags(int limit, int offset);
        int GetNumberOfTags();

        /*----------------------
                 User
         ------------------------*/
        IEnumerable<User> GetAllUserData(int limit, int offset);
        int GetNumberOfUser();

        /**********************
                     PostType
         ***********************/
        IEnumerable<PostType> GetPostType();

    }
}
