(function (app) {
    app.controller('loginController', loginController);

    loginController.$inject = ['$scope','loginService','$injector','notificationService'];
    function loginController($scope, loginService, $injector, notificationService) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.loginSubmit = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.data.error != undefined) {
                    //notificationService.displayError(response.data.error_description);
                    notificationService.displayError("Đăng nhập không thành công!");

                }
                else {
                    var stateService = $injector.get('$state');
                    stateService.go('home');
                }
            });
        }
    }
})(angular.module('techShop'));