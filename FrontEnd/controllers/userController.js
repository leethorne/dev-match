app.controller("userController", function ($scope, $state, $stateParams, userService, projectService,  NgMap) {

    $scope.errorMessage = false;
    $scope.currentUser = userService.getCurrentUser();

    $scope.availableTechnologies = [
        { name: "BootStrap", isSeeking: false, isUsing: false },
        { name: "JavaScript", isSeeking: false, isUsing: false },
        { name: "AngularJS", isSeeking: false, isUsing: false },
        { name: "C#", isSeeking: false, isUsing: false },
        { name: "ASP.NET Core", isSeeking: false, isUsing: false },
        { name: "Node.js", isSeeking: false, isUsing: false },
        { name: "CSS", isSeeking: false, isUsing: false },
        { name: "MySQL", isSeeking: false, isUsing: false },
        { name: "React", isSeeking: false, isUsing: false },
        { name: "Ojective-C", isSeeking: false, isUsing: false },
        { name: "jQuery", isSeeking: false, isUsing: false },
        { name: "MongoDB", isSeeking: false, isUsing: false },
        { name: "C / C++", isSeeking: false, isUsing: false },
        { name: "Ruby", isSeeking: false, isUsing: false },
        { name: "SpringMVC", isSeeking: false, isUsing: false },
        { name: "Java", isSeeking: false, isUsing: false },
        { name: "PHP", isSeeking: false, isUsing: false },
        { name: "AWS", isSeeking: false, isUsing: false },
        { name: "Azure", isSeeking: false, isUsing: false },
        { name: "Entity Framework Core", isSeeking: false, isUsing: false },
        { name: "SQL Server", isSeeking: false, isUsing: false },
        { name: "Dapper", isSeeking: false, isUsing: false },
        { name: "NancyFX", isSeeking: false, isUsing: false },
        { name: ".Net Core 2.0", isSeeking: false, isUsing: false },
        { name: "C#", isSeeking: false, isUsing: false },
        { name: "Xcode", isSeeking: false, isUsing: false },
        { name: "Swift", isSeeking: false, isUsing: false },
        { name: "Django", isSeeking: false, isUsing: false },
        { name: "Ajax", isSeeking: false, isUsing: false },
        { name: "Python", isSeeking: false, isUsing: false },
        { name: "HTML", isSeeking: false, isUsing: false }
    ]

    userService.getUsers()
        .then(function (response) {
            console.log(response.data);
            $scope.users = response.data;
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
            $scope.user = user;
            console.log($scope.user);
        })
    }

    $scope.addUser = function () {
        console.log("user before function: ", $scope.user)
        console.log("image: ", $scope.user.image)

        userService.addUser($scope.user)
            .then(function (response) {
                // $scope.user = response.data;
                console.log("userrrr: ", response.data)
                console.log("image: ", response.data.image)
                
                //ADDING TECH SKILLS TO USER 
                    userService.updateUserTech(response.data.id, $scope.techName)
                        .then(function (response) {
                            console.log(response)
                        }, function (error) {
                            console.log(error);
                            //do something here to alert user of fail 
                        })
                
                $state.go("user", {
                    id: $scope.user.id
                });
            }, function (error) {
                console.log("you have an error: ", error)
                //do something here to display error msg
            })
    }

    $scope.updateUser = function () {
        userService.updateUser($stateParams.id, $scope.user)
            .then(function (response) {
                console.log(response.data);
                $scope.user = response.data;
                $state.go("user", {
                    id: $scope.user.id
                });
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

    $scope.addProject = function () {
        var skillsArray = []

        // Looping through Seeking Skills array and setting isSeeking = True
        for (var i = 0; i < $scope.project.seekingSkills.length; i++) {
            $scope.project.seekingSkills[i].isSeeking = true;
            skillsArray.push($scope.project.seekingSkills[i])
        }

        var added = null;

        // Looping through Using Skills array and setting isUsing = True
        for (var i = 0; i < $scope.project.usingSkills.length; i++) {
            added = false
            for (var j = 0; j < skillsArray.length; j++) {
                if ($scope.project.usingSkills[i].name == skillsArray[j].name) {
                    skillsArray[j].isUsing = true;
                    added = true;
                }
            }
            if (!added) {
                $scope.project.usingSkills[i].isUsing = true;
                skillsArray.push($scope.project.usingSkills[i])
            }
        }

        console.log($scope.project)
        console.log(skillsArray);

        projectService.addProject($scope.project)
            .then(function (response) {
                // $scope.project = response.data;
                console.log("ADD proj SUCCESS: ", response)

                //adding user to project
                userService.updateUserProj($stateParams.id, response.data.id)
                    .then(function (response) {
                        console.log("USER ADDED: ", response)
                    }, function (error) {
                        console.log("error adding use to proj: ", error);
                        //do something here to alert user of fail 
                    })


                //ADDING TECH TO PROJECT
                skillsArray.forEach(function (element) {
                    projectService.updateProjTech(response.data.id, element.name, element.isSeeking, element.isUsing)
                        .then(function (response) {
                            console.log("ADD TECH TO PROJ - SUCCESSFUL: ", response)
                        }, function (error) {
                            console.log("error updating seeking tech: ", error)
                            //alert here 
                        })
                });

                $state.go('user', {}, { reload: 'user'})
            }, function (error) {
                console.log("error adding proj: ", error)
                //make error message for user if failed
            })
    }

    $scope.updateUserProj = function () {
        userService.updateUserProj($stateParams.id, $scope.projId)
            .then(function (response) {
                console.log(response)
            }, function (error) {
                console.log(error);
                //do something here to alert user of fail 
            })
    }

    $scope.updateUserTech = function () {
        userService.updateUserTech($stateParams.id, $scope.techName)
            .then(function (response) {
                console.log(response)
            }, function (error) {
                console.log(error);
                //do something here to alert user of fail 
            })
    }

    $scope.login = function () {
        userService.login($scope.user, function (message) {
            $scope.errorMessage = message;
        })
    }

    $scope.logout = function () {
        userService.logout($scope.currentUser);
        $state.go("home");
    }

    // user page --> user form
    $scope.editUser = function () {
        userService.editUser($stateParams.id)
    }

    // collapse login form
    $('.login').click(function () {
        console.log("clicked");
        $addProj = $(this);
        $projForm = $('.login-form');
        $projForm.slideToggle(500);
    });

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

    // profile pic preview
    $(document).ready(function () {
        $.uploadPreview({
            input_field: "#image-upload",
            preview_box: "#image-preview",
            label_field: "#image-label"
        });
    });

    // input fields 
    (function() {
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
        };

        function onInputBlur(ev) {
            if (ev.target.value.trim() === '') {
                classie.remove(ev.target.parentNode, 'input--filled');
            }
        };
    })();


     //API functionality -- get map from the address of the users
     $scope.googleMapsUrl = "https://maps.googleapis.com/maps/api/js?key=AIzaSyD7RhAqkBYU5QS2Z75F-0jujx2e8bKJ-n4";
     
         NgMap.getMap().then(function (map) {
             console.log(map.getCenter());
             console.log('markers', map.markers);
         });
     
         //default zoom and center for usa on page load
         $scope.MapCenter = "38.457791, -99.641980"
         $scope.MapZoom = 5;
     
         //enact click events to trigger zoom over city 
         $scope.zoomCitySearch = function () {
             cityKey = $scope.selectedCity;
     
             switch (cityKey) {
                 case 'Long Beach':
                     $scope.MapCenter = "33.757120, -118.126273";
                     $scope.MapZoom = 15;
                     break;
                 case 'Brooklyn':
                     $scope.MapCenter = "40.691358, -73.914062"
                     $scope.MapZoom = 15;
                     break;
                 default:
                     $scope.MapCenter = "38.457791, -99.641980"
                     $scope.MapZoom = 5;
             }
        }
       
    // $scope.postImage = function() {
    //     $scope.image = $scope.scope.uploadme.substr(22);
    //     // console.log($scope.image);

    //     userService.postImage($scope.image)
    //         .then(function(response) {
    //             console.log(response);
    //         }, function(error) {
    //             console.log(error);
    //         })
    // }
    
});