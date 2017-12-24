var app = angular.module("DevMatchApp", ["ui.router", "ngMap"])

app.config(function($stateProvider, $urlRouterProvider) {

  $urlRouterProvider.otherwise("/");
  
  $stateProvider
    .state("app", {
      abstract: true,
      url: '',
      templateUrl: "./views/app-container.html",
      controller: "homeController"
    })
    .state("app.home", {
      url: "/",
      templateUrl: "./views/home.html",
      controller: "userController"
    })
    // users
    .state("app.users", { // users index
      url: "/users",
      templateUrl: "./views/users.html",
      controller: "userController"
    })
      .state("app.usersCreate", { // create user
        url: "/users/new",
        templateUrl: "./views/user-form.html",
        controller: "userController"
      })
      .state("app.user", { //show - user profile
        url: "/users/:id",
        templateUrl: "./views/user.html",
        controller: "userController"
      })
      .state("app.userUpdate", { // update user
        url: "/users/:id/edit",
        templateUrl: "./views/user-form.html",
        controller: "userController"
      })
    // projects
    .state("app.projects", { // index 
      url: "/projects",
      templateUrl: "./views/projects.html",
      controller: "projectController"
    })
      // .state("projectsCreate", { // create
      //   url: "/projects/new",
      //   templateUrl: "./views/project-form.html",
      //   controller: "projectController"
      // })
      .state("app.project", { // show
        url: "/projects/:id",
        templateUrl: "./views/project.html",
        controller: "projectController"
      })
      .state("app.projectUpdate", { // update
        url: "/projects/:id/edit",
        templateUrl: "./views/project-form.html",
        controller: "projectController"
      })
}) 