define(['app', 'service/breezeFactory'], function(app) {
    app.register.controller('homeController', ['$scope','dataContext','$q', function ($scope,dataContext,$q) {
        //alert('controller loaded ....');

var context = dataContext;

        breeze.EntityQuery.from("Users").toType('User')
            .using(context).execute()
            .then(function(data){

            });

        $scope.title = "Home Page";
        $scope.name = 'amin';
        $scope.lastname = 'sheikhi';

        $scope.people = [
            {id: 1, name: 'sheikhi'}
        ];

        function save(){
            $scope.people.forEach(function(item){
               item.fullName = item.id + ' ' + item.name;
            });
        }

        $scope.Person = {
            fname: 'amin', lname: 'sheikhi', fullname: function () {
                return $scope.Person.fname + ' ' + $scope.Person.lname;
            }
        };

        $scope.Person.fullNameX = $scope.Person.fullname;
        $scope.Person.fullname = '';
        $scope.$watch($scope.Person.fullNameX, function (newValue) {
            $scope.Person.fullname = $scope.Person.fullNameX();
        });
        //$scope.$watch('Person.fname', changeName);
        //$scope.$watch('Person.lname', changeName);

        //Object.defineProperty($scope.Person, 'fullName', {
        //    get: function () {
        //        return $scope.Person.fname + ' ' + $scope.Person.lname;
        //    }
        //});

        //function changeName() {
        //    $scope.Person.fullname = $scope.Person.fname + ' ' + $scope.Person.lname;
        //}

        window.Person = $scope.Person;

    }]);
});