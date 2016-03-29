function register() {
    var email = $('#email').val();
    if (!email)
        return layer.alert('邮箱不能为空', { icon: 3, skin: 'layer-ext-moon' });
    if (!isEmail(email))
        return layer.alert('邮箱格式不正确', { icon: 3, skin: 'layer-ext-moon' });
    var pwd = $('#pwd').val();
    if (!pwd)
        return layer.alert('密码不能为空', { icon: 3, skin: 'layer-ext-moon' });
    pwd = hex_md5(pwd);
    $.ajax({
        type: 'post',
        url: '/UserInfo/Register',
        data: { loginId: email, password: pwd },
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.StatusCode != '1')
                return layer.alert(data.Message, { icon: 3, skin: 'layer-ext-moon' });
            else
                return layer.alert('验证连接已发送到'+email+'邮箱,请您前去验证邮箱', { icon: 1, skin: 'layer-ext-moon' });
        }
    });
}



function login() {
    var email = $('#email').val();
    if (!email)
        return layer.alert('邮箱不能为空', { icon: 3, skin: 'layer-ext-moon' });
    if (!isEmail(email))
        return layer.alert('邮箱格式不正确', { icon: 3, skin: 'layer-ext-moon' });
    var pwd = $('#pwd').val();
    if (!pwd)
        return layer.alert('密码不能为空', { icon: 3, skin: 'layer-ext-moon' });
    pwd = hex_md5(pwd);
    $.ajax({
        type: 'post',
        url: '/UserInfo/Login',
        data: { loginId: email, password: pwd },
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.StatusCode != '1')
                return layer.alert(data.Message, { icon: 3, skin: 'layer-ext-moon' });
            else
                window.location.href = "/home/index";
        }
    });

}