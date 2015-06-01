angular.module('starter.services', [])
    .factory('Employee', function($http) {

        var restServer = "http://localhost:60695/api/";

        var getEmployees = function() {
            return $http.get(restServer + "employee");
        };

    var saveEmployee = function(employee) {
        $http.post(restServer + "employee", employee);
    };

        return {
            get: getEmployees,
            save : saveEmployee
        }
    });
