var LoginController = function($scope, $routeParams, $location) {
    $scope.loginForm = {
        emailAddress: '',
        password: '',
        rememberMe: false,
        returnUrl: $routeParams.returnUrl
    };

    $scope.login = function() {
        //todo
        console.log(loginForm);
        $location.path("index");
    }
}

LoginController.$inject = ['$scope', '$routeParams', '$location'];