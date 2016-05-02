using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Utils
{
    public class Config
    {
        public const string PostsRoute = "PostsApi";
        public const string AnnotationRoute = "AnnotationsApi";
        public const string CommentsRoute = "CommentsApi";
        public const string SearchHistoriesRoute = "SearhHistoriesApi";
        public const string TagsRoute = "TagsApi";
        public const string UsersRoute = "UsersApi";
        public const string PostTypeRoute = "PostTypeApi";
        public const string LinkPostsRoute = "LinkPostsApi";

        public const int DefaultPageSize = 5;
    }
}