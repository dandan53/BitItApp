var TodoApp = angular.module("TodoApp", ["ngResource", "ngRoute"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            otherwise({ redirectTo: '/' });
    });

TodoApp.factory('Todo', function ($resource) {
    return $resource('/api/todo/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

var ListCtrl = function ($scope, $location, Todo) {
    $scope.search = function() {
        Todo.query({q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offest, limit: $scope.limit },
            function (data) {
                $scope.more = data.length === 20;
                $scope.items = $scope.items.concat(data);
        });
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
        $scope.search();
    };
    
    $scope.has_more = function () {
        return $scope.more;
    };

    $scope.reset = function () {
        $scope.limit = 20;
        $scope.offest = 0;
        $scope.items = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.sort_order = "Priority";
    $scope.is_desc = false;
    
    $scope.reset();
};













//TodoApp.directive('greet', function () {
//    return {
//        template: '<h2>Greeting from {{from}} to my dear {{to}}</h2>',
//        controller: function ($scope, $element, $attrs) {
//            $scope.from = $attrs.from;
//            $scope.to = $attrs.greet;
//        }
//    };
//});

//TodoApp.directive('dir', function() {
//    return {
//        scope: true,
//        transclude: true,
//        require: '',
//        template: '',
//        link: function(scope, elm, attrs, ctrl) {
//        },
//        controller: function($scope, $element, $attrs) {

//        }
//    };
//});

