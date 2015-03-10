var TodoApp = angular.module("TodoApp", ["ngResource", "ngRoute"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            when('/login', { controller: LoginCtrl, templateUrl: 'login.html' }).
            when('/signup', { controller: SignupCtrl, templateUrl: 'signup.html' }).
            when('/new', { controller: CreateCtrl, templateUrl: 'details.html' }).
            when('/edit/:editId', { controller: EditCtrl, templateUrl: 'details.html' }).
            otherwise({ redirectTo: '/' });
    });


TodoApp.factory('Item', function ($resource) {
    return $resource('/api/item/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

TodoApp.factory('Login', function ($resource) {
    return $resource('/api/login', { id: '@id' }, { update: { method: 'PUT' } });
});

//*********************** List ***************************//

var ListCtrl = function ($scope, $location, Item) {

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

    $scope.get_items = function (categoryId, subCategoryId) {
        Item.query({
            categoryId: categoryId,
            subCategoryId: subCategoryId
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

        $scope.get_items(categoryId, subCategoryId);
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

    $scope.show_more = function() {
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
        Todo.delete({id: id}, function() {
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
    
    $scope.reset();

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

};


//******************** Login **************************//

var LoginCtrl = function ($scope, $location, $routeParams, Login) {
    $scope.forgetPassword = false;

    $scope.toggle_forget_password = function () {
        $scope.forgetPassword = !$scope.forgetPassword;
    };

    $scope.show_forget_password = function() {
        return $scope.forgetPassword;
    };

    $scope.login = function() {
        Login.save({
                Username: $scope.item.Mail,
                Password: $scope.item.Password
            }, function(data) {
                alert(data.CID);
            });
    };

    $scope.item = {};
    $scope.item.Mail = "";
    $scope.item.Password = "";
};


//********************* SignUp *********************************//

var SignupCtrl = function ($scope, $location, $routeParams, Item) {
    
};



var EditCtrl = function ($scope, $location, $routeParams, Item) {
    $scope.action = "Update";
    var id = $routeParams.editId;
    $scope.item = Item.get({ id: id });

    $scope.save = function () {
        Item.update({ id: id }, $scope.item, function () {
            $location.path('/');
        });
    };
};


var CreateCtrl = function ($scope, $location, Item) {
    $scope.action = "Add";

    $scope.save = function () {
        Item.save($scope.item, function () {
            $location.path('/');
        });
    };
};






///////// Resources /////////

var categories = [
    { 'id': 0, 'name': 'בחר קטגוריה' },
    { 'id': 1, 'name': 'כלי עבודה' },
    { 'id': 2, 'name': 'מוצרי חשמל' },
    { 'id': 3, 'name': 'ריהוט' }
];

var getCategories = function() {
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