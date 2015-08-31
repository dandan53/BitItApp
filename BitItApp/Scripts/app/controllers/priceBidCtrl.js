app.controller('PricebidCtrl', function ($scope, $location, $routeParams, Login, bidService) {


    $scope.bid_id = $routeParams.id;

    $scope.get_bid = function () {

        bidService.getBid($scope.bid_id)
                        .then(
                            loadData,
                            function (errorMessage) {

                                console.warn(errorMessage);

                            }
                        )
        ;
    };

    function loadData(data) {
        $scope.item = data;
    };


    $scope.get_bid();


    $scope.update_bid = function () {

        var price = $scope.price;
        if (price > 0) {
            var updatedBid = {
                Id: $scope.bid_id,
                NewPrice: price
            };

            bidService.updateBid(updatedBid)
                            .then(
                                loadRemoteData,
                                function (errorMessage) {

                                    console.warn(errorMessage);

                                }
                            );

        } else {
            alert('נא הגש הצעה');
        }
    };


    // I load the remote data from the server.

    function loadRemoteData() {
        $location.url('http://www.google.com');
    };


});

