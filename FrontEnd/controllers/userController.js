app.controller("userController", function($scope, $state, $stateParams, userService) {
    $(".tags").select2({ tags: true, width: '100%' }); //jquery box

    $scope.errorMessage = false;

    userService.getUsers()
        .then(function (response) {
            console.log(response.data);
            // $scope.users = response.data;
            //do something with route data to display. set equal to $scope.something to ng-repeat
        }, function (error) {
            console.log(error);
            //do something else here to alert user of a fail
        })

    $scope.currentUser = userService.getCurrentUser();

    if ($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
        $scope.submitButton = true;
        $scope.heading = "Create Your DevMatch Profile!"

        userService.getUserById($stateParams.id, function (user) {
            $scope.user = user;
            console.log($scope.user);
        })
    } else {
        $scope.submitButton = false;
        $scope.heading = "Update Your DevMatch Profile!";

        userService.getUserById($stateParams.id, function (user) {
            $scope.currentUser = user;
            console.log($scope.currentUser);
        })
    }

    $scope.addUser = function () {
        userService.addUser($scope.user)
            .then(function (response) {
                console.log(response.data);
                $scope.currentUser = response.data
                $state.go("user", {id: $scope.currentUser.id})
            }, function (error) {
                console.log("you have an error: ", error)
                //do something here to display error msg
            })
    }

    $scope.updateUser = function () {
        userService.updateUser($stateParams.id, $scope.user)
            .then(function (response) {
                console.log(response.data);
                //once we get results set the $scope.user to response.data
                //state.go to profile/"my account" page?
            }, function (error) {
                console.log(error)
                //insert error message here for users
            })
    }

    $scope.deleteUser = function () {
        userService.deleteUser($stateParams.id)
            .then(function (response) {
                $state.go("home");
            }, function (error) {
                console.log(error)
                //set error message here for users to see
            })
    }

    $scope.login = function () {
        userService.login($scope.user, function(message) {
            $scope.errorMessage = message;
        })
    }

    // collapse create project form
    $('.add-proj').click(function () {
        $addProj = $(this);
        $projForm = $('.create-project');
        $projForm.slideToggle(500, function () {
            $addProj.text(function () {
                return $addProj.is(':visible') ? '-' : '+';
            });
        });
    });

    // collapse login form
    $('.login').click(function () {
        console.log("clicked");
        $addProj = $(this);
        $projForm = $('.login-form');
        $projForm.slideToggle(500);
    });

    // profile pic preview
    $(document).ready(function () {
        $.uploadPreview({
            input_field: "#image-upload",
            preview_box: "#image-preview",
            label_field: "#image-label"
        });
    });
});

