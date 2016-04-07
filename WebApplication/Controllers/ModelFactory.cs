using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using AutoMapper;
using DomainModel;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class ModelFactory
    {
        private static readonly IMapper AnnotationMapper;
        private static readonly IMapper PostMapper;
        private static readonly IMapper CommentMapper;
        private static readonly IMapper SearchHistoryMapper;
        private static readonly IMapper UserMapper;


        static ModelFactory()
        {

            /*---------------------------------
                    Post
            ---------------------------------*/
            var postConfig = new MapperConfiguration(pcfg => pcfg.CreateMap<Post, PostModel>());
            PostMapper = postConfig.CreateMapper();

            /*---------------------------------
                    Comment
            ---------------------------------*/
            var commentConfig = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            // .ForMember(c => c.PostId, opt => opt.MapFrom(cm => cm.PostId)));
            CommentMapper = commentConfig.CreateMapper();

            /*--------------------------------
                    SearchHistory
            ---------------------------------*/
            var searchHisotyConfig = new MapperConfiguration(shcfg => shcfg.CreateMap<SearchHistory, SearchHistoryModel>());
            SearchHistoryMapper = searchHisotyConfig.CreateMapper();

            /*--------------------------------
                        Annotation 
            -----------------------------------*/

            var annotationConfig = new MapperConfiguration(acfg => acfg.CreateMap<Annotation, AnnotationModel>());
            AnnotationMapper = annotationConfig.CreateMapper();

            /*--------------------------
                    User
            ---------------------------*/
            var userConfig = new MapperConfiguration(ucfg => ucfg.CreateMap<User, UserModel>());
            UserMapper = userConfig.CreateMapper();
        }

        /*--------------------------------
                   Annotation 
       -----------------------------------*/

        public static AnnotationModel Map(Annotation annotation, UrlHelper urlHelper)
        {
            if (annotation == null) return null;

            var annotationModel = AnnotationMapper.Map<AnnotationModel>(annotation);
            annotationModel.Url = urlHelper.Link(Config.AnnotationRoute, new { annotation.Id });
            return annotationModel;

        }
        /*--------------------------------------
                    Post
        ---------------------------------------*/
        public static PostModel Map(Post post, UrlHelper urlHelper)
        {
            if (post == null) return null;

            var postModel = PostMapper.Map<PostModel>(post);
            postModel.Url = urlHelper.Link(Config.PostsRoute, new { post.Id });
            return postModel;
        }

        /*--------------------------------
                   Comment 
           --------------------------------*/
        public static CommentModel Map(Comment comment, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Config.CommentsRoute, new { comment.Id });
            return commentModel;
        }
        /*--------------------------------
                Search History 
        --------------------------------*/

        public static SearchHistoryModel Map(SearchHistory searchHistory, UrlHelper urlHelper)
        {
            if (searchHistory == null) return null;

            var searchHistoryModel = SearchHistoryMapper.Map<SearchHistoryModel>(searchHistory);
            searchHistoryModel.Url = urlHelper.Link(Config.SearchHistoriesRoute, new { searchHistory.Id });
            return searchHistoryModel;
        }

        /*----------------------------
                User
        -----------------------------*/

        public static UserModel Map(User user, UrlHelper urlHelper)
        {
            if (user == null) return null;

            var userModel = UserMapper.Map<UserModel>(user);
            userModel.Url = urlHelper.Link(Config.UsersRoute, new { user.Id });
            return userModel;
        }
    }
}