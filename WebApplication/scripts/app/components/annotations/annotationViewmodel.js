define(["knockout", "app/dataservice", "app/config"], function (ko, db, config) {
    return function (params) {

        var annotations = ko.observableArray();
        var prev = ko.observable();
        var next = ko.observable();
        var total = ko.observable();

        var callback = function(data) {
            annotations(data.data);
            prev(data.prev);
            next(data.next);
            total(data.totalAnnotationData);
        };

        var prevLink = function() {
            db.getAnnotations(prev(), callback);
        };
        var nextLink = function () {
            db.getAnnotations(next(), callback);
        };


        db.getAnnotations(callback);

        var deleteAnnotation = function (data) {
            db.deleteAnnotationByid(data.id);
            annotations.remove(data);
        };

       
        var addannotation = function(data) {
            db.addAnnotation(data);
            annotations.removeAll();
            db.getAnnotations(callback);
        };

        var clickAnnotation = function (data) {
            ns.postbox.notify(
            {
                component: config.annotationDetailComponent,
                params: { annotationUrl: data.url }
            }, config.changeComponentEVent);
        };

        return {
            annotations: annotations,
            deleteAnnotation: deleteAnnotation,
            addannotation: addannotation,
            clickAnnotation: clickAnnotation,
            prevLink: prevLink,
            nextLink: nextLink,
            total: total,
            prevValue: prev,
            nextValue: next
        };
    };
});

