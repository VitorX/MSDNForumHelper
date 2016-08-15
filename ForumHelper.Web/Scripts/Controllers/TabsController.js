angular.module('ForumHelperApp').controller('tabsCtrl',['$scope','$window', function ($scope,$window) {

    $scope.alertMe = function () {
        setTimeout(function () {
            $window.alert('You\'ve selected the alert tab!');
        });
    };

    $scope.search = function () {
        $window.alert('function is not able now!');
    }
  
}]);

