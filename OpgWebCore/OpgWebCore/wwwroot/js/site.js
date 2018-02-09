// Write your Javascript code.
/*
(function () {
    var $div = $(".carousel-indicators");
    var observer = new MutationObserver(function (mutations) {
        mutations.forEach(function (mutation) {
            if (mutation.attributeName === "class") {
                var attributeValue = $(mutation.target).prop(mutation.attributeName);

                if (attributeValue === "active") {
                    console.log("Class attribute changed to:", attributeValue);
                }
            }
        });
    });

    var childEle = $div.children();

    [].forEach.call(childEle, (item) => {
        observer.observe(item, {
            attributes: true
        });
    });
})()   */

(function(win) {
    var _this = win;
    var baseUrl = "http://opgsf.chinanorth.cloudapp.chinacloudapi.cn:8684/api/operation";

    var AddSourceOperationPara = function(para, callBack) {
        Request("source", para, callBack);
    }

    var AddDestOperationPara = function (para, callBack) {
        Request("dest", para, callBack);
    }

    var AddOperation = function (para, callBack) {
        Request("opera", para, callBack);
    }

    var GetResult = function (para, callBack) {
        Request("result", para, callBack);
    }

    var Reset = function (para, callBack) {
        Request("reset", para, callBack);
    }

    function Request(type, para, callBack) {
        var oReq = new XMLHttpRequest();

        oReq.onload = function (e) {
            var result = oReq.response; // not responseText
            callBack(result);
            /* ... */
        }
        oReq.overrideMimeType("text/plain; charset=x-user-defined");

        oReq.open("GET", [
            baseUrl,
            "?type=",
            type,
            "&value=",
            para
        ].join(""), true);
        //oReq.responseType = "arraybuffer";
        oReq.send();
    }

    var state = [];
    var len = 0;

    var SendMessage = function (message, callback) {
        var regReset = /^\s*reset\s*$/gi;
        if (regReset.test(message)) {
            Reset(0, callback);
            state = [];
            len = 0;
            return;
        }
        if (len === 0) {
            AddSourceOperationPara(message, callback);
            len = 1; return;
        } else {
            var regCompute = /^\s*={1}\s*$/g;
            if (regCompute.test(message)) {
                GetResult(0, callback);
                state = [];
                len = 0;
                return;
            }

            if (len === 1) {
                //var reg = /(\+|\-)/gi;
                var regPlusSub = /^\s*(\+|\-){1}\s*$/g;
                //var regSub = /^\s*(\+|\-){1}\s*$/g;
                var exeResult = regPlusSub.exec(message)
                if (exeResult[0].indexOf("+") > -1) {
                    AddOperation(1, callback);
                } else {
                    if (exeResult[0].indexOf("-") > -1) {
                        AddOperation(0, callback);
                    }
                }

                len += 1;
            } else {
                if (len >= 2) {
                    AddDestOperationPara(message, callback);
                }
            }
        } 

        //callback(res);
    }
    /*
    _this.AddSourceOperationPara = AddSourceOperationPara;

    _this.AddDestOperationPara = AddDestOperationPara;

    _this.AddOperation = AddOperation;

    _this.GetResult = GetResult;
    */

    _this.SendMessage = SendMessage;




})(window)