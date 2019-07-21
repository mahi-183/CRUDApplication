//(function () {
//    'use strict';

//    angular
//        .module('app')
//        .controller('HomeController', HomeController);

//    HomeController.$inject = ['$location'];

//    function HomeController($location) {
//        /* jshint validthis:true */
//        var vm = this;
//        vm.title = 'HomeController';

//        activate();

//        function activate() { }
//    }
//})();
//var app = angular.module("MyApp", [])
//app.controller("HomeController", function ($scope) {
//    var user = {
//        'FirstName': $scope.Firstname,
//        'LastName': $scope.Lastname,
//        'Designation': $scope.Desigantion,
//        'FirstName': $scope.Firstname,
//    }



//    console.log('data in controller')
//    $http.Get('https://localhost:44355/api/Employee/Get').success(function () {
//        $scope.
//    });

var app = angular.module('MyApp', [])
app.controller('HomeController', function ($scope, $http, $window) {
     console.log('in home controller');
    ////Getting records from database.
    var post = $http({
        method: "GET",
        url: "https://localhost:44355/api/Employee/Get",
        dataType: 'json',
        headers: { "Content-Type": "application/json" }
    }).then(
        function successCallback(response) {//call back function of http sevice
            console.log("chat service get all users it returns some response")
            console.log("datbase reocrd:", response.data)
            //The received response is saved in Emploees array
            $scope.EmployeeManagement = response.data;
        },
        function errorCallback(response) {
            console.log("register Unsuccessfull ");
            console.log(response);
        }
    );

    
    $scope.Add = function () {
        if (typeof ($scope.Firstname) == "undefined" || ($scope.Lastname) == "undefined" || ($scope.City) == "undefined" || ($scope.Contact) == "undefined" || ($scope.Gender) == "undefined") {
            return;
        }
        var post = $http({
            method: "POST",
            url: "https://localhost:44355/api/Employee/add",
            data: "{Firstname: '" + $scope.FirstName + "', Lastname: '" + $scope.LastName + "',  Designation: '" + $scope.Designation + "',  Age: '" + $scope.Age + "',  Salary: '" + $scope.Salary + "',  Gender: '" + $scope.Gender + "'}",
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            //The newly inserted record is inserted into the Emploees array.
            $scope.EmployeeManagement.push(data)
        });
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.Designation = "";
        $scope.Age = " ";
        $scope.Salary = " ";
        $scope.Gender = "";
    };


    $scope.EditItem = {};

    //Editing an existing record.
    $scope.Edit = function (index) {
        //Setting EditMode to TRUE makes the TextBoxes visible for the row.
        $scope.EmployeeManagement[index].EditMode = true;

        //The original values are saved in the variable to handle Cancel case.
        $scope.EditItem.employeeId = $scope.EmployeeManagement[index].employeeId;
        $scope.EditItem.firstName = $scope.EmployeeManagement[index].firstName;
        $scope.EditItem.lastName = $scope.EmployeeManagement[index].lastName;
        $scope.EditItem.designation = $scope.EmployeeManagement[index].designation;
        $scope.EditItem.age = $scope.EmployeeManagement[index].age;
        $scope.EditItem.salary = $scope.EmployeeManagement[index].salary;
        $scope.EditItem.gender = $scope.EmployeeManagement[index].gender;
    };

    $scope.Cancel = function (index) {
        // The original values are restored back into the Emploees Array.
        $scope.EmployeeManagement[index].EmployeeId = $scope.EditItem.EmployeeId;
        $scope.EmployeeManagement[index].FirstName = $scope.EditItem.FirstName;
        $scope.EmployeeManagement[index].LastName = $scope.EditItem.LastName;
        $scope.EmployeeManagement[index].Designation = $scope.EditItem.Designation;
        $scope.EmployeeManagement[index].Age = $scope.EditItem.Age;
        $scope.EmployeeManagement[index].Salary = $scope.EditItem.Salary;
        $scope.EmployeeManagement[index].Gender = $scope.EditItem.Gender;

        //Setting EditMode to FALSE hides the TextBoxes for the row.
        $scope.EmployeeManagement[index].EditMode = false;
        $scope.EditItem = {};
    };

    $scope.Update = function (index) {
        var Employee = $scope.EmployeeManagement[index];
        var put = $http({
            method: "PUT",
            url: "https://localhost:44355/api/Employee/update/5",
            data: JSON.stringify(Employee),
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        put.success(function (data, status) {
            //Setting EditMode to FALSE hides the TextBoxes for the row.
            Employee.EditMode = false;
        });
    };

    $scope.Delete = function (EmpId) {
        if ($window.confirm("Do you want to delete this row?")) {
            var _Emp = {};
            _Emp.EmployeeId = EmpId;
            var post = $http({
                method: "Delete",
                url: "https://localhost:44355/api/Employee/delete/5",
                data: JSON.stringify(_Emp),
                dataType: 'json',
                headers: { "Content-Type": "application/json" }
            });
            post.success(function (data, status) {
                //Remove the Deleted record from the Customers Array.
                $scope.EmployeeManagement = $scope.EmployeeManagement.filter(function (emp) {
                    return emp.EmployeeId !== EmpId;
                });
            });
            post.error(function (data, status) {
                $window.alert(data.Message);
            });
        }
    };
});

//});
