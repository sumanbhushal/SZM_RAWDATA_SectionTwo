define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var postDetails = ko.observable();
        showAddAnotation = ko.observable(false);
        newAnnotation = ko.observable('');


        var postUrl = params.postUrl;
        dataservice.getPostDetails(postDetails, postUrl);



        return {
            receivedPostUrl: postUrl,
            postDetails: postDetails,
            showAddAnotation: showAddAnotation,
            newAnnotation: newAnnotation
        }
    }
});