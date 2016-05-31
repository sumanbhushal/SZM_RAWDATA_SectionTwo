define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var posts = ko.observableArray();
        var prevPosts = ko.observable();
        var nextPosts = ko.observable();
        var totalPosts = ko.observable();

        var callback = function (data) {
            posts(data.data);
            prevPosts(data.prev);
            nextPosts(data.next);
            totalPosts(data.total);
        };

        dataservice.getPosts(callback);


        var previousPostLink = function () {
            dataservice.getPosts(prevPosts(), callback);
        }
         var nextPostLink = function () {
            dataservice.getPosts(nextPosts(), callback);
        }

        return {
            posts: posts,
            //prevPosts: function () {
            //    dataservice.getPosts(prevPosts(), callback);
            //},
            //nextPosts: function () {
            //    dataservice.getPosts(nextPosts(), callback);
            //},

            previousPostLink: previousPostLink,
            nextPostLink: nextPostLink,
            total: totalPosts
        }

    }
});