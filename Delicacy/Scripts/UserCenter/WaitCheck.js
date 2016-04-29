var index = 1, size = 10;

$(function () {
    getWaitCheck(1, size, 0);
});
var flag = true;


//获取等待审核的菜谱
function getWaitCheck(pageIndex,pageSize,status) {
    $.ajax({
        type: 'get',
        url: '/UserCenter/GetaPageCookBookByStatus',
        dataType: 'json',
        data: { pageIndex: pageIndex, pageSize: pageSize, status: status },
        success: function (data) {
            if(data.StatusCode==1)
            {
                initList(data.Data);
            } else
            {
                flag = false;
                return layer.msg(data.Message);
            }
                
        }
    });
}

function initList(json) {
    var str = '';
    $.each(json, function () {
        str += '<li onclick="getDetail(&quot;' + this.CookBookId + '&quot;) "><div class="pic"><a href="#" ><img class="imgLoad" src="' + this.ImgUrl + '" alt="' + this.Name + '" width="120" height="90" /></a></div><div class="detail"><h4><a href="#">' + this.Name + '</a></h4><div class="substatus clear"><div class="right"><a href="#">编辑</a></div></div></div></li>';
    })
    $('#ulCookBook').append(str);
    window.onscroll = function () {
        var scrollTop = document.body.scrollTop;
        var offsetHeight = document.body.offsetHeight;
        var scrollHeight = document.body.scrollHeight;
        if (scrollTop == scrollHeight - offsetHeight && flag) {
            index++;
            getWaitCheck(index, size, 0);
        }
    };
}

function getDetail(cookbookId) {
    window.location.href = "/UserCenter/ShowDetail?cookBookId=" + cookbookId;
}

