angular.module('adminApp', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/posts', { templateUrl: 'partials/posts-list.html', controller: PostsListCtrl }).
          when('/categories', { templateUrl: 'partials/categories-dropdown.html', controller: CategoriesController }).
          when('/categories/:id/posts', { templateUrl: 'partials/posts-list.html', controller: SingleCategotyController }).
          when('/posts/create', { templateUrl: 'partials/create-post.html', controller: PostsListCtrl }).
          otherwise({ redirectTo: '/' });
  }]);