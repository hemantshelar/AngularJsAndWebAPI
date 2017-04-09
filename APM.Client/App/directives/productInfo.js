(function () {
    "use strict";
    var module = angular.module("productManagement");
    module.directive('productInfo', function () {
        return {
            templateUrl: 'app/directives/productInfo.html',
            scope: {
                product: '='
            }
        };
    });
}());