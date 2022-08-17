$(function () {

    $(".funny-circle").mouseenter(function () {
      $(this).css("top", "5px")
    });


  $("body").keydown(function (e) {
    switch (e.which) {
      case 38:
        console.log("hello");

        break;

      default:
        break;
    }
  });
});
