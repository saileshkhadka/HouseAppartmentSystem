(function () {
    'use strict';
    myApp.controller('LoginCtrl', loginController);

    loginController.$inject = ['$scope', 'accountService', '$location'];

    function loginController($scope, accountService, $location) {
        $scope.account = {
            username: '',
            password: ''
        }
        $scope.message = "";
        $scope.login = function () {
            accountService.login($scope.account).then(function (data) {
                $.notify({
                    title: "",
                    message: " Login Success!",
                    icon: 'fa fa-check'
                }, {
                    type: "info"
                });
                $location.path('/authorize');

            }, function (error) {
                $.notify({
                    title: "",
                    message: " Login Failed!",
                    icon: 'fa fa-check'
                }, {
                    type: "danger"
                });
            })
        }

        $scope.registerpage = function () {
            $location.path('/register');
        };
    }
})();

