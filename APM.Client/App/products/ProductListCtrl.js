var module = angular.module("productManagement");

module.controller('ProductListCtrl', function ($scope, productResource, sharedService) {

    $scope.products = [];
    $scope.searchFilter = "";

    $scope.selectedProduct = {
       "productId"    : "1",
       "productName"  : "Test Product",
       "productCode"  : "GDN-New",
       "description"  : "Test desc",
       "price"        : "101.09"
    };

    $scope.applyFilter = function () {
        console.log("Searching....");
        productResource.query({ search: $scope.searchFilter }, function (data) {
            $scope.products = data;
        });
    }

    $scope.odata1 = function () {
        productResource.query({$skip: 1, $top: 2}, function (data) {
            $scope.products = data;
        });
    }

    $scope.odata2 = function () {
        productResource.query({ $filter: "substringof('GDN',ProductCode) and Price ge 10 " }, function (data) {
            $scope.products = data;
        });
    }

    productResource.query(function (data) {
        $scope.products = data;
    });

    $scope.shareData = function () {
        sharedService.sendData('My data');
    }

});