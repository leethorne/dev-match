app.controller("projectController", function ($scope, $state, $stateParams, projectService, userService) {

    // $(".tags").select2({ tags: true, width: '100%' }); //jQuery box

    if ($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
      projectService.getProjectById($stateParams.id, function (project) {
        $scope.project = project;
        console.log($scope.project);
      })
    }
    else {
      projectService.getProjectById($stateParams.id, function (project) {
        $scope.project = project;
        console.log($scope.project);
      })
    }

    projectService.getProjects()
        .then(function (response) {
            console.log(response);
            $scope.projects = response.data;
        }, function (error) {
            console.log(error);
            //handle error messages here to the user
        })

    $scope.addProject = function () {
        projectService.addProject($scope.project)
            .then(function (response) {
                $scope.project = response.data;
                console.log("adding: ", $scope.project)
                userService.updateUserProj($stateParams.id, $scope.project.id)
                    .then(function (response) {
                        console.log(response)
                    }, function (error) {
                        console.log(error);
                        //do something here to alert user of fail 
                    })
            }, function (error) {
              console.log(error)
              //make error message for user if failed
            })
        }

    $scope.updateProject = function () {
        projectService.updateProject($stateParams.id, $scope.project)
            .then(function (response) {
              console.log(response)
              $state.go("project", { id: $scope.project.id })
            },
            function (error) {
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

    $(".create-project").hide();

    $scope.checkOutProj = function() {
        console.log($scope.project)
    }

    $scope.availableTechnologies = [
        {id: 0, name: "BootStrap"},
        {id: 1, name: "JavaScript"},
        {id: 2, name: "AngularJS"},
        {id: 3, name: "C#"},
        {id: 4, name: "ASP.NET Core"},
        {id: 5, name: "Node.js"},
        {id: 6, name: "CSS"},
        {id: 7, name: "MySQL"},
        {id: 8, name: "React"},
        {id: 9, name: "Ojective-C"},
        {id: 10, name: "jQuery"},
        {id: 11, name: "MongoDB"},
        {id: 12, name: "C / C++"},
        {id: 13, name: "Ruby"},
        {id: 14, name: "SpringMVC"},
        {id: 15, name: "Java"},
        {id: 16, name: "PHP"},
        {id: 17, name: "AWS"},
        {id: 18, name: "Azure"},
        {id: 19, name: "Entity Framework Core"},
        {id: 20, name: "SQL Server"},
        {id: 21, name: "Dapper"},
        {id: 22, name: "NancyFX"},
        {id: 23, name: ".Net Core 2.0"},
        {id: 24, name: "C#"},
        {id: 25, name: "Xcode"},
        {id: 26, name: "Swift"},
        {id: 27, name: "Django"},
        {id: 28, name: "Ajax"},
        {id: 29, name: "Python" },
        {id: 30, name: "HTML"}
    ]


    // collapse create project form
    $(".add-proj").click(function () {
        $(".create-project").slideToggle(500);
        if ($(".add-proj").text() == "+") {
            $(".add-proj").html("-")
        } else {
            $(".add-proj").text("+")
        }
    });

    // $scope.updateProjTech = function() {
    //     projectService.updateProjTech($stateParams.id, $scope.techName, $scope.isSeeking)
    //     .then(function(response) {
    //         console.log("updating: ", response)
    //     }, function(error) {
    //         console.log(error)
    //     })

    projectService.getNews()
        .then(function (response) {
            console.log(response);
            console.log(response.data.articles);
            $scope.news = response.data.articles;
        }, function (error) {
            console.log(error);
            //handle error messages here to the user
        });

    // input fields 
    (function () {
        // trim polyfill : https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/Trim
        if (!String.prototype.trim) {
            (function () {
                // Make sure we trim BOM and NBSP
                var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
                String.prototype.trim = function () {
                    return this.replace(rtrim, '');
                };
            })();
        }

        [].slice.call(document.querySelectorAll('input.input__field')).forEach(function (inputEl) {
            // in case the input is already filled..
            if (inputEl.value.trim() !== '') {
                classie.add(inputEl.parentNode, 'input--filled');
            }

            // events:
            inputEl.addEventListener('focus', onInputFocus);
            inputEl.addEventListener('blur', onInputBlur);
        });

        function onInputFocus(ev) {
            classie.add(ev.target.parentNode, 'input--filled');
        }

        function onInputBlur(ev) {
            if (ev.target.value.trim() === '') {
                classie.remove(ev.target.parentNode, 'input--filled');
            }
        }
    })();
});
