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
        if (data != null && data.IsSuccess == true) {
            alert('הסיסמה נשלחה בהצלחה למייל שלך');
        } else {
            alert('נא נסה שנית');
        }
    };

  
    $scope.user = {};
    $scope.user.email = "";
});
