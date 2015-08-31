app.controller('LoginCtrl', function ($scope, $location, $routeParams, LoginService) {
    $scope.forgetPassword = false;

    $scope.toggle_forget_password = function () {
        $scope.forgetPassword = !$scope.forgetPassword;
    };

    $scope.show_forget_password = function () {
        return $scope.forgetPassword;
    };

    $scope.login = function () {

        if ($scope.cred.username != "" && $scope.cred.password != "") {
            var cred = {
                username: $scope.cred.username,
                password: $scope.cred.password
            };

            LoginService.login(cred)
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

    //$scope.login = function () {      
    //    Login.save({
    //        Username: $scope.cred.Mail,
    //        Password: $scope.cred.Password
    //    }, function (data) {
    //        if (data != null && data.User != null) {
    //            $scope.username = data.Username;
    //            $scope.is_logged_in(true);
    //        } else {
    //            alert(data.CID);
    //        }
    //    });
    //};

    $scope.logout = function () {
        $scope.username = "";
        $scope.is_logged_in(false);

        //Login.save({
        //    Username: $scope.item.Mail,
        //    Password: $scope.item.Password
        //}, function (data) {
        //    $scope.is_logged_in(false);
        //    alert(data.CID);
        //});
    };

    $scope.cred = {};
    $scope.cred.username = "";
    $scope.cred.password = "";

    $scope.is_logged = false;

    $scope.is_logged_in = function (is_login) {
        $scope.is_logged = is_login;
    };

    $scope.username = "";
});
