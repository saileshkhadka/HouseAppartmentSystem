(function () {
    'use strict';
    myApp.factory('employeeService', employeeService);

    employeeService.$inject = ['$http', 'serviceBasePath', '$q'];

    function employeeService($http, serviceBasePath, $q) {
        var fac = {};

        fac.getEmployeeDetails = function () {

            return $http.get(serviceBasePath + '/api/employee/getemployeedetails').then(function (response) {
                return response.data;
            })
        }
        fac.addemployees = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var data = {
                ID:model.EmployeeID,
                EmployeeName: model.EmployeeName,
                Address: model.Address,
                ContactNumber: model.ContactNumber,
                DepartmentId: model.DepartmentId,
                DepartmentName: model.DepartmentName,
                Status: model.Status,
                
              
            }
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/employee/addemployees', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }
      

        fac.deleteemployee = function (id) {


            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/employee/deleteemployee', { params: { id: id } }, config).success(function (response) {     //1st id=employeecontroller,2nd id = from function(id)
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }


        fac.UpdateEmployee = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/employee/Update', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }

        fac.getById = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/employee/getById', { params: { id: id } }, config).success(function (response) {     //1st Id=employeecontroller,2nd Id = from function(Id)
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }
        return fac;
    }


})();