using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using WebApplication.Utils;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: Config.PostsRoute,
                routeTemplate: "api/posts/{id}",
                defaults: new {controller = "Posts",  id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.AnnotationRoute,
                routeTemplate: "api/annotations/{id}",
                defaults: new { controller = "Annotations", id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
               name: Config.CommentsRoute,
               routeTemplate: "api/comments/{id}",
               defaults: new { controller = "Comments", id = RouteParameter.Optional }
               );

            config.Routes.MapHttpRoute(
               name: Config.SearchHistoriesRoute,
               routeTemplate: "api/searchhistories/{id}",
               defaults: new { controller = "SearchHistories", id = RouteParameter.Optional }
               );

            config.Routes.MapHttpRoute(
               name: Config.TagsRoute,
               routeTemplate: "api/tags/{id}",
               defaults: new { controller = "Tags", id = RouteParameter.Optional }
               );

            config.Routes.MapHttpRoute(
               name: Config.UsersRoute,
               routeTemplate: "api/users/{id}",
               defaults: new { controller = "Users", id = RouteParameter.Optional }
               );

            config.Routes.MapHttpRoute(
                name: Config.PostTypeRoute,
                routeTemplate: "api/posttype/{id}",
                defaults: new { controller = "PostTypes", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.LinkPostsRoute,
                routeTemplate: "api/linkposts/{id}",
                defaults: new { controller = "LinkPosts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.MarkedPostsRoute,
                routeTemplate: "api/markedposts/{id}",
                defaults: new { controller = "MarkedPosts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchPostsRoute,
                routeTemplate: "api/search/{id}",
                defaults: new { controller = "Search", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsCommentsRoute,
                routeTemplate: "api/posts/{postId}/comments",
                defaults: new { controller = "PostsComments", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsAnswersRoute,
                routeTemplate: "api/posts/{postId}/answers",
                defaults: new { controller = "PostsAnswers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsTagsRoute,
                routeTemplate: "api/posts/{postId}/tags",
                defaults: new { controller = "PostsTags", id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = 
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
