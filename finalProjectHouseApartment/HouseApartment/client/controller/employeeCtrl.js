(function () {
    'use strict';
    myApp.controller('EmployeeCtrl', employeeController);

    employeeController.$inject = ['$scope', 'employeeService', 'departmentService'];

    function employeeController($scope, employeeService, departmentService) {
        function getemployeedetails() {
            employeeService.getEmployeeDetails().then(function (data) {
                $scope.EmployeeList = data;
            });


        }
        getemployeedetails();
        $scope.DepartmentList = [];
        $scope.addemployees = function (model) {
            employeeService.addemployees(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: " Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getemployeedetails();
                    $("#myModal2").modal('hide');
                }
                $scope.addemployees = [];
                getemployeedetails();
            });
        };


        $scope.UpdateEmployee = function (model) {

            employeeService.UpdateEmployee(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: "Updated  !",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getemployeedetails();
                    $("#myModal").modal('hide');
                }
                $scope.EditEmployee = [];
                getemployeedetails();
            });
        };




        $scope.deleteemployee = function (id) {

            var result = confirm("Are you sure want to delete?");
            if (result) {
                employeeService.deleteemployee(id).then(function (data) {
                    if (data) {
                        $.notify({
                            title: "",
                            message: "Employee Successfully Deleted!",

                            icon: 'fa fa-check'
                        }, {
                            type: "info"

                        });
                        getemployeedetails();
                        $("#myModal2").modal('hide');
                    }
                });
                getemployeedetails();
            }
        };

        $scope.getById = function (id) {
            employeeService.getById(id).then(function (data) {
                if (data !== null) {
                    $scope.EditEmployee = data;  //data comes from services and in editemployee are used in html pages.
                }
            });
        };
        $scope.getdepartmentdetails = function () {
            departmentService.getDepartmentDetails().then(function (data) {
                $scope.DepartmentList = data;
                console.log(data);
            });

        };
        $scope.getdepartmentdetails();
    }
})();