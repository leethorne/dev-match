app.service("userService", function($http, $state) {
    
    var currentUser = null;

    this.getUsers = function () {
        return $http.get(serverLink + "users");
    }

    this.getUserById = function (id, cb) {
        if (id == null || id == undefined || id == "") {
            var user = {};
            cb(user);
        } else {
            $http.get(serverLink + "users/" + id)
            .then (function(response) {
                console.log(response)
                cb(response.data)
            }, function(error) {
                console.log(error)
                //do something else here to alert user of a fail
            })
        }
    }

    this.addUser = function(user) {
        return $http.post(serverLink + "users" + user)
    }

    this.updateUser = function(id, user) {
        return $http.put(serverLink + "users" + id, user)
    }

    this.deleteUser = function(id) {
        return $http.delete(serverLink + "users" + id);
    }

    this.login = function(user) {
        $http.get(serverLink + "users/?username=" + user.username + "&password=" + user.password)
            .then(function(response) {
                console.log("res", response);
            }, function(error) {
                console.log(error);
            })   
    }

});