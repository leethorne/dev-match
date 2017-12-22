app.controller("messageController", function ($scope, $state, $stateParams, userService) {

    messageService.getMessages()
    .then (function (response) {
        console.log(response);
        //$scope.messages = response.data;
    })
});