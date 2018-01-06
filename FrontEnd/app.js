var app = angular.module("DevMatchApp", ["ui.router", "angularCSS", "ngMap", "ui.select", "ngSanitize"])

app.config(function($stateProvider, $urlRouterProvider) {

  $urlRouterProvider.otherwise("/");

  $stateProvider
    .state("home", {
      url: "/",
      templateUrl: "./views/home.html",
      controller: "masterController"
    })

    // USERS
    .state("users", { // users index
      url: "/users",
      templateUrl: "./views/users.html",
      controller: "masterController"
    })
        .state("usersCreate", { // create user
          url: "/users/new",
          templateUrl: "./views/user-form.html",
          controller: "masterController"
        })
        .state("user", { //show - user profile
          url: "/users/:id",
          templateUrl: "./views/user.html",
          controller: "masterController"
        })
        .state("userUpdate", { // update user
          url: "/users/:id/edit",
          templateUrl: "./views/user-form.html",
          controller: "masterController",
          css: "./css/update-user.css"
        })

    // PROJECTS
    .state("projects", { // index
      url: "/projects",
      templateUrl: "./views/projects.html",
      controller: "masterController"
    })
        // .state("projectsCreate", { // create
        //   url: "/projects/new",
        //   templateUrl: "./views/project-form.html",
        //   controller: "projectController"
        // })
        .state("project", { // show
          url: "/projects/:id",
          templateUrl: "./views/project.html",
          controller: "masterController"
        })
        .state("projectUpdate", { // update
          url: "/projects/:id/edit",
          templateUrl: "./views/project-form.html",
          controller: "masterController",
          css: "./css/update-user.css"
        })

})
