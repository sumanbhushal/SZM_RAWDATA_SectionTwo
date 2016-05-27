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
        private static readonly IMapper LinkPostMapper;
        private static readonly IMapper PostTypeMapper;
        private static readonly IMapper PostTagsMapper;
        private static readonly IMapper SearchMapper;


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
            var searchHisotyConfig =
                new MapperConfiguration(shcfg => shcfg.CreateMap<SearchHistory, SearchHistoryModel>());
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

            /*--------------------------
                    Link Post 
            ---------------------------*/
            var linkPostConfig = new MapperConfiguration(lpcfg => lpcfg.CreateMap<LinkPost, LinkPostModel>());
            LinkPostMapper = linkPostConfig.CreateMapper();

            /*--------------------------
                    Post Type
            ---------------------------*/
            var postTypeConfig = new MapperConfiguration(ptcfg => ptcfg.CreateMap<PostType, PostTypeModel>());
            PostTypeMapper = postTypeConfig.CreateMapper();

            /*--------------------------
                  Post Tags
           ---------------------------*/
            var postTagsConfig = new MapperConfiguration(tcfg => tcfg.CreateMap<Tag, TagModel>());
            PostTagsMapper = postTagsConfig.CreateMapper();

            /*--------------------------
                   Search
            ---------------------------*/
            var searchConfig = new MapperConfiguration(scfg => scfg.CreateMap<Search, SearchModel>());
            SearchMapper = searchConfig.CreateMapper();
        }

        /*--------------------------------
                   Annotation 
       -----------------------------------*/

        public static AnnotationModel Map(Annotation annotation, UrlHelper urlHelper)
        {
            if (annotation == null) return null;

            var annotationModel = AnnotationMapper.Map<AnnotationModel>(annotation);
            annotationModel.Url = urlHelper.Link(Config.AnnotationRoute, new { id = annotation.Id });
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

        /*----------------------------
               LinkPost
       -----------------------------*/

        public static LinkPostModel Map(LinkPost linkpost, UrlHelper urlHelper)
        {
            if (linkpost == null) return null;

            var linkPostModel = LinkPostMapper.Map<LinkPostModel>(linkpost);
            linkPostModel.PostUrl = urlHelper.Link(Config.LinkPostsRoute, new { linkpost.PostId });
            return linkPostModel;
        }

        /*----------------------------
               Post Type
       -----------------------------*/

        public static PostTypeModel Map(PostType postType, UrlHelper urlHelper)
        {
            if (postType == null) return null;

            var postTypeModel = PostTypeMapper.Map<PostTypeModel>(postType);
            postTypeModel.Url = urlHelper.Link(Config.PostTypeRoute, new { postType.Id });
            return postTypeModel;
        }

        /*----------------------------
               Post Tags
       -----------------------------*/

        public static TagModel Map(Tag tags, UrlHelper urlHelper)
        {
            if (tags == null) return null;

            var tagModel = PostTagsMapper.Map<TagModel>(tags);
            tagModel.PostUrl = urlHelper.Link(Config.TagsRoute, new { tags.PostId });
            return tagModel;
        }

        /*----------------------------
               Search
       -----------------------------*/

        public static SearchModel Map(Search search, UrlHelper urlHelper)
        {
            if (search == null) return null;

            var searchModel = SearchMapper.Map<SearchModel>(search);
            searchModel.Url = urlHelper.Link(Config.PostsRoute, new { search.Id });
            return searchModel;
        }
    }
}