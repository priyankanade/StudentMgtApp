//<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.6/angular.min.js"></script>
var app = angular.module("HomeApp", []);
app.controller("StudentController", function ($scope, $http) {
    $scope.btntext = "save";
    $scope.savedata = function () {
        $scope.btntext = "Wait..";
        $http({
            method: 'POST',
            url: '/Student/create',
            data: $scope.Student
        }).success(function (d) {
            $scope.btntext = "save";
            $scope.Student = null;
        }).error(function () {
            alert("Failed");
        })
    }
});