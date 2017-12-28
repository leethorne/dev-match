var app = angular.module("DevMatchApp", ["ui.router", "angularCSS", "ngMap", "ui.select", "ngSanitize"])

app.config(function($stateProvider, $urlRouterProvider) {

  $urlRouterProvider.otherwise("/");

  $stateProvider
    .state("home", {
      url: "/",
      templateUrl: "./views/home.html",
      controller: "userController"
    })
    // users
    .state("users", { // users index
      url: "/users",
      templateUrl: "./views/users.html",
      controller: "userController"
    })
      .state("usersCreate", { // create user
        url: "/users/new",
        templateUrl: "./views/user-form.html",
        controller: "userController"
      })
      .state("user", { //show - user profile
        url: "/users/:id",
        templateUrl: "./views/user.html",
        controller: "userController"
      })
      .state("userUpdate", { // update user
        url: "/users/:id/edit",
        templateUrl: "./views/user-form.html",
        controller: "userController",
        css: "./css/update-user.css"
      })
    // projects
    .state("projects", { // index
      url: "/projects",
      templateUrl: "./views/projects.html",
      controller: "projectController"
    })
      // .state("projectsCreate", { // create
      //   url: "/projects/new",
      //   templateUrl: "./views/project-form.html",
      //   controller: "projectController"
      // })
      .state("project", { // show
        url: "/projects/:id",
        templateUrl: "./views/project.html",
        controller: "projectController"
      })
      .state("projectUpdate", { // update
        url: "/projects/:id/edit",
        templateUrl: "./views/project-form.html",
        controller: "projectController",
        css: "./css/update-user.css"
      })


})
