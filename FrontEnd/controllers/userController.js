app.controller("userController", function ($scope, $state, $stateParams, userService, projectService,  NgMap) {

    //jQuery Box
    // $(".tags").select2({ tags: true, width: '100%' });

    $scope.errorMessage = false;

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
        projectService.addProject($scope.project)
            .then(function (response) {
                $scope.project = response.data;
                console.log("adding proj: ", $scope.project)
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
     
});