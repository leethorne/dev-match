'use strict';
app.service("projectService", function($http, $state) {
  
    this.getProjects = function() {
        return $http.get(serverLink + "projects")
    }

    this.getProjectById = function(id, cb) {
        if (id == null || id == undefined || id == "") {
            var project = {
                usingSkills: [],
                seekingSkills: [],
                name: "",
                description: "",
                status: "",
                desiredTeamSize: null
            };
            cb(project)
        } else {
            $http.get(serverLink + "projects/" + id)
            .then (function(response) {
                console.log(response)
                cb(response.data)
            }, function(error) {
                console.log(error)
            })
        }
    }

    this.addProject = function(project) {
        return $http.post(serverLink + "projects/" + project)
    }

    this.updateProject = function(id, project) {
        return $http.put(serverLink + "projects/" + id, project)
    }

    this.deleteProject = function(id) {
        return $http.delete(serverLink + "projects/" + id)
    }

    this.updateProjTech = function(id, techName, isSeeking) {
        return $http.put(serverLink + "projects/" + id + "/addtechnology?techName=" + techName + "&isSeeking=" + isSeeking)
    }

    this.getNews = function() {
        return $http.get("https://newsapi.org/v2/top-headlines?category=technology&language=en&apiKey=8b44e7a550f1436bbd9a0961cb9c838c")
    }
});