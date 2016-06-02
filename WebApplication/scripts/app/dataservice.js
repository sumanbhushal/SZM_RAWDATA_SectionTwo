define(['jquery', 'app/config', 'knockout'], function ($, config, ko) {
    return {
        getPosts: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = config.postUrl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        postSearchKeywordToServer: function (searchwordToSave) {
            var url = config.searchhistoriesUrl;
            var data = ko.toJS(searchwordToSave);
            //$.post(url, data);
            $.ajax({
                type: 'POST',
                url: url,
                dataType: 'json',
                data: data
            });
        },

        searchResults: function (url, searchword, callback) {

            if (callback == undefined) {
                callback = url;
                url = config.searchUrl + searchword;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        getData: function (url, callback) {

            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        getPostDetails: function (url, postUrl, callback) {

            if (callback == undefined) {
                callback = url;
                url = postUrl;
                //url = config.postUrl + "/" + postid;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        //Search Histories
        getSearchHistories: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = config.searchhistoriesUrl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        deleteDataById: function (url) {
            $.ajax({
                type: 'DELETE',
                url: url
            });
        },

        clearSeachHistory: function () {
            var url = config.searchhistoriesUrl;
            $.ajax({
                type: 'DELETE',
                url: url
            });
        },

        //add Annotation
        addAnnotation: function (annoDesc) {
            var url = config.annotationurl;
            var data = ko.toJS(annoDesc);
            $.ajax({
                url: url,
                type: "Post",
                data: data
            });
        },

        //get Anntations
        getAnnotations: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = config.annotationurl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        //get Annotation
        getAnnotation: function (url, annotationUrl, callback) {
            if (callback == undefined) {
                callback = url;
                url = annotationUrl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },

        //delete Annotation
        deleteAnnotationByid: function (id) {
            var url = config.annotationurl;
            $.ajax({
                url: url + "/" + id,
                type: "Delete"
            });
        },

        //update Annotation
        updateAnnotation: function (data) {
            var url = config.annotationurl;
            $.ajax({
                url: url + "/" + data.id,
                type: "Put",
                data: data
            });
        },

        //update post for unmark
        mark: function (postUrl) {
            var url = postUrl;
            $.ajax({
                url: url,
                type: "Put"
            });
        },

        //update post for unmark
        unMark: function (data) {
            var url = data.url;
            $.ajax({
                url: url,
                type: "Put",
                data: data
        });
        },

        //get marked posts
        getMarkedPosts: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = config.markedpostsurl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        }

    }
});