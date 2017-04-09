(function () {
    "use strict";

    for (var i = 0; i < 5; i++) {

        (function (myVar) {
            setTimeout(function () {
                console.log('My var is : ' + myVar);
            },2000);
        }(i));
    }
    var module = angular.module("productManagement");

    module.factory('sharedService', function ($rootScope) {
        var service = {};
        service.data = false;

        service.sendData = function (data) {
            this.data = data;
            $rootScope.$broadcast('data_shared');
        }

        service.getData = function () {
            return this.data;
        }
        return service;
    });
}());