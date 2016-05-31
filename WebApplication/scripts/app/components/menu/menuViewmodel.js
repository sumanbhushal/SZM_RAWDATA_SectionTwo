define(['knockout', 'app/config'], function(ko, config) {
    return function(params) {
        var currentComponent = params.currentComponent;

        var isMenuSelected = function(content) {
            return content && currentComponent() === content.toLowerCase();
        };

        var changeContent = function(content) {
            currentComponent(content.toLowerCase());
        };

        changeContent(config.defaultMenu);

        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent,
            changeContent: changeContent,
            isMenuSelected: isMenuSelected
        }
    };
});