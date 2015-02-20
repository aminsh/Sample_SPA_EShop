define(['app'],function(app){
    app.register.factory('categoryService', function($http , $q){
       return{
           get: function(){
               var deferred = $q.defer();

               $http.get('/api/categories')
                   .success(function(data){
                       var categories = data.select(function(item){return new category(item);});
                       deferred.resolve(categories);
                   })
                   .error(function(error){
                       deferred.reject(error);
                   });

               return deferred.promise;
           },
           save: function(categories){
               var deferred = $q.defer();

               var cats = categories.select(function(c){
                   return {
                       Id: c.id,
                       Name: c.name,
                       ImageKey: c.image.key,
                       Products: c.products.select(function(p){
                           return {
                               Id: p.id,
                               Name: p.name,
                               ImageId: p.imageId,
                               Price: p.price
                           }})
                   };
               });
               $http.post('/api/categories/', cats)
                   .success(function(data){
                       var categories = data.select(function(item){return new category(item);});
                       deferred.resolve(categories);
                   })
                   .error(function(error){
                       deferred.reject(error);
                   });

               return deferred.promise;
           }
       }
    });

    function category(item){
        var self = this;

        self.id = item.Id;
        self.name = item.Name;
        self.image = isNullOrEmpty(item.Image)
            ? null
            :{key: item.Image.Key, bigUrl: item.Image.BigUrl, smallUrl: item.Image.SmallUrl};
        self.price = item.Price;
        self.products = isNullOrEmpty(item.Products)
            ? []
            : item.Products.select(function(p){return new product(p);});
    }

    function product(item){
        var self = this;

        self.id = item.Id;
        self.name = item.Name;
        self.price = item.Price;
        self.imageId = item.ImageId;
        self.imageUrl = item.ImageUrl;
    }
});
