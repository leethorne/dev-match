app.controller("projectController", function ($scope, $state, $stateParams, projectService) {

    //jquery box
    $(".tags").select2({
        tags: true,
        width: '100%'
    });

    //     console.log("tech: ", $scope.projectSeekingTechnology);
    // //attempting to bind data
    // $scope.ProjTech = [];
    //     $scope.seekingTechnologies = function() {
    //         if($scope.projectSeekingTechnology == technology.Name) {
    //             console.log("tech fun: ", $scope.projectSeekingTechnology)
    //             $scope.ProjTech.push(projectSeekingTechnology);
    //         }
    //     }

    // collapse create project form
    $(document).ready(function () {
        $(".add-proj").click(function () {
            $(".create-project").slideToggle(500);
            if ($(".add-proj").text() == "+") {
                $(".add-proj").html("-")
            } else {
                $(".add-proj").text("+")
            }
        });
    });

    projectService.getProjects()
        .then(function (response) {
            console.log(response);
            $scope.projects = response.data;
        }, function (error) {
            console.log(error);
            //handle error messages here to the user
        })

    if ($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
        projectService.getProjectById($stateParams.id, function (project) {
            $scope.project = project;
            console.log($scope.project);
        })
    } else {
        projectService.getProjectById($stateParams.id, function (project) {
            $scope.project = project;
            console.log($scope.project);
        })
    }

    $scope.addProject = function () {
        projectService.addProject($scope.project)
            .then(function (reponse) {
                $scope.project = response.data;
                console.log($scope.project)
                $state.go("projects")
            }, function (error) {
                console.log(error)
                //make error message for user if failed
            })
    }

    $scope.updateProject = function () {
        projectService.updateProject($stateParams.id, $scope.project)
            .then(function (response) {
                console.log(response)
                $state.go("project", {
                    id: $scope.project.id
                })
            }, function (error) {
                console.log(error)
                //error msg here to user 
            })
    }

    $scope.deleteProject = function () {
        projectService.deleteProject($stateParams.id)
            .then(function (response) {
                console.log("deleted: ", response)
                $state.go("projects")
            }, function (error) {
                console.log(error);
                //make an error message for the user 
            })
    }

    projectService.getNews()
        .then(function (response) {
            console.log(response);
            console.log(response.data.articles);
            $scope.news = response.data.articles;
        }, function (error) {
            console.log(error);
            //handle error messages here to the user
        })

});