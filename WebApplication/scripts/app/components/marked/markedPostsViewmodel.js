define(["knockout", "app/dataservice", "app/config"], function (ko, db,config) {
    return function(params) {
        var markedPosts = ko.observableArray();
        var prev = ko.observable();
        var next = ko.observable();
        var total = ko.observable();

        var callback = function (data) {
            markedPosts(data.data);
            prev(data.prev);
            next(data.next);
            total(data.total);
        };

        var prevLink = function () {
            db.getMarkedPosts(prev(), callback);
        };
        var nextLink = function () {
            db.getMarkedPosts(next(), callback);
        };

        db.getMarkedPosts(callback);

        var unmark = function(data) {
            db.unMark(data);
            markedPosts.remove(data);
        };

        var clickPost = function (data) {
            ns.postbox.notify(
            {
                component: config.postDetailsComponent,
                params: { postUrl: data.url }
            }, config.changeComponentEVent);
        };

        return {
            markedPosts: markedPosts,
            unmark: unmark,
            prevLink: prevLink,
            nextLink: nextLink,
            total: total,
            prevValue: prev,
            nextValue: next,
            clickPost: clickPost
        }
    }
});