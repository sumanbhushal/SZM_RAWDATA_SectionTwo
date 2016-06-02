define([], function () {
    var server = 'http://localhost:54299';
    var menuElements = ["Home", "Annotations", "Search History", "Post Detials"];

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
        //postsComponent: menuElements[1].toLowerCase(),
        annotationComponent: menuElements[1].toLowerCase(),
        searchHistoryComponent: menuElements[2].toLowerCase(),
        postDetailsComponent: menuElements[3].toLowerCase(),


        //changeComponent
        changeComponentEVent: "changeComponentEvent"
    }
});