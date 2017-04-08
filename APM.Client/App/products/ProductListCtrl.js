var module = angular.module("productManagement");

module.controller('ProductListCtrl', function ($scope,productResource) {

    $scope.products = [];

    //productResource.query(function (data) {
    //    $scope.products = data;
    //});

    productResource.query({search: 'GDN'},function (data) {
        $scope.products = data;
    });

});