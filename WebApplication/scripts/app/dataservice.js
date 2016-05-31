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
        }
    }
});