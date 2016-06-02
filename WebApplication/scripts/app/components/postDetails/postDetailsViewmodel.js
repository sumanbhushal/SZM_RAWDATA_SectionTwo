define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var postDetail = ko.observable();
        var showAddAnotation = ko.observable(false);
        var newAnnotation = ko.observable('');
        var comments = ko.observableArray();
        var answers = ko.observableArray();
        var annotationDescription = ko.observable();

        var postUrl = params.postUrl;
        var anserUrl = postUrl + "/answers";
        var commentUrl = postUrl + "/comments";

        dataservice.getPostDetails(postDetail, postUrl);

        var postId = postUrl.substr(postUrl.lastIndexOf('/') + 1);
        var addAnotation = function () {
            var annotationDescEntered = annotationDescription();

            var annoationDescToSave = {
                'postid': postId,
                'annotationdescription': annotationDescEntered
            };

            dataservice.addAnnotation(annoationDescToSave);
        };

        var answerCallback = function (data) {
            answers(data.data);
            console.log(data.data);
        };

        var commentCallback = function (data) {

            comments(data.data);
        };


        dataservice.getData(anserUrl, answerCallback);
        dataservice.getData(commentUrl, commentCallback);

        var markPosts = function () {
            dataservice.mark(postUrl);
        };

        return {
            receivedPostUrl: postUrl,
            details: postDetail,
            showAddAnotation: showAddAnotation,
            newAnnotation: newAnnotation,
            comments: comments,
            answers: answers,
            markPosts: markPosts,
            addAnotation: addAnotation,
            annotationDescription: annotationDescription
        }
    }
});