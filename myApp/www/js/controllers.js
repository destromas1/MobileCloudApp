angular.module('starter.controllers', [])

.controller('DashCtrl', function ($scope) {
})

.controller('FriendsCtrl', ['$scope', 'District', 'Employee', function ($scope, District, Employee) {
    //$scope.friends = Friends.all();


    var saveDistrictsToLocalDb = function (districts) {
        localforage.setItem('districts', districts, function (err, items) {
            console.log(items);
        });
    };


    var getDistricts = function () {
        District.get().then(function (resp) {
            console.log(resp);
            $scope.districts = resp.data;
            alert("District Data sync succesfull from server");
            saveDistrictsToLocalDb($scope.districts);
        });
    };


    var init = function () {
        localforage.getItem('districts', function (err, values) {
            if (err) {
                console.error('Oh noes!');
                getDistricts();
            } else {
                if (!values) {
                    getDistricts();
                } else {
                    $scope.districts = values;
                    $scope.$digest();
                }
            }
        });
    };

    init();

    $scope.employee = {
        EmployeeId: 0,
        FirstName: '',
        LastName: '',
        DistrictName: '',
        DistrictId: null,
        JoiningDate: null
    };


    $scope.save = function () {

        localforage.getItem('employees', function (err, values) {
            if (err) {
                console.error('Oh noes!');
            } else {
                if (!values) {
                    values = [];
                }
                values.push($scope.employee);
                localforage.setItem('employees', values, function (err, employees) {
                    console.log(employees);
                    $scope.employee.FirstName = '';
                    $scope.employee.LastName = '';
                    $scope.employee.DistrictId = '';
                    $scope.employee.JoiningDate = '';
                    $scope.$digest();
                });

            }
        });


    };

}])

.controller('FriendDetailCtrl', function ($scope, $stateParams, Friends) {
    $scope.friend = Friends.get($stateParams.friendId);
})


.controller('AccountCtrl', ['$scope', 'Employee', function ($scope, Employee) {
    localforage.getItem('employees', function (err, value) {
        if (err) {
            console.error('Oh noes!');
        } else {
            $scope.employees = value.slice(0, 10);
            $scope.$digest();
            console.log("assasdadasd");
        }
    });


    $scope.syncToServer = function () {

        var employees = $scope.employees;

        angular.forEach(employees, function (employee, key) {
            Employee.save(employee).then(function (resp) {
                if (resp && resp.status) {
                    $scope.employees.splice(key, 1);
                }
            });
        });

        //window.setTimeout(function() {
        localforage.setItem('employees', [], function (err, empls) {

        });
        //}, 2500);
    };


}]);



