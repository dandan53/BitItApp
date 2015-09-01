app.controller('ForgetPasswordCtrl', function ($scope, $location, $routeParams, ForgetPasswordService) {
   
    $scope.forgetPassword = function () {

        if ($scope.user.email != "") {
            var user = {
                email: $scope.user.email
            };

            ForgetPasswordService.forgetPassword(user)
                .then(
                    loadRemoteData,
                    function (errorMessage) {
                        console.warn(errorMessage);
                    }
                );
        }
        else {
            alert('נא הכנס משתמש וסיסמא');
        }
    };

    // I load the remote data from the server.

    function loadRemoteData(data) {
        if (data != null && data.User != null) {
            $scope.username = data.User.Username;
            $scope.is_logged_in(true);
        } else {
            alert('שם משתמש או סיסמא אינם נכונים');
        }
    };

  
    $scope.user = {};
    $scope.user.email = "";
});
