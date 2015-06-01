angular.module('starter.services', [])
    .factory('District', function ($http) {

        var restServer = "http://localhost:60695/api/";

        var getDistrict = function () {
            return $http.get(restServer + "district");
        };

        return {
            get: getDistrict
        }
    }).factory('Employee', function ($http) {

        var restServer = "http://localhost:60695/api/";

        var getEmployees = function () {
            return $http.get(restServer + "person");
        };

        var saveEmployee = function (employee) {
            //$http.post(restServer + "employee", employee);


            return $http({
                method: 'POST',
                //withCredentials:true,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' },
                data: $.param(employee) ,
                url: restServer + "person"
            });
        };

        return {
            get: getEmployees,
            save: saveEmployee
        }
    });



