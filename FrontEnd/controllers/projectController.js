app.controller("projectController", function($scope, $state,$stateParams, projectService) {

    projectService.getProjects()
    .then(function(response) {
        console.log(response);
        //set $scope.projects to something here once we can get data
    }, function(error) {
        console.log(error);
        //handle error messages here to the user
    })

    if($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
        projectService.getProjectById($stateParams.id, function(project) {
            $scope.project = project;
            console.log($scope.project);
        })
    } else {
        projectService.getProjectById($stateParams.id, function(project) {
            $scope.project = project;
            console.log($scope.project);
        })
    }

    $scope.addProject = function() {
        projectService.addProject($scope.project)
        .then(function(reponse) {
            $scope.project = response.data;
            console.log($scope.project)
            //$state.go to porject wall?
        }, function(error) {
            console.log(error)
        })
    }

    $scope.updateProject = function() {
        projectService.updateProject($stateParams.id, $scope.project)
        .then (function(response) {
            console.log(response)
            //set $scope.project to reponse data? 
            //state.go to project page? 
        }, function(error) {
            console.log(error)
        })
    }

    $scope.deleteProject = function() {
        projectService.deleteProject($stateParams.id)
        .then(function(response) {
            $state.go("projects")
        }, function(error) {
            console.log(error);
            //make an error message for the user 
        })
    }
}); 