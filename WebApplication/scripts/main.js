var ns = ns || {};

ns.postbox = {
    subscribers: [],
    subscribe: function (callback, topic) {
        this.subscribers.push({ topic: topic, callback: callback });
    },
    notify: function (value, topic) {
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].topic === topic) {
                this.subscribers[i].callback(value);
            }
        }
    }
};


(function () {
    requirejs.config({
        baseUrl: 'scripts',
        paths: {
            knockout: 'lib/knockout-3.4.0',
            jquery: 'lib/jquery-2.2.3.min',
            text: 'lib/text',
            bootstrap: 'lib/bootstrap.min'
        },
        shim: {
            'bootstrap': {
                deps: ['jquery']
            }
        }
    });
})();

require(['knockout', 'app/viewmodel', 'app/config', 'jquery', 'bootstrap'], function (ko, vm, config, $, bstrap) {

    ko.components.register(config.menuComponent, {
        viewModel: { require: 'app/components/menu/menuViewmodel' },
        template: { require: 'text!app/components/menu/menu.html' }
    });

    ko.components.register(config.homeComponent, {
        viewModel: { require: 'app/components/home/homeViewmodel' },
        template: { require: 'text!app/components/home/home.html' }
    });

    //ko.components.register(config.postsComponent, {
    //    viewModel: { require: 'app/components/posts/postsViewmodel' },
    //    template: { require: 'text!app/components/posts/posts.html' }
    //});

    ko.components.register(config.searchHistoryComponent, {
        viewModel: { require: 'app/components/searchHistory/searchHistoryViewmodel' },
        template: { require: 'text!app/components/searchHistory/searchHistory.html' }
    });

    ko.components.register(config.postDetailsComponent, {
        viewModel: { require: 'app/components/postDetails/postDetailsViewmodel' },
        template: { require: 'text!app/components/postDetails/postDetails.html' }
    });

    ko.applyBindings(vm);
});