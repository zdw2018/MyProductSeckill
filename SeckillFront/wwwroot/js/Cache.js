//缓存js
//封装过期控制代码
function setCache(key, value, expsecond) {
    var time = new Date();
    time.setSeconds(expsecond);
    var exptime = time.getTime();
    localStorage.setItem(key, JSON.stringify({ data: value, time: exptime }))
}

function getCache(key) {
    var data = localStorage.getItem(key);
    console.log(data);


    if (data == null) {
        return {};
    }
    var dataObj = JSON.parse(data);
    if (new Date().getTime() > dataObj.time) {
        //缓存过期
        console.log('信息过期');
        localStorage.removeItem(key);
        return {};
    }
    else {
        var jsondata = dataObj.data;
        return jsondata;
    }
}

function removeCache(key) {
    localStorage.removeItem(key);
}