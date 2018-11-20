(function () {
    'use strict';
    myApp.controller('DepartmentCtrl', departmentController);

    departmentController.$inject = ['$scope', 'departmentService'];

    function departmentController($scope, departmentService) {
        function getdepartmentdetails() {
            departmentService.getDepartmentDetails().then(function (data) {
                $scope.DepartmentList = data;
            });
           
            
        }
        getdepartmentdetails();
    
        $scope.adddepartments = function (model) {
            departmentService.adddepartments(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: " Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getdepartmentdetails();
                    $("#myModal2").modal('hide');
                }
                $scope.CreateUser = [];
                getdepartmentdetails();
            });
        };
        
    
        $scope.updatedepartments = function (model) {

            departmentService.updatedepartments(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: "Updated Successfully !",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getdepartmentdetails();
                    $("#myModal").modal('hide');
                }
                $scope.EditDepartment = [];
                getdepartmentdetails();


            });
        };

        $scope.deletedepartments = function (id) {
            var result = confirm("Are you sure want to delete?");
            if (result) {
                departmentService.deletedepartments(id).then(function (data) {
                    if (data) {
                        $.notify({
                            title: "",
                            message: "Department Successfully Deleted!",

                            icon: 'fa fa-check'
                        }, {
                            type: "info"

                        });
                        getdepartmentdetails();
                        $("#myModal2").modal('hide');
                    }

                });
                getdepartmentdetails();
            }
        };

        $scope.GetDepartmentByID = function (id) {
            departmentService.getDepartmentByID(id).then(function (data) {
                if (data !== null) {
                    $scope.Editdepartment = data;  //data comes from services and in editdepartment are used in html pages.
                }

            });
        };

    }
})();