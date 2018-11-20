(function () {
    'use strict';
    myApp.factory('departmentService', departmentService);

    departmentService.$inject = ['$http', 'serviceBasePath', '$q'];

    function departmentService($http, serviceBasePath, $q) {
        var fac = {};
     
        fac.getDepartmentDetails = function () {

            return $http.get(serviceBasePath + '/api/department/getdepartmentdetails').then(function (response) {
                return response.data;
            })
        }
        fac.adddepartments = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var data = {
                Id: model.DepartmentID,
                DepartmentName: model.DepartmentName,
                Description: model.Description,
                Status: model.Status,
                EmployeeNumber:model.EmployeeNumber
            }
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/department/adddepartments', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }

        
        fac.updatedepartments = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/department/updatedepartments', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }
        


        fac.deletedepartments = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/department/deletedepartments', id, config).success(function (response) {     //1st id=noticecontroller,2nd id = from function(id)
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }
        fac.getDepartmentByID = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/department/getbyid', { params: { id: id } }, config).success(function (response) {     //1st id=noticecontroller,2nd id = from function(id)
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
