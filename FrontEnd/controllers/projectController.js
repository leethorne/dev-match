app.controller("projectController", function ($scope, $state, $stateParams, projectService, userService) {

  $scope.currentUser = userService.getCurrentUser();

  projectService.getProjects()
      .then(function (response) {
          console.log(response);
          $scope.projects = response.data;
      }, function (error) {
          console.log(error);
          alert("Error: Something went wrong. No Project Info Available")
      })

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

  $scope.addProject = function () {
      var skillsArray = []

      // Looping through Seeking Skills array and setting isSeeking = True
      for(var i = 0; i< $scope.project.seekingSkills.length; i++) {
          $scope.project.seekingSkills[i].isSeeking = true;
          skillsArray.push($scope.project.seekingSkills[i])
      }

      var added = null;

      // Looping through Using Skills array and setting isUsing = True
      for (var i = 0; i < $scope.project.usingSkills.length; i++) {
          added = false
          for(var j = 0; j < skillsArray.length; j++) {
              if($scope.project.usingSkills[i].name == skillsArray[j].name) {
                  skillsArray[j].isUsing = true;
                  added = true;
              }
          }

          if(!added) {
              $scope.project.usingSkills[i].isUsing = true;
              skillsArray.push($scope.project.usingSkills[i])
          }
      }

      console.log($scope.project)
      console.log(skillsArray);

      projectService.addProject($scope.project)
          .then(function (response) {
              console.log("ADD PROJECT SUCCESSFUL: ", response)

              //ADDING USER TO PROJECT(user service)
              userService.updateUserProj(currentUser.id, response.data.id)
                  .then(function (response) {
                      console.log("ADD USER SUCCESSFUL: ", response)

                  }, function (error) {
                      console.log("error updating user on proj: ", error);
                      alert("Error: Something went wrong. Project user cannot be added.")
                  });

              //ADDING TECH TO PROJECT
              skillsArray.forEach(function(element) {
                  projectService.updateProjTech(response.data.id, element.name, element.isSeeking, element.isUsing)
                      .then(function (response) {
                          console.log("ADD TECH TO PROJ - SUCCESSFUL: ", response)

                      }, function (error) {
                          console.log("error updating seeking tech: ", error)
                          alert("Error: Something went wrong. Project technology cannot be added.")
                      })
              });

              $timeout(function () {
                  $state.go("projects", { id: $scope.project.id });
              }, 3000);

            //   $state.go('projects', {}, { reload: 'projects'}) ---- causing issues for id moving between states?

          }, function (error) {
            console.log("error to add proj: ", error)
            alert("Error: Something went wrong. Project was not added")
          })
      }

  $scope.updateProject = function () {
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

          //ADDING TECH TO PROJECT
          skillsArray.forEach(function (element) {
              projectService.updateProjTech($scope.project.id, element.name, element.isSeeking, element.isUsing)
                  .then(function (response) {
                      console.log("ADD TECH TO PROJ - SUCCESSFUL: ", response)
                  }, function (error) {
                      console.log("error updating seeking tech: ", error)
                      alert("Error: Something went wrong. Project technology cannot be updated.")
                  })
          });

      projectService.updateProject($stateParams.id, $scope.project)
          .then(function (response) {
            console.log(response)

            $timeout(function () {
                $state.go("projects", { id: $scope.project.id });
            }, 3000);

          //   $state.go("project", { id: $scope.project.id })

          },
          function (error) {
            console.log(error)
            alert("Error: Something went wrong. Project cannot be updated.")
          })
      }

      $scope.deleteProject = function () {
          projectService.deleteProject($stateParams.id)
              .then(function (response) {
                  console.log("deleted: ", response)
                  $state.go("projects")
              }, function (error) {
                  console.log(error);
                  alert("Error: Something went wrong. Project cannot be deleted.")
              })
      }

      projectService.getNews()
          .then(function (response) {
              console.log(response);
              console.log(response.data.articles);
              $scope.news = response.data.articles;
          }, function (error) {
              console.log(error);
              alert("Error: Something went wrong. Tech News not currently available.")
          })

  $(".create-project").hide();

//   $scope.checkOutProj = function() {
//       console.log($scope.project)
//   }

  $scope.availableTechnologies = [
      {name: "BootStrap", isSeeking: false, isUsing: false},
      {name: "JavaScript", isSeeking: false, isUsing: false},
      {name: "AngularJS", isSeeking: false, isUsing: false},
      {name: "C#", isSeeking: false, isUsing: false},
      {name: "ASP.NET Core", isSeeking: false, isUsing: false},
      {name: "Node.js", isSeeking: false, isUsing: false},
      {name: "CSS", isSeeking: false, isUsing: false},
      {name: "MySQL", isSeeking: false, isUsing: false},
      {name: "React", isSeeking: false, isUsing: false},
      {name: "Ojective-C", isSeeking: false, isUsing: false},
      {name: "jQuery", isSeeking: false, isUsing: false},
      {name: "MongoDB", isSeeking: false, isUsing: false},
      {name: "C / C++", isSeeking: false, isUsing: false},
      {name: "Ruby", isSeeking: false, isUsing: false},
      {name: "SpringMVC", isSeeking: false, isUsing: false},
      {name: "Java", isSeeking: false, isUsing: false},
      {name: "PHP", isSeeking: false, isUsing: false},
      {name: "AWS", isSeeking: false, isUsing: false},
      {name: "Azure", isSeeking: false, isUsing: false},
      {name: "Entity Framework Core", isSeeking: false, isUsing: false},
      {name: "SQL Server", isSeeking: false, isUsing: false},
      {name: "Dapper", isSeeking: false, isUsing: false},
      {name: "NancyFX", isSeeking: false, isUsing: false},
      {name: ".Net Core 2.0", isSeeking: false, isUsing: false},
      {name: "C#", isSeeking: false, isUsing: false},
      {name: "Xcode", isSeeking: false, isUsing: false},
      {name: "Swift", isSeeking: false, isUsing: false},
      {name: "Django", isSeeking: false, isUsing: false},
      {name: "Ajax", isSeeking: false, isUsing: false},
      {name: "Python" , isSeeking: false, isUsing: false},
      {name: "HTML", isSeeking: false, isUsing: false}
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
