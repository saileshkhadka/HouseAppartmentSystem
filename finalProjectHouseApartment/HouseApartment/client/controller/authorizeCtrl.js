/// <reference path="C:\Users\Avishek\Desktop\final\finalProjectHouseApartment\HouseApartment\js/plugins/bootstrap-notify.min.js" />


(function () {
    'use strict';
    myApp.controller('AuthorizeCtrl', authorizeController);

    authorizeController.$inject = ['$scope', 'dataService'];

    function authorizeController($scope, dataService) {
        $scope.data = "";
        dataService.GetAuthorizeData().then(function (data) {
      
            $scope.data = data.details;
            $scope.name = data.name;

       
        })
    }
})();

