define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {

        var searchResult = ko.observableArray();
        var searchword = ko.observable();
        var prevSearchResults = ko.observable();
        var nextNextSearchResults = ko.observable();
        var totalSearchResults = ko.observable();
        //var postDetailsByUrl = ko.observable();

        var callback = function (data) {
            searchResult(data.data);
            prevSearchResults(data.prev);
            nextNextSearchResults(data.next);
            totalSearchResults(data.total);
        };

        //var searchwordRecieved = "";
        if (params) {
            var searchwordRecieved = params.searchKey;
            //searchword = params.searchKey;
            dataservice.searchResults(callback, searchwordRecieved);
        }


        var searchPosts = function () {
            var enteredkeyword = searchword();

            var keywordToSave = {
                'keyword': enteredkeyword
            }

            dataservice.postSearchKeywordToServer(keywordToSave);
            //console.log(enteredkeyword);
            dataservice.searchResults(callback, enteredkeyword);
        };

        var previousSearchRusultLink = function () {
            dataservice.getData(prevSearchResults(), callback);
        };

        var nextSearchResultLink = function () {
            dataservice.getData(nextNextSearchResults(), callback);
        };
        //dataservice.searchResults(function (data) {
        //    searchResult(data);
        //}, enteredkeyword);

        //getPostDeatilsByUrl = function(url) {
        //    dataservice.getData(url);
        //}

        var onPostClick = function (data) {
            ns.postbox.notify(
            {
                component: config.postDetailsComponent,
                params: { postUrl: data.url }
            }, config.changeComponentEVent);
        }


        return {
            searchResult: searchResult,
            searchword: searchword,
            searchPosts: searchPosts,
            previousSearchRusultLink: previousSearchRusultLink,
            nextSearchResultLink: nextSearchResultLink,
            total: totalSearchResults,
            onPostClick: onPostClick
            //postDetailsByUrl: getPostDeatilsByUrl
        }
    }
});