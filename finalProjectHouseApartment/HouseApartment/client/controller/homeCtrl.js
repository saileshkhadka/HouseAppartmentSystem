(function () {
    'use strict';
    myApp.controller('HomeCtrl', homeController);

    homeController.$inject = ['$scope', 'dataService'];

    function homeController($scope, dataService) {
        $scope.data = "";
     
        dataService.GetAnonymousData().then(function (data) {
            $scope.data = data;
        })
    }
})();

