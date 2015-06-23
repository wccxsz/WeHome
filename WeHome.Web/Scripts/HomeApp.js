var HomeApp = angular.model("HomeApp", [
    "ui.router"
]);

AwesomeAngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

var configFunction = function ($stateProvider, $httpProvider, $locationProvider) {
    $locationProvider.hashPrefix('!').html5Mode(true);
    $stateProvider
        .state('images', {
            url: '/user/images',
            views: {
                "Main": {
                    templateUrl: function (params) { return '/Home/UserImages'; }
                }
            }
        })
        .state('stateTwo', {
            url: '/stateTwo',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/one'
                }
            }
        })
        .state('stateThree', {
            url: '/stateThree?donuts',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/Home/UserImages'; }
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister?returnUrl',
            views: {
                "containerOne": {
                    templateUrl: '/Account/Login',
                    controller: LoginController
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];
HomeApp.config(configFunction);