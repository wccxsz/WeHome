var HomeController = function($scope, $sce, $state) {
    $scope.models = {
        Title: '首页'
    };
    if ($state.current.name === '') {
        $state.go('images', {}, { reload: true });
        $scope.currentSelectedMenu = 'images';
    }
    $scope.toTrustedHTML = function(html, state) {
        if (state === $scope.currentSelectedMenu) {
            return $sce.trustAsHtml(html + '<span class="selected"></span>');
        } else {
            return $sce.trustAsHtml(html);
        }
    };
    $scope.Menus = [
        { state: 'images', title: '照片', css: 'classic-menu-dropdown active' },
        { state: 'video', title: '视频', css: 'classic-menu-dropdown' },
        { state: 'question', title: '好问', css: 'classic-menu-dropdown' },
        { state: 'community', title: '社区', css: 'classic-menu-dropdown' },
        { state: 'dictionary', title: '妈妈宝典', css: 'classic-menu-dropdown' }
    ];


    $scope.menuClick = function(state) {
        $scope.currentSelectedMenu = state;
        for (var i = 0; i < $scope.Menus.length; i++) {
            if ($scope.Menus[i].state === state) {
                $scope.Menus[i].css = 'classic-menu-dropdown active';
            } else {
                $scope.Menus[i].css = 'classic-menu-dropdown';
            }
        }
    };


}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope', '$sce', '$state'];