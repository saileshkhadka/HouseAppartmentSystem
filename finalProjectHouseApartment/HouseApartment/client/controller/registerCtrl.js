(function () {
    'use strict';
    myApp.controller('RegisterCtrl', registerController);

    registerController.$inject = ['$scope', 'dataService','$location'];

    function registerController($scope, dataService, $location) {

        var vm = this;
        vm.CreateUser = {};
        $scope.Create = function (model) {
         
         //   model.DateOfBirth = (model.DateOfBirth);
            console.log(model);
            dataService.CreateUser(model).then(function (data) {
                
                $scope.data = data;
            })


        }

        $scope.loginpage = function () {
            $location.path('/login');
        };
    
    }
})();
