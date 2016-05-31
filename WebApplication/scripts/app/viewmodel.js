define(['knockout', 'app/config'], function (ko, config) {
    return (function () {
        var currentComponent = ko.observable(config.defaultMenu);
        var currentParams = ko.observable();

        ns.postbox.subscribe(function (value) {
            currentParams(value.params);
            currentComponent(value.component);
        }, "changeComponentEvent");

        return {
            currentComponent: currentComponent,
            menuComponent: config.menuComponent,
            currentParams: currentParams
        }
    });
});