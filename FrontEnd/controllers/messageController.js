app.controller("messageController", function ($scope, $state, $stateParams, userService) {

  $scope.currentUser = userService.getCurrentUser();

  messageService.getMessages()
    .then (function (response) {
      console.log(response);
      $scope.messages = response.data;
    },
    function(error) {
      console.log(error);
    })

  if ($stateParams.id == null || $stateParams.id == undefined || $stateParams.id == "") {
      messageService.getMessageById($stateParams.id, function (message) {
      $scope.message = message;
      console.log($scope.message);
    })
  }
  else {
    messageService.getMessageById($stateParams.id, function (message) {
      $scope.message = message;
      console.log($scope.message);
    })
  }

  $scope.addMessage = function () {
    messageService.addMessage($scope.message)
      .then(function (response) {
        console.log(response.data);
        $scope.message = response.data;
        console.log("message: ", $scope.message)
        //$state.go somewhere - view msgs page or a user page?
      },
      function (error) {
        console.log("you have an error: ", error)
      })
  }

  $scope.updateMessage = function () {
    messageService.updateMessage($stateParams.id, $scope.message)
      .then(function (response) {
        console.log(response.data);
        $scope.message = response.data;
        //$state.go to view messages or user?
      },
      function (error) {
        console.log(error)
      })
  }

  $scope.deleteMessage = function () {
    messageService.deleteMessage($stateParams.id)
      .then(function (response) {
          //$state.go(""); msg page??
      }, function (error) {
          console.log(error)
          //set error message here for users to see
      })
  }
});
