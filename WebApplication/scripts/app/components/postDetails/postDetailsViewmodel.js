define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var postDetail = ko.observable();
        var showAddAnotation = ko.observable(false);
        var newAnnotation = ko.observable('');
        var comments = ko.observableArray();
        var answers = ko.observableArray();

        var postUrl = params.postUrl;
        var anserUrl = postUrl + "/answers";
        var commentUrl = postUrl + "/comments";

        dataservice.getPostDetails(postDetail, postUrl);

        //var postId = postUrl.substr(postUrl.lastIndexOf('/') + 1);

        var answerCallback = function (data) {
            answers(data.data);
            console.log(data.data);
        };

        var commentCallback = function (data) {

            comments(data.data);
        };


        dataservice.getData(anserUrl, answerCallback);
        dataservice.getData(commentUrl, commentCallback);


        return {
            receivedPostUrl: postUrl,
            details: postDetail,
            showAddAnotation: showAddAnotation,
            newAnnotation: newAnnotation,
            comments: comments,
            answers: answers
        }
    }
});