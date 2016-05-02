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
        IEnumerable<Post> GetPostDetailsByPostId(int id);
        IEnumerable<Post> GetAnswerPostByPostId(int id);

        /*----------------------
                Annotation
        ------------------------*/
        IEnumerable<Annotation> GetAnnotions(int limit, int offset);
        int GetNumberOfAllAnnotation();
        IEnumerable<Annotation> FindAnnotationById(int id);
        bool InsertNewAnnotation(Annotation annotation);
        bool UpdateAnnotation(Annotation annotation);
        bool DeleteAnnotationById(int id);


        /*-----------------------
                Comment
        -------------------------*/
        IEnumerable<Comment> GetComments(int limit, int offset);
        int GetNumberOfComments();
        IEnumerable<Comment> FindCommentById(int id);

        /*-------------------------
                SearchHistory
         -------------------------*/

        IEnumerable<SearchHistory> GetAllSearchHistory(int limit, int offset);
        int GetNumberofSearchHistory();
        IEnumerable<SearchHistory> FindSearchHistoryById(int id);
        bool InsertNewSearchHistory(SearchHistory searchHisotry);
        bool DeleteSearchHistoryById(int id);
        bool DeleteAllSearchHistories();

        /*---------------------
            Tags
            ---------*/
        IEnumerable<Tag> GetTags(int limit, int offset);
        int GetNumberOfTags();
        IEnumerable<Tag> FindTagsByPostId(int postid);

        /*----------------------
                 User
         ------------------------*/
        IEnumerable<User> GetAllUserData(int limit, int offset);
        int GetNumberOfUser();
        IEnumerable<User> FindUserDetailById(int id);

        /**********************
                     PostType
         ***********************/
        IEnumerable<PostType> GetPostType();
        IEnumerable<PostType> FindPostTypeById(int id);

        /**********************
               LinkToPost
        ***********************/
        IEnumerable<LinkPost> GetLinkToPost(int limit, int offset);
        int GetNumberOfLinkPosts();
        IEnumerable<LinkPost> FindLinkToPostByPostId(int postId);
    }
}
