/// <reference path="../../../bower_components/angular/angular.js" />

(function () {
    angular.module('techShop.products_categories', ['techShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products_categories', {
            url: "/products_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });

    }
})();