(function () {
    'use strict';
    myApp.controller('unauthorizeController', unauthorizeController);

    unauthorizeController.$inject = ['$scope'];

    function unauthorizeController($scope) {
        $scope.data = "Sorry you are not authorize to access this page";
    }
})();

