(function () {
    angular.module('techShop', ['techShop.products',
                                'techShop.products_categories',
                                'techShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
                url: "/admin",
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/admin');

    }
})();