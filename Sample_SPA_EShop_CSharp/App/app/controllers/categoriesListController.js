define([
    'app',
    'service/rest/categoryService'
], function(app){

    app.register.controller('categoriesListController',function($scope,categoryService){
        $scope.title = 'مدیریت محصولات';
        $scope.categories = [];

        function init(){
            categoryService.get()
                .then(function(result){
                    $scope.categories = result
                        .select(function(item){
                            item.canShowProduct = false;
                            return item;
                        });

                    if(!$scope.$$phase)
                        $scope.$apply();
            });
        }

        init();

        $scope.save = function(form){
            debugger;
            categoryService.save($scope.categories)
                .then(function(result){
                    $scope.categories = result;
                });
        };

        $scope.addCategory = function(){
            $scope.categories.push({
                id: 0,
                name: '',
                imageId: 0,
                imageUrl: 0,
                products: []
            });
        };

        $scope.removeCategory = function(category){
            $scope.categories.remove(category);
        };

        $scope.addProduct = function(category){
            category.products.push({
                id: 0,
                name: '',
                imageId: 0,
                imageUrl: 0
            });
        };

        $scope.removeProduct = function(category , product){
            category.products.remove(product);
        };

        $scope.expandCategory = function(category){
            category.canShowProduct = !category.canShowProduct;
        };
    });
});

