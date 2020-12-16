
// 登录js
$(function () {

    // 1、判断是否登录
    isHasLogin();

})

// 5、是否已经登录
function isHasLogin() {
    if (IsLogin()) {
        return true;
    } else {
        // 1、弹出登录框
        loginbox();
        return false;

    }
}

//判断是否登录
function IsLogin() {
    //显示登录信息
    var user = getCache("user");
    //判断用户是否登录
    if (!$.isEmptyObject(user)) {
        $("#userLogin").show();
        $("#noneLogin").hide();
        $("#manage").html("你好 !" + user.UserName);
        return true;
    }
    else {
        $("#userLogin").hide();
        $("#noneLogin").show();
        return false;
    }
}

function logout() {
    //注销
    removeCache("user");
    //重置
    IsLogin();
}

//弹框登录
function loginbox() {
    layer.open({
        type: 1,
        title: "登陆",
        content: $('#loginbox')
    });
}
//注册登录
function registerbox() {
    layer.open({
        type: 1,
        title: "注册",
        content: $('#registerbox')
    });
}
//弹窗登录
function userLogin() {
    var username = $("#username").val();
    var pwd = $("#pwd").val();
    if (username == "" || pwd == null) {
        layer.msg("用户名或者密码不能为空", { time: 1000, icon: 5 });
        return;
    }
    else {
        //根据用户信息检测账号密码[聚合微服务地址]
        $.post("http://localhost:5000", { "UserName": username, "PassWord": pwd }, function (result) {
            if (result.ErrorNo == "0") {
                // 1、用户信息
                var ResultDic = result.ResultDic;
                setCache("user", ResultDic, ResultDic.ExpiresIn);

                // 3、关闭登录框
                layer.closeAll();

                // 4、登录提示
                layer.msg("登录成功");
                //显示用户登录信息
                IsLogin();
            } else {
                layer.msg("result.ErrorInfo")
            }

        });
    }
}



// 4、弹框注册
function regLogin() {
    // 1、获取用户信息
    var username = $("#txtusername").val(); // 用户名
    var pwd = $("#txtpwd").val(); // 用户密码
    var qq = $("#txtqq").val();// 用户QQ
    var tel = $("#txtphone").val();// 用户手机号
    if (username == "" || pwd == "" || qq == "" || tel == "") {
        layer.msg("各项不能为空", {
            time: 1000,
            icon: 5
        })
        return;
    }

    // 2、根据用户信息进行登录
    $.post("https://localhost:5006/api/User", { "UserName": username, "Password": pwd, "UserQQ": qq, "UserPhone": tel }, function (result) {
        if (result.ErrorNo == "0") {
            layer.msg("注册成功");
            // 1、关闭注册框
            layer.closeAll();

            // 2、弹出登录框
            loginBox();
        } else {
            layer.msg(result.ErrorInfo);
        }
    });
}