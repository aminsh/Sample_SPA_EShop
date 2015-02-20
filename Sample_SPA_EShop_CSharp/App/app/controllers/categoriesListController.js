define([
    'app',
    'service/rest/categoryService',
    'directives/imageuploader'
], function(app){

    app.register.controller('categoriesListController',function($scope,categoryService){
        $scope.title = 'مدیریت محصولات';
        $scope.categories = [];
        $scope.currentCategory = {};
        $scope.selectedImage = {};

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
                image: {},
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
                image: {}
            });
        };

        $scope.removeProduct = function(category , product){
            category.products.remove(product);
        };

        $scope.expandCategory = function(category){
            category.canShowProduct = !category.canShowProduct;
        };

        $scope.afterUploadAction = function(image){
            $scope.selectedImage = image;
        };

        $scope.assignImageToCategory = function(category , images){
            debugger;
            var img = images.first();
            var image = category.image;

            image.key = img.Key;
            image.bigUrl = img.BigUrl;
            image.smallUrl = img.SmallUrl;
        }

        $scope.cancelAssignImageToCategory = function(){
            $scope.currentCategory = {};
        };

        $scope.selectImage = function(category){
            $scope.currentCategory = category;
        };
    });
});

