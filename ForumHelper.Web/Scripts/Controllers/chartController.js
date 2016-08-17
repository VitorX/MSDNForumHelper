angular.module('ForumHelperApp').controller('pieCtrl', ['$scope','ARRate', function($scope,arRate) {

    arData = arRate.request(Date.now, Date.now, 'overall');
    $scope.labels = arData.labels;
    $scope.data = arData.data;

}]);

