(function () {
    'use strict';
        myApp.factory('dataService', dataService);

        dataService.$inject = ['$http', 'serviceBasePath','$q'];

        function dataService($http, serviceBasePath,$q) {
        var fac = {};
        fac.GetAnonymousData = function () {
            return $http.get(serviceBasePath + '/api/data/forall').then(function (response) {
                return response.data;
            })
        }

        fac.GetAuthenticateData = function () {
            return $http.get(serviceBasePath + '/api/data/authenticate').then(function (response) {
                return response.data;
            })
        }

        fac.GetAuthorizeData = function () {
            return $http.get(serviceBasePath + '/api/data/authorize').then(function (response) {
                return response.data;
            })
        }

 fac.CreateUser = function (model) {
            console.log(model)
           
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/user/create', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
   
 }

 fac.getUserDetails = function () {
    
     return $http.get(serviceBasePath + '/api/role/getUserRoles').then(function (response) {
         return response.data;
     })
 }
        return fac;
    }
})();


