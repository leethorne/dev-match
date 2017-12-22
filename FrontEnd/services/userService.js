app.service("userService", function ($http, $state) {

    this.getUsers = function () {
        return $http.get(serverLink + "users");
    }

    this.getUserById = function (id, cb) {
        if (id == null || id == undefined || id == "") {
            var user = {};
            cb(user);
        } else {
<<<<<<< HEAD
            $http.get("http://localhost:50771/api/users" + id)
                .then(function (response) {
                    console.log(response)
                    cb(response.data)
                }, function (error) {
                    console.log(error)
                    //do something else here to alert user of a fail
                })
        }
    }

    this.addUser = function (user) {
        return $http.post("http://localhost:50771/api/users" + user)
    }

    this.updateUser = function (id, user) {
        return $http.put("http://localhost:50771/api/users" + id, user)
    }

    this.deleteUser = function (id) {
        return $http.delete("http://localhost:50771/api/users" + id);
=======
            $http.get(serverLink + "users" + id)
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
>>>>>>> d4e3f58293837db4fc4a460ae958509f6888b1fd
    }
});