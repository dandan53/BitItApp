app.controller('MainCtrl', function ($scope, $location, UserData) {

    $scope.newBid = function (item) {
        if ($scope.isLoggedIn()) {
            $location.path('/newbid/');
        } else {
            alert('יש להיכנס למערכת');
        }
    };

    $scope.isLoggedIn = function () {
        if ($scope.user != null && $scope.user.CID != 0) {
            return true;
        } else {
            return false;
        }
    };

    $scope.user = UserData;

});
