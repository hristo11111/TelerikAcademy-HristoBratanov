/// <reference path="../data/menuItems.js" />
function PostsListCtrl($scope, $http) {
    $scope.newPost = {
        title: "",
        content: "",
        dateCreated: ""
    };

    $http.get('http://localhost:2115/api/Posts').success(function (data) {
        $scope.posts = data;

        $scope.addPost = function () {
            $scope.posts.push($scope.newPost);
            //var category = $scope.newPost.category;
            //if (!_.contains($scope.categories, category)) {
            //    $scope.categories.push(category);
            //}

            $scope.newPost = {
                title: "",
                content: "",
                dateCreated: ""
            };
        }

    });
}

function CategoriesController($scope, $http) {
    $http.get('http://localhost:2115/api/Categories').success(function (data) {
        $scope.categories = data;
    });
}

function SingleCategotyController($scope, $http, $routeParams) {
    var id = $routeParams.id;

    $http.get('http://localhost:2115/api/Categories/' + id).success(function (data) {
        //var category = _.where(data, { "id": parseInt(id) });
        //debugger;
        //var catPosts = category[0].posts;
        $scope.posts = data;
    }); 
}