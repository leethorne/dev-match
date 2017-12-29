app.service("technologyService", function ($http, $state) {

    this.getTechnologies = function () {
      return $http.get(serverLink + "technologies")
    }

    this.getTechnologyById = function (id, cb) {
        if (id == null || id == undefined || id == "") {
          var technology = {};
          cb(technology)
        }
        else {
        $http.get(serverLink + "technologies/" + id)
          .then(function (repsonse) {
            console.log(response)
            cb(response.data)
          },
          function (error) {
            console.log(error)
          })
        }
    }

    this.addTechnology = function (technology) {
      return $http.post(serverLink + "technologies/" + project)
    }

    this.updateTechnology = function (id, technology) {
      return $http.put(serverLink + "technologies/" + id, project)
    }

    this.deleteTechnology = function (id) {
      return $http.delete(serverLink + "technologies/" + id)
    }

});
