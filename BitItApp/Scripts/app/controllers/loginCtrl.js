app.controller('LoginCtrl', function ($scope, $location, $routeParams, LoginService, Data, UserData) {
    $scope.Data = Data;
    //$scope.isForgetPassword = false;

    $scope.toggle_forget_password = function () {
        $scope.Data.isForgetPassword = !$scope.Data.isForgetPassword;
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
            $scope.user.username = data.User.Username;
            $scope.user.CID = data.User.CID;
            
            //$scope.is_logged_in(true);
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
        $scope.user.username = "";
        $scope.user.CID = 0;

        //$scope.is_logged_in(false);

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

    //$scope.is_logged = false;

    //$scope.is_logged_in = function (is_login) {
    //    $scope.is_logged = is_login;
    //};

    $scope.isLoggedIn = function () {
        if ($scope.user != null && $scope.user.CID != 0) {
            return true;
        } else {
            return false;
        }
    };

    $scope.user = UserData;
});
