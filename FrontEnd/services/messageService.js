app.service("messageService", function ($http, $state) {

    this.getMessages = function() {
        return $http.get(serverLink + "messages")
    }

    this.getMessageById = function (id, cb) {
        if (id == null || id == undefined || id == "") {
            var message = {};
            cb(message);
        } else {
            $http.get(serverLink + "messages/" + id)
                .then(function (response) {
                    console.log(response)
                    cb(response.data)
                }, function (error) {
                    console.log(error)
                    //do something else here to alert of a fail
                })
        }
    }

    this.addMessage = function (message) {
        return $http.post(serverLink + "messages/", message)
    }

    this.updateMesage = function (id, message) {
        return $http.put(serverLink + "messages/" + id, message)
    }

    this.deleteUser = function (id) {
        return $http.delete(serverLink +  "messages/" + id);
    }

});