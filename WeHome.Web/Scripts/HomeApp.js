var HomeApp = angular.module("HomeApp", [
    "ui.router"
]);

HomeApp.controller('HomeController', HomeController);
HomeApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

var configFunction = function($stateProvider, $httpProvider, $locationProvider, $urlRouterProvider) {
    $locationProvider.hashPrefix('!').html5Mode({ enabled: true });

    //$stateProvider.when("", "images");
    $urlRouterProvider.deferIntercept();
    $stateProvider
        .state('images', {
            url: '/single/images',
            views: {
                "Main": {
                    templateUrl: function(params) { return '/user/images'; }
                }
            }
        })
        .state('video', {
            url: '/single/video',
            views: {
                "Main": {
                    templateUrl: function(params) { return '/user/videos'; }
                }
            }
        })
        .state('stateThree', {
            url: '/stateThree?donuts',
            views: {
                "Main": {
                    templateUrl: function(params) { return '/Home/UserImages'; }
                }
            }
        })
        .state('space', {
            url: 'single/' + curUser + '/space',
            views: {
                "Main": {
                    templateUrl: function(params) { return '/admin/space'; }
                }
            }
        })
        .state('question', {
            url: 'single/question',
            views: {
                "Main": {
                    templateUrl: function(params) { return '/user/question'; }
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider', '$urlRouterProvider'];
HomeApp.config(configFunction);