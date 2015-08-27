var app = angular.module("TodoApp", ["ngResource", "ngRoute"]);
    
app.config(function ($routeProvider) {
    $routeProvider.
         when('/', { controller: 'MainCtrl', templateUrl: 'main.html' }).
         when('/login', { controller: 'LoginCtrl', templateUrl: 'login.html' }).
         when('/newbid', { controller: 'NewbidCtrl', templateUrl: 'newbid.html' }).
         when('/pricebid/:id', { controller: 'PricebidCtrl', templateUrl: 'pricebid.html' }).
         when('/signup', { controller: 'SignupCtrl', templateUrl: 'signup.html' }).
         otherwise({ redirectTo: '/' });
});

app.factory('Item', function ($resource) {
    return $resource('/api/item/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

app.factory('Login', function ($resource) {
    return $resource('/api/login', { id: '@id' }, { update: { method: 'PUT' } });
});



//******************* http *************************//


app.service("bidService", function ($http, $q) {

                // Return public API.
                return ({
                    addBid: addBid,
                    getBid: getBid,
                    updateBid: updateBid

                    //removeFriend: removeFriend
                });


                // ---
                // PUBLIC METHODS.
                // ---


                // I add a friend with the given name to the remote collection.
                function addBid(item) {

                    var request = $http({
                        method: "post",
                        url: "/api/item/",
                        //params: {
                        //    action: "add"
                        //},
                        data:
                        {
                            CategoryId: item.CategoryId,
                            Category: item.Category,
                            SubCategoryId: item.SubCategoryId,
                            SubCategory: item.SubCategory,
                            ProductId: item.ProductId,
                            Product: item.Product,
                            DueDate: item.DueDate,
                            Amount: item.Amount
                        }
                    });

                    return (request.then(handleSuccess, handleError));

                }

                function updateBid(item) {

                    var request = $http({
                        method: "post",
                        url: "/api/item/",
                        //params: {
                        //    action: "add"
                        //},
                        data:
                        {
                            Id: item.Id,
                            NewPrice: item.NewPrice
                        }
                    });

                    return (request.then(handleSuccess, handleError));

                }               // I get all of the friends in the remote collection.
                function getBid(id) {

                    var request = $http({
                        method: "get",
                        url: "/api/item/",
                        params: {
                            id: id
                        }
                    });

                    return (request.then(handleSuccess, handleError));

                }


                //// I get all of the friends in the remote collection.
                //function getFriends() {

                //    var request = $http({
                //        method: "get",
                //        url: "api/index.cfm",
                //        params: {
                //            action: "get"
                //        }
                //    });

                //    return (request.then(handleSuccess, handleError));

                //}


                //// I remove the friend with the given ID from the remote collection.
                //function removeFriend(id) {

                //    var request = $http({
                //        method: "delete",
                //        url: "api/index.cfm",
                //        params: {
                //            action: "delete"
                //        },
                //        data: {
                //            id: id
                //        }
                //    });

                //    return (request.then(handleSuccess, handleError));

                //}


                // ---
                // PRIVATE METHODS.
                // ---


                // I transform the error response, unwrapping the application dta from
                // the API response payload.
                function handleError(response) {

                    // The API response from the server should be returned in a
                    // nomralized format. However, if the request was not handled by the
                    // server (or what not handles properly - ex. server error), then we
                    // may have to normalize it on our end, as best we can.
                    if (
                        !angular.isObject(response.data) ||
                        !response.data.message
                        ) {

                        return ($q.reject("An unknown error occurred."));

                    }

                    alert("handleError");

                    // Otherwise, use expected error message.
                    return ($q.reject(response.data.message));


                }


                // I transform the successful response, unwrapping the application data
                // from the API response payload.
                function handleSuccess(response) {

                   // alert("handleSuccess");

                    return (response.data);

                }

            }
        );



//***************** main ************************//

app.controller('MainCtrl', function ($scope) {

});



//*********************** List ***************************//

app.controller('ListCtrl', function ($scope, $location, Item) {

    $scope.cl = "row";

    $scope.setCl = function (ro) {
        if (ro.cl === "row") {
            ro.cl = "row zoom";
        } else {
            ro.cl = "row";
        }
    };

    //$scope.get_items = function () {
    //    Item.query({
    //        q: $scope.query,
    //        sort: $scope.sort_order,
    //        desc: $scope.is_desc,
    //        offset: $scope.offset,
    //        limit: $scope.limit
    //    },
    //        function (data) {
    //            $scope.items = data;
    //            //$scope.more = data.length > 5;
    //            //$scope.items = $scope.items.concat(data);
    //        });
    //};

    $scope.get_items = function (categoryId, subCategoryId, productId) {
        Item.query({
            categoryId: categoryId,
            subCategoryId: subCategoryId,
            productId: productId
        },
            function (data) {
                $scope.items = data;
                //$scope.more = data.length > 5;
                //$scope.items = $scope.items.concat(data);
            });
    };

    $scope.search = function () {
        var categoryId = $scope.selectedOption.id;
        var subCategoryId = $scope.selectedSubOption.id;
        var productId = $scope.selectedProduct.id;

        $scope.get_items(categoryId, subCategoryId, productId);
    };

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        }

        $scope.reset();
    };

    $scope.show_more = function () {
        $scope.offset += $scope.limit;
        $scope.search(0, 1000);
    };

    $scope.has_more = function () {
        return $scope.more;
    };

    $scope.reset = function () {
        $scope.limit = 5;
        $scope.offset = 0;
        $scope.items = [];
        $scope.more = true;
        $scope.search(0, 1000);
    };

    $scope.delete = function () {
        var id = this.todo.Id;
        Todo.delete({ id: id }, function () {
            $('#todo_' + id).fadeOut();
        });
    };

    $scope.sort_order = "Priority";
    $scope.is_desc = false;

    $scope.options = getCategories();
    $scope.selectedOption = $scope.options[0];

    $scope.update_selected_option = function () {
        $scope.subOptions = getSubCategories($scope.selectedOption.id);
        $scope.selectedSubOption = $scope.subOptions[0];
    };

    $scope.update_selected_option();

    $scope.update_selected_subOption = function () {
        $scope.products = getProducts($scope.selectedSubOption.id);
        $scope.selectedProduct = $scope.products[0];
    };

    $scope.update_selected_subOption();


    $scope.reset();
    
    $scope.price_bid = function (item) {
        $location.path('/pricebid/' + item.Id);
    };


    $scope.he = {};
    $scope.he.cat = "קטגוריה";
    $scope.he.pri = "תאור פריט";
    $scope.he.bes = "המחיר הטוב ביותר";
    $scope.he.siu = "מועד סיום המכרז";
    $scope.he.det = "לפרטים";

    $scope.en = {};
    $scope.en.cat = "category";
    $scope.en.pri = "description";
    $scope.en.bes = "best";
    $scope.en.siu = "final";
    $scope.en.det = "details";

});



//******************** Login **************************//

app.controller('LoginCtrl', function ($scope, $location, $routeParams, Login) {
    $scope.forgetPassword = false;

    $scope.toggle_forget_password = function () {
        $scope.forgetPassword = !$scope.forgetPassword;
    };

    $scope.show_forget_password = function () {
        return $scope.forgetPassword;
    };

    $scope.login = function () {
        Login.save({
            Username: $scope.item.Mail,
            Password: $scope.item.Password
        }, function (data) {
            alert(data.CID);
        });
    };

    $scope.item = {};
    $scope.item.Mail = "";
    $scope.item.Password = "";
});



//******************** New Bid **************************//

app.controller('NewbidCtrl', function ($scope, $location, $routeParams, Login, bidService) {
   
    $scope.options = getCategories();
    $scope.selectedOption = $scope.options[0];

    $scope.update_selected_option = function () {
        $scope.subOptions = getSubCategories($scope.selectedOption.id);
        $scope.selectedSubOption = $scope.subOptions[0];
    };

    $scope.update_selected_option();
    

    $scope.update_selected_subOption = function () {
        $scope.products = getProducts($scope.selectedSubOption.id);
        $scope.selectedProduct = $scope.products[0];
    };

    $scope.update_selected_subOption();
    
    $scope.dueDate = new Date();

    $scope.amount = 1;
    
    $scope.add_bid = function () {

        var product_name = $scope.selectedProduct.name;
        if (product_name === 'הכל') {
            alert('נא בחר מוצר');
        }
        else{
            var newBid = {
                CategoryId: $scope.selectedOption.id,
                Category: $scope.selectedOption.name,
                SubCategoryId: $scope.selectedSubOption.id,
                SubCategory: $scope.selectedSubOption.name,
                Product: $scope.selectedProduct.name,
                ProductId: $scope.selectedProduct.id,
                DueDate: $scope.dueDate,
                Amount: $scope.amount
            };

            bidService.addBid(newBid)
                            .then(
                                loadRemoteData,
                                function (errorMessage) {

                                    console.warn(errorMessage);

                                }
                            );

        }
    };
    
    // I load the remote data from the server.

    function loadRemoteData() {
        $location.url('http://www.google.com');
    };


});


//******************** Price Bid **************************//

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
        if (price > 0)
        {
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




//********************* SignUp *********************************//

app.controller('SignupCtrl', function ($scope, $location, $routeParams, Item) {

});








///////// Resources /////////

var categories = [
    { 'id': 0, 'name': 'בחר קטגוריה' },
    { 'id': 1, 'name': 'כלי עבודה' },
    { 'id': 2, 'name': 'מוצרי חשמל' },
    { 'id': 3, 'name': 'ריהוט' }
];

var getCategories = function () {
    return categories;
};


var subCategories = {};
subCategories[0] = [
    { 'id': 1000, 'name': 'כל תתי הקטגוריה' }
];

subCategories[1] = [
    { 'id': 1000, 'name': 'כל תתי הקטגוריה' },
    { 'id': 100, 'name': 'חומרי עבודה' },
    { 'id': 101, 'name': 'כלי עבודה' },
    { 'id': 102, 'name': 'כלים לנגרות' }
];

subCategories[2] = [
    { 'id': 1000, 'name': 'כל תתי הקטגוריה' },
    { 'id': 200, 'name': 'מאוורר' },
    { 'id': 201, 'name': 'מזגן' },
    { 'id': 202, 'name': 'טלויזיה' }
];

subCategories[3] = [
    { 'id': 1000, 'name': 'כל תתי הקטגוריה' },
    { 'id': 300, 'name': 'ארונות' },
    { 'id': 301, 'name': 'כסאות' },
    { 'id': 302, 'name': 'שולחנות' }
];

var getSubCategories = function (parentId) {
    return subCategories[parentId];
};


var products = {};
products[1000] = [
    { 'id': 0, 'name': 'הכל' }
];

products[100] = [
    { 'id': 0, 'name': 'הכל' },
    { 'id': 10001, 'name': 'קרמיקה' },
    { 'id': 10002, 'name': 'צבע' },
    { 'id': 10003, 'name': 'פלקט' }
];

products[101] = [
    { 'id': 0, 'name': 'הכל' },
    { 'id': 10101, 'name': 'מגרפה' },
    { 'id': 10102, 'name': 'מעדר' },
    { 'id': 10103, 'name': 'מטאטא' }
];

products[102] = [
    { 'id': 0, 'name': 'הכל' },
    { 'id': 10201, 'name': 'מסור' },
    { 'id': 10202, 'name': 'פטיש' },
    { 'id': 10203, 'name': 'מסמר' }
];


products[200] = [
    { 'id': 0, 'name': 'הכל' },
    { 'id': 20001, 'name': 'מאוורר תקרה' }
];

products[201] = [
    { 'id': 0, 'name': 'הכל' },
    { 'id': 20101, 'name': 'מזגן עילי' }
];

products[202] = [
    { 'id': 0, 'name': 'הכל' },
//    { 'id': 20200, 'name': 'הכל' },
    { 'id': 20201, 'name': 'LCD' },
    { 'id': 20202, 'name': 'LED' },
];


products[300] = [
//    { 'id': 30000, 'name': 'הכל' },
    { 'id': 0, 'name': 'הכל' },
    { 'id': 30001, 'name': 'ארון קיר' },
    { 'id': 30002, 'name': 'ארונית' },
    { 'id': 30003, 'name': 'ארון מטבח' }
];

products[301] = [
    { 'id': 0, 'name': 'הכל' },
//    { 'id': 30100, 'name': 'הכל' },
    { 'id': 30101, 'name': 'כסא פלסטיק' },
    { 'id': 30102, 'name': 'כסא בר' },
    { 'id': 30103, 'name': 'שרשפרף' }
];

products[302] = [
    { 'id': 0, 'name': 'הכל' },
//    { 'id': 30200, 'name': 'הכל' },
    { 'id': 30201, 'name': 'שולחן מטבח' },
    { 'id': 30202, 'name': 'שולחן מחשב' },
    { 'id': 30203, 'name': 'שולחן ישיבות' }
];

var getProducts = function (parentId) {
    return products[parentId];
};