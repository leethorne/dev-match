app.service("userService", function ($http, $state) {

    this.getUsers = function () {
        return $http.get("http://localhost:50771/api/users");
    }

    this.getUserById = function (id, cb) {
        if (id == null || id == undefined || id == "") {
            var user = {};
            cb(user);
        } else {
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
    }
});