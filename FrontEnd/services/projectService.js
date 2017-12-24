app.service("projectService", function($http, $state) {
  
    this.getProjects = function() {
        return $http.get(serverLink + "projects")
    }

    this.getProjectById = function(id, cb) {
        if (id == null || id == undefined || id == "") {
            var project = {};
            cb(project)
        } else {
            $http.get(serverLink + "projects/" + id)
            .then (function(repsonse) {
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
});