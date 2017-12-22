app.controller("userController", function($scope, $state, $stateParams, userService) {
  
    userService.getUsers()
    .then(function(response){
        console.log(response.data)
        //do something with route data to display. set equal to $scope.something to ng-repeat
    }, function(error){
        console.log(error);
        //do something else here to alert user of a fail
    })

    if($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
        $scope.submitButton = true;
        $scope.heading = "Create Your DevMatch Profile!"

        userService.getUserById($stateParams.id, function (user) {
            $scope.user = user;
            console.log($scope.user);
        })
    } else {
        $scope.submitButton = false;
        $scope.heading = "Update Your DevMatch Profile!";

        userService.getUserById($stateParams.id, function(user) {
            $scope.user = user;
            console.log($scope.user);
        })
    }

    $scope.addUser = function() {
        userService.addUser($scope.user)
        .then(function(response) {
            console.log(response.data);
            //do something with route data to display. set equal to $scope.something to ng-repeat
            //$state.go to profile page or dev map?
        }, function(error) {
            console.log(error)
            //do something here to display error msg
        })
    }

    $scope.updateUser = function() {
        userService.updateUser($stateParams.id, $scope.user)
        .then(function (response) {
            console.log(response.data);
            //once we get results set the $scope.user to response.data
            //state.go to profile/"my account" page?
        }, function(error) {
            console.log(error)
            //insert error message here for users
        })
    }

    $scope.deleteUser = function() {
        userService.deleteUser($stateParams.id)
        .then(function(response) {
            $state.go("home");
        }, function(error) {
            console.log(error)
            //set error message here for users to see
        })
    }

}); 

