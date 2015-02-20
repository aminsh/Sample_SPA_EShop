define(['app'],function(app){
    app.register.directive('modal',function(){
        return{
            restrict: 'E',
            template: '',
            replace: true,
            scope:{
                key: '=',
                afterupload:'&'
            },
            transclude: true,
            link: function(scope, element, attrs){

            }
        }
    });
});
