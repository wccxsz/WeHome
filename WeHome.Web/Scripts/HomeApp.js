var HomeApp = angular.model("HomeApp", [
    "ui.router"
]);

HomeApp.controller('LoginController', LoginController);

HomeApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/Single/Index");
    $stateProvider.state('login', {
        url: "Single/login",
        templateUrl: "Single/login",
        data: { pageTitle: 'Admin Dashboard Template' },
        controller: "LoginController"
    });
}]);