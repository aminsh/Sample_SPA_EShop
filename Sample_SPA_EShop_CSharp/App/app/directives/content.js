define(['app'], function(app){
    app.directive('content', function(){
        return {
          restrict: 'E',
          template: '<div ng-transclude ' +
              'style="padding-left: 20%;padding-right: 20%">' +
              '</div>',
          transclude: true,
          link: function($scope){

          }
        };
    });
});
