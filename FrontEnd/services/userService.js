app.service("userService", function ($http, $state) {

    var that = this;

    this.getUsers = function () {
      return $http.get(serverLink + "users");
    }

    this.getUserById = function (id, cb) {
      if (id == null || id == undefined || id == "") {
        var user = {};
        cb(user);
      }
      else {
        $http.get(serverLink + "users/" + id)
          .then(function (response) {
            console.log(response)
            cb(response.data)
          }, function (error) {
            console.log(error)
          })
      }
    }

    this.registerUser = function (user) { //register new user
      return $http.post(serverLink + "users/", user)
    }

    this.updateUser = function (id, user) {
      return $http.put(serverLink + "users/" + id, user)
    }

    this.deleteUser = function (id) {
      return $http.delete(serverLink + "users/" + id);
    }

    this.updateUserProj = function(id, projId) {
      return $http.put(serverLink + "users/" + id + "/addproject?projId=" + projId);
    }

    this.updateUserTech = function(id, techName) {
      return $http.put(serverLink + "users/" + id + "/addtechnology?techName=" + techName)
    }

    this.getCurrentUser = function () {
      return that.currentUser
    }

    // this.editUser = function (id) {
    //   $state.go("userUpdate", { id: id });
    // }

        // this.postImage = function(image) {
    //     // return $http.post("http://uploads.im/api?upload=" + image + "&format=json")
    //     return $http.post("http://uploads.im/api", image)
    // }

    that.currentUser = null;
    
    this.login = function (user, cb) {
      console.log(user)
      $http.get(serverLink + "users/?username=" + user.username + "&password=" + user.password)
        .then(function (response) {
          console.log("res", response.data[0]);
          if (response.data[0] != undefined) {
            that.currentUser = response.data[0];
            $state.go("user", { id: that.currentUser.id });
          }
          else {
            cb(true);
          }
        },
        function (error) {
          console.log(error);
        })
    }

    this.logout = function() {
      that.currentUser = null;
      $state.go("home");
    }
});
