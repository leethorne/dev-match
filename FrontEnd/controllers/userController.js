app.controller("userController", function($scope, $stateParams, userService) {
  
  // collapse create project form
  $('.add-proj').click(function () {
    console.log("clicked");
    $addProj = $(this);
    $projForm = $('.create-project');
    $projForm.slideToggle(500, function () {
      $addProj.text(function () {
        return $addProj.is(':visible') ? '-' : '+';
      });
    });
  });

  // collapse login form
  $('.login').click(function () {
    console.log("clicked");
    $addProj = $(this);
    $projForm = $('.login-form');
    $projForm.slideToggle(500);
  });

  // profile pic preview
  $(document).ready(function() {
    $.uploadPreview({
      input_field: "#image-upload",
      preview_box: "#image-preview",
      label_field: "#image-label"
    });
  });
  
}); 