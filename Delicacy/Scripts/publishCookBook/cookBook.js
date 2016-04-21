function publishCookBook(status) {
    var Name = $("input[name=subject]").val();
    var Taste = $("input[name=cuisine]:checked").val();
    var FoodSort = $("input[name=foodSort]:checked").val();
    var foodMaterial = $("input[name=foodMaterial]").val()
    var Description = $("#message").val();
    var Tips = $("#tips").val();//$("#").val();
    var FinalImg = $("#final").val();
    var ProcessImgDes = getSteps();
    var MainMaterial = getMainMaterial();//|||::
    var AssistMaterial = getAssistMaterial();
    $.ajax({
        type: 'Post',
        url: '/CookBook/PublishCookBook',
        data: { Name: Name, Taste: Taste, FoodSort: FoodSort, Description: Description, Tips: Tips, FinalImg: FinalImg, ProcessImgDes: ProcessImgDes, MainMaterial: MainMaterial, AssistMaterial: AssistMaterial, status: status, foodMaterial: foodMaterial },
        dataType:'json',
        success: function (data) {
            $('#postbtn').val("发布菜谱");
            if (data.StatusCode == 1)
            {
                $("input[name=subject]").val('');
                //信息框-例2
                layer.msg('您的菜谱发布成功,正在审核', {
                    time: 2000 
                });
                setTimeout(function () { window.location.href = '/UserCenter/WaitCheck'; }, 2000);
            }
            else
                return layer.alert(data.Message, { icon: 3, skin: 'layer-ext-moon' });
        }
    });
}




function getSteps() {
    //abc.jpg::过程描述|||def.jpg::过程描述
    var steps = '';
     $("#dragsort blockquote").each(function () {
         steps += $(this).find('input[name="step_img[]"] ').val() + '::' + $(this).find('textarea[name="note[]"] ').val() + '|||';
     });
   return steps.substr(0, steps.length - 3);
}

function getMainMaterial() {
    var mainMaterial = '';
    $('blockquote[class="Left"] div').each(function () {
        mainMaterial += $(this).find('input[name="food1[]"]').val() + '::' + $(this).find('input[name="food2[]"]').val() + '|||';
    });
    mainMaterial = mainMaterial.replace("::|||", "");
    return mainMaterial.substr(0, mainMaterial.length - 3);
}

function getAssistMaterial() {
    var assistMaterial = '';
    $('blockquote[class="Right"] div').each(function () {
        assistMaterial += $(this).find('input[name="food3[]"]').val() + '::' + $(this).find('input[name="food4[]"]').val() + '|||';
    });
    assistMaterial = assistMaterial.replace("::|||", "");
    return assistMaterial.substr(0, assistMaterial.length - 3);
}