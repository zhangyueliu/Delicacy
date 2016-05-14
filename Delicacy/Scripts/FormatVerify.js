var regEmail = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
//验证是否是邮箱
function isEmail(email) {
    return regEmail.test(email);
}