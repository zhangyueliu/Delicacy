function publishCookBook() {
    var Name = $("input[name=subject]").val();
    var Taste = $("input[name=cuisine]:checked").val();
    var FoodSort = $("input[name=foodSort]:checked").val();
    var Description = $("#message").val();
    var Tips = $("#tips").val();//$("#").val();
    var FinalImg = $("#final").val();
    var ProcessImgDes = getSteps();

    alert(1);
}


function getSteps() {
    //abc.jpg::过程描述|||def.jpg::过程描述
    var steps = '';
     $("#dragsort blockquote").each(function () {
         steps += $(this).find('input[name="step_img[]"] ').val() + '::' + $(this).find('textarea[name="note[]"] ').val() + '|||';
     });
   return steps.substr(0, steps.length - 3);

}