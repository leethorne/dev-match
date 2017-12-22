app.service("messageService", function ($http, $state) {

    this.getMessages = function() {
        return $http.get(serverLink + "messages")
    }

});