define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var searchHistories = ko.observableArray();
        var prevSearchHistories = ko.observable();
        var nextSearchHistories = ko.observable();
        var totalSearchHisotries = ko.observable();

        var callback = function (data) {
            searchHistories(data.data);
            prevSearchHistories(data.prev);
            nextSearchHistories(data.next);
            totalSearchHisotries(data.totalNumberOfSearhHisoty);
        };

        dataservice.getSearchHistories(callback);

        var onKeywordClick = function (data) {
            ns.postbox.notify(
              {
                  component: config.homeComponent,
                  params: { searchKey: data.keyword }
              }, config.changeComponentEVent);
        };

        var deleteSearchHistory = function (data) {
            if (confirm("Are you sure you want to delete!!!")) {
                dataservice.deleteDataById(data.url);
                searchHistories.remove(data);
            }

        };

        clearSearchData = function () {
            if (confirm("Are you sure you want to clear all search histories")) {
                dataservice.clearSeachHistory();
                dataservice.getSearchHistories(callback);
            }
        };

        var previousSearchHistoryLink = function () {
            dataservice.getData(prevSearchHistories(), callback);
        };

        var nextSearchHistoryLink = function () {
            dataservice.getData(nextSearchHistories(), callback);
        };


        return {
            searchHistories: searchHistories,
            previousSearchHistoryLink: previousSearchHistoryLink,
            nextSearchHistoryLink: nextSearchHistoryLink,
            total: totalSearchHisotries,
            deleteSearchHistory: deleteSearchHistory,
            onKeywordClick: onKeywordClick

        }
    }
});
