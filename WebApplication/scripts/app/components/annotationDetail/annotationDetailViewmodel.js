define(["knockout", "app/dataservice","app/config"], function (ko, db,config) {
    return function (params) {
        var annotation = ko.observable();

        var annotationUrl = params.annotationUrl;
        db.getAnnotation(annotation, annotationUrl);

        var deleteAnnotation = function (data) {
            db.deleteAnnotationByid(data.id);
            ns.postbox.notify(
            {
                component: config.annotationComponent,
                params: { annotationUrl: data.url }
            }, config.changeComponentEVent);
        };

        var showEdit = ko.observable(true);
        var hiddenEdit = ko.observable(false);
        var toggleVisible = function () {
            showEdit(!showEdit());
            hiddenEdit(!hiddenEdit());
        };

        var updateannotation = function (data) {
            db.updateAnnotation(data);
            toggleVisible();
            annotation.removeAll();
            db.getAnnotation(annotation);
        };

        var clickPost = function (data) {
            var url = config.postUrl;
            var postUrl = url + "/" + data.postId;
            ns.postbox.notify(
            {
                component: config.postDetailsComponent,
                params: { postUrl: postUrl }
            }, config.changeComponentEVent);
        };

        var back = function (data) {
            ns.postbox.notify(
            {
                component: config.annotationComponent,
                params: { annotationUrl: data.url }
            }, config.changeComponentEVent);
        };

        return {
            annotation: annotation,
            deleteAnnotation: deleteAnnotation,
            showEdit: showEdit,
            hiddenEdit: hiddenEdit,
            toggleVisible: toggleVisible,
            updateannotation: updateannotation,
            back: back,
            clickPost:clickPost
        }
    };
});