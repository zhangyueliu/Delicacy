$(function () {

    getWaitCheck(0);
});


//获取等待审核的菜谱
function getCookBook(status) {
    $.ajax({
        type: 'get',
        url: '/UserCenter/GetWaitCheckCookBook',
        dataType: 'json',
        success: function (data) {
            if(data.StatusCode==1)
            {
                initList(data.Data);
            }else
                return layer.alert(data.Message, { icon: 3, skin: 'layer-ext-moon' });
        }
    });
}

function initList(json) {

}