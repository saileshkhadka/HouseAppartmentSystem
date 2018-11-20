(function () {
    'use strict';
    myApp.controller('RolesCtrl', roleController);

    roleController.$inject = ['$scope', 'dataService'];

    function roleController($scope, dataService) {
        function getDetails() {
            dataService.getUserDetails().then(function (data) {
                $scope.UserDetailsData = data;
               
            })
        };
        getDetails();
      
    }
})();