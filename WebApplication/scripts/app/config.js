define([], function () {
    var server = 'http://localhost:54299';
    var menuElements = ["Home", "Posts", "Annotations", "Search History", "Post Detials"];

    return {
        //backend routes
        postUrl: server + "/api/posts",
        searchUrl: server + "/api/search?keyword=",
        searchhistoriesUrl: server + "/api/searchhistories",

        //menu
        menuElements: menuElements,
        defaultMenu: menuElements[0].toLowerCase(),

        //components 
        menuComponent: "menu",
        homeComponent: menuElements[0].toLowerCase(),
        postsComponent: menuElements[1].toLowerCase(),
        annotationComponent: menuElements[2].toLowerCase(),
        searchHistoryComponent: menuElements[3].toLowerCase(),
        postDetailsComponent: menuElements[4].toLowerCase(),


        //changeComponent
        changeComponentEVent: "changeComponentEvent"
    }
});