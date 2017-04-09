(function () {
    "use strict";

    var module = angular.module("productManagement");

    module.controller('ProductEditCtrl', function ($scope, sharedService) {
        $scope.test = "hello world!";

        $scope.$on('data_shared', function () {
            console.log(sharedService.getData());

        });
        $scope.product = {
            "productId"    : "1",
            "productName"  : "Test Product",
            "productCode"  : "GDN-New",
            "description"  : "Test desc",
            "price"        : "101.09"
        };
    });
}());