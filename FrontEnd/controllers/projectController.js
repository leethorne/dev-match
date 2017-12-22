app.controller("projectController", function($scope, $stateParams, projectService) {
  // collapse Form
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





}); 