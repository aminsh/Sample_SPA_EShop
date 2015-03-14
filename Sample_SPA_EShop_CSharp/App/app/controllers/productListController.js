
define(['app', 'service/helper', 'service/rest/productService'],function(app){
    app.register.controller('productListController',function($scope, helper, productService){
        debugger;

        $scope.products = [];

        productService.get({Term: 'amin'})
            .then(function(result){
                debugger;
            });

        $scope.viewType = 'gallary';

        $scope.params = {
            categoryId: 0,
            sortItem: ''
        };

        $scope.changeView = function(){
            if($scope.viewType == 'gallary')
            $scope.viewType = 'list';
            else
            $scope.viewType = 'gallary';
        };

        $scope.addToCart = function(p){
            console.log(p);
        }
    });
});
