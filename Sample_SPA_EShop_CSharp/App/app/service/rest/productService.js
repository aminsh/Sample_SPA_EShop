define(['app'],function(app){
    app.register.factory('productService',function($http, $q){
        return{
            get: function(param){
                var deferred = $q.defer();
                debugger;
                return $http.get('/api/products',
                   {
                       params: param,
                       headers: {'Content-Type': 'application/json'}
                   })
                    .success(function(data){
                    debugger;
//                        var products = data.select(function(item){return new product(item);});
                        deferred.resolve(data);
                    })
                    .error(function(error){
                        deferred.reject(error);
                    });

                return deferred.promise;
            },
            getById: function(id){
                var deferred = $q.defer();
                return $http.get('/api/products/' + id)
                    .success(function(result){
                        deferred.resolve(result)
                    })
                    .error(function(error){
                        deferred.reject(error)
                    });

                return deferred.promise;
            }
        }
    });
});
