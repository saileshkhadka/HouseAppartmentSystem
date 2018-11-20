var myApp = angular.module('myApp', ['ui.router', 'dataGrid', 'pagination']);
//config routing
myApp.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/login');
    $stateProvider
        .state('auth', {
            abstract: true,
            views: {
                '@': {
                    templateUrl: '/client/views/layouts/main.html'
                },
            }
        })
        .state('public', {
            abstract: true,
            views: {
                '@': {
                    templateUrl: '/client/views/layouts/authentication.html'
                }
            },
            data: {
                pageTitle: 'Home',
                requiredLogin: false
            }
        })
            .state('auth.role', {
                url: '/role',
                templateUrl: '/client/views/roleManagement.html',
                controller: 'RolesCtrl',
                controllerAs: 'vm'
            })

            .state('auth.employee', {
                url: '/employee',
                templateUrl: '/client/views/employeeManagement.html',
                controller: 'EmployeeCtrl',
                controllerAs: 'vm'
            })
         .state('auth.department', {
             url: '/department',
             templateUrl: '/client/views/departmentManagement.html',
             controller: 'DepartmentCtrl',
             controllerAs: 'vm'
         })
        //.state('auth.notice', {
        //    url: '/notice',
        //    templateUrl: '/client/views/noticeManagement.html',
        //    controller: 'NoticesCtrl',
        //    controllerAs: 'vm'
        //})
              //.state("auth.home", {
              //    url: '/home',
              //    templateUrl: '/client/views/home.html',
              //    controller: 'HomeCtrl',

              //    data: { pageTitle: 'Dashboard' }
              //})
          .state("auth.authorize", {
              url: '/authorize',
              templateUrl: '/client/views/authorize.html',
              controller: 'AuthorizeCtrl',

              data: { pageTitle: 'Dashboard' }
          })
          //.state("auth.list", {
          //    url: '/home',
          //    templateUrl: '/client/views/list.html',
          //    controller: 'ListCtrl',

          //    data: { pageTitle: 'Dashboard' }
          //})

       //public states with no login required
            .state('public.login', {
                url: '/login',
                controller: 'LoginCtrl',
                templateUrl: '/client/views/login.html',
                controllerAs: 'vm'
            })
        .state('public.register', {
            url: '/register',
            controller: 'RegisterCtrl',
            templateUrl: '/client/views/register.html',
            controllerAs: 'vm'
        })
 
    //$routeProvider
    //.when('/', {
    //    redirectTo: '/login'
    //})
    //.when('/home', {
    //    templateUrl: '/template/home.html',
    //    controller: 'homeController'
    //})
    //.when('/authenticated', {
    //    templateUrl: '/template/authenticate.html',
    //    controller: 'authenticateController'
    //})
    //.when('/authorized', {
    //    templateUrl: '/template/authorize.html',
    //    controller: 'authorizeController'
    //})
    //.when('/login', {
    //    templateUrl: '/template/login.html',
    //    controller: 'loginController'
    //})
    //.when('/unauthorized', {
    //    templateUrl: '/template/unauthorize.html',
    //    controller: 'unauthorizeController'
    //})
    //.when('/register', {
    //    templateUrl: '/template/register.html',
    //    controller: 'registerController'
    //})
    //.when('/role', {
    //    templateUrl: '/template/roleManagement.html',
    //    controller: 'roleController'
    //})
}])
//global veriable for store service base path
myApp.constant('serviceBasePath', 'http://localhost:3855');
//controllers

//http interceptor
myApp.config(['$httpProvider', function ($httpProvider) {
    var interceptor = function (userService, $q, $location) {
        return {
            request: function (config) {
                var currentUser = userService.GetCurrentUser();
                if (currentUser !== null) {
                    config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                }
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                    return $q.reject(rejection);
                }
                if (rejection.status === 403) {
                    $location.path('/unauthorized');
                    return $q.reject(rejection);
                }
                return $q.reject(rejection);
            }

        }
    }
    var params = ['userService', '$q', '$location'];
    interceptor.$inject = params;
    $httpProvider.interceptors.push(interceptor);
}]);
