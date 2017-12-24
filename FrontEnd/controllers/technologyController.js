app.controller("technologyController", function ($scope, $state, $stateParams, userService) {

    technologyService.getTechnologies()
        .then(function (response) {
            console.log(response);
            $scope.technologies = response.data;
        }, function (error) {
            console.log(error);
            //handle error messages here to the user
        })

    if ($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
        technologyService.getTechnologyById($stateParams.id, function (technology) {
            $scope.technology = technology;
            console.log($scope.technology);
        })
    } else {
        technologyService.getTechnologyById($stateParams.id, function (technology) {
            $scope.technology = technology;
            console.log($scope.technology);
        })
    }

    $scope.addTechnology = function () {
        technologyService.addTechnology($scope.technology)
            .then(function (reponse) {
                $scope.technology = response.data;
                console.log($scope.technology)
                //$state.go to what page - user/post?
            }, function (error) {
                console.log(error)
                //make error message for user if failed
            })
    }

    $scope.updateTechnology = function () {
        technologyService.updateTechnology($stateParams.id, $scope.technology)
            .then(function (response) {
                console.log(response)
                //state.go to project wall or user page? 
            }, function (error) {
                console.log(error)
                //error msg here to user 
            })
    }

    $scope.deleteTechnology = function () {
        projectService.deleteProject($stateParams.id)
            .then(function (response) {
                //$state.go() to what page? 
            }, function (error) {
                console.log(error);
                //make an error message for the user 
            })
    }
    
});