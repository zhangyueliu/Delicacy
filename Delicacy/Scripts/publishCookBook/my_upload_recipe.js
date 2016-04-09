//var upUrl = 'http://121.42.58.78:8888/';
var upUrl = 'http://localhost:53565/';
(function ($, window) {
    $("input[name=subject]").focus();
    var default_words = "";
    $("body").on("click", ".J_addDiv,.J_delete,.J_addTextarea,.J_upTextarea,.J_downTextarea,.J_fileImag,.J_addElem_box span,.more,.J_delTextarea", function () {
        var th = $(this);
        if (th.hasClass("J_input")) {
            mycenter.Event_input(th)
        } else {
            if (th.hasClass("J_addDiv")) {
                mycenter.Event_addDiv(th)
            } else {
                if (th.hasClass("J_delete")) {
                    mycenter.Event_delDiv(th)
                } else {
                    if (th.hasClass("J_addTextarea")) {
                        mycenter.Event_addBlockQ(th)
                    } else {
                        if (th.hasClass("J_upTextarea")) {
                            mycenter.Event_upBlockQ(th)
                        } else {
                            if (th.hasClass("J_downTextarea")) {
                                mycenter.Event_downBlockQ(th)
                            } else {
                                if (th.parent().hasClass("J_addElem_box")) {
                                    mycenter.Event_J_addElem_box(th)
                                } else {
                                    if (th.hasClass("more")) {
                                        mycenter.Event_more(th)
                                    } else {
                                        if (th.hasClass("J_delTextarea")) {
                                            mycenter.Event_delTextarea(th)
                                        } else {
                                            if (th.hasClass("J_fileImag")) { }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    });
    $("body").on("focus", ".J_input", function () {
        if (!/color_5b/.test($(this).attr("class"))) {
            default_words = $(this).val();
            $(this).html("").val("").addClass("color_5b")
        } else {
            default_words = ""
        }
    });
    $("body").on("blur", ".J_input", function () {
        if ($(this).val() == "") {
            $(this).html(default_words).val(default_words).removeClass("color_5b")
        }
    });
    $(".uploadImage2 div.main_cover, .uploadImage2 div.other_cover, .uploadImage2 div.collect_edit").hover(function () {
        $(this).find(".shadow1").fadeTo(0, 0.3).show();
        $(this).find(".shadow2").show()
    }, function () {
        $(this).find(".shadow1,.shadow2").hide()
    });
    $(".other_cover").click(function () {
        var pa = $(this);
        var photoid = $(this).find("div.shadow1 input").val();
        var recipeid = $("#recipeinfo_id").val();
        msc.ui.dialog.alert("删除后无法恢复，确定要删除此图么?", function () {
            $.post(msc.tools.getAjaxUrl({
                ac: "recipe",
                op: "delete_photo_pic"
            }), {
                recipeid: recipeid,
                photoid: photoid
            }, function (result) {
                if (result.error == 0) {
                    pa.remove();
                    msc.ui.dialog.success("删除成功")
                } else {
                    msc.ui.dialog.error("出现错误，请重试")
                }
                return false
            }, "json")
        }, $.noop)
    });

    function check_step() {
        var istep = 0;
        $('textarea[name="note[]"]').each(function () {
            if (!/color_5b/.test($(this).attr("class")) || $(this).val() == "") {
                istep = 1
            }
        });
        return istep
    }

    function check_step_img() {
        var istep_img = 0;
        $(".div_file_img").each(function () {
            if (/span/.test($(this).html())) {
                istep_img = 1
            }
        });
        return istep_img
    }
    $("#savebtn").click(function () {
        if ($("input[name=subject]").val() === "") {
            msc.ui.dialog.error("请输入菜谱名称");
            $("input[name=subject]").focus()
        } else {
            $(this).attr("id", "");
            $(this).val("提交中...");
            ifbtn = 1;
            if (!$('input[name="food1[]"]:first').hasClass("color_5b")) {
                $('input[name="food1[]"]:first').val("")
            }
            if (!$('input[name="food2[]"]:first').hasClass("color_5b")) {
                $('input[name="food2[]"]:first').val("")
            }
            if (!$('input[name="food3[]"]:first').hasClass("color_5b")) {
                $('input[name="food3[]"]:first').val("")
            }
            if (!$('input[name="food4[]"]:first').hasClass("color_5b")) {
                $('input[name="food4[]"]:first').val("")
            }
            if (!$('textarea[name="message"]').hasClass("color_5b")) {
                $('textarea[name="message"]').val("")
            }
            $('textarea[name="note[]"]').each(function () {
                if (!$(this).hasClass("color_5b")) {
                    $(this).val("")
                }
            });
            setTimeout(function () {
                $("#savesub").click()
            }, 1000)
        }
    });
    $("#formRecipe").submit(function () {
        if ($("input[name=subject]").val() === "") {
            msc.ui.dialog.error("出现异常，请重试");
            return false
        }
    });
    $("#cancel").click(function () {
        msc.ui.dialog.alert("取消后，您输入的信息将不会被保存，要继续么?", function () {
            history.go(-1)
        }, $.noop)
    });
    $("#add_collect").submit(function () {
        if (!$("input[name=collect_type]:checked").val()) {
            msc.ui.dialog.error("请选择菜单类型");
            return false
        } else {
            if ($("input[name=collect_name]").val() == "") {
                msc.ui.dialog.error("请输入菜单名称");
                return false
            } else {
                return true
            }
        }
    });
    var mycenter = {
        Event_addDiv: function (th) {
            var pa = th.parent();
            if (pa.attr("class") == "Right") {
                var tem = '<div class="J_addDiv"><input type="text" class="zhuliao btn37 color_5b" value="" name="food3[]">' + '<input type="text" class="yongliang btn37 color_5b" value="" name="food4[]">' + '<a href="javascript:;" class="delete J_delete"></a></div>'
            } else {
                var tem = '<div class="J_addDiv"><input type="text" class="zhuliao btn37 color_5b" value="" name="food1[]">' + '<input type="text" class="yongliang btn37 color_5b" value="" name="food2[]">' + '<a href="javascript:;" class="delete J_delete"></a></div>'
            }
            th.removeClass("J_addDiv");
            pa.append(tem)
        },
        Event_delDiv: function (th) {
            var path = th.closest("blockquote");
            var pa = th.parent();
            pa.remove();
            path.find("div:last").addClass("J_addDiv")
        },
        Event_addBlockQ: function (th) {
            var tpl = '<blockquote class="cp_block J_blockQ clear" style="display:none;cursor:move;">' + '<div class="left addicon J_fileImag" >' + '<input type="hidden" value="" name="step_img[]" class="J_imghidden" />' + '<input type="file" name="file"  value=""/>' + '<p class="p1">点击上传步骤图</p>' + '<p class="p3">（可不填）</p>' + "</div>" + '<div class="left">' + '<input type="hidden" name="stepid[]" value="">' + '<textArea name="note[]" class="textArea J_input">请输入做法说明菜谱描述，最多输入1000字</textArea>' + '<span class="J_step_num"></span>' + '<a href="javascript:;" class="add J_addTextarea"></a><a class="up J_upTextarea" href="javascript:;"></a><a class="down J_downTextarea" href="javascript:;"></a><a href="javascript:;" class="delete J_delTextarea"></a>' + "</div>" + "</blockquote>";
            th.closest(".J_blockQ").after(tpl);
            th.parent().parent().next().slideDown("600");
            orderNumber();
            this.Event_util()
        },
        Event_upBlockQ: function (th) {
            var pa = th.closest(".J_blockQ");
            var sn = th.parent().parent().index();
            if (sn == 0) {
                return false
            } else {
                sn -= 1;
                $("#dragsort").find("blockquote:eq(" + sn + ")").before(th.parent().parent().clone().hide());
                $("#dragsort").find("blockquote:eq(" + sn + ")").fadeIn("800");
                pa.remove();
                orderNumber()
            }
        },
        Event_downBlockQ: function (th) {
            var pa = th.closest(".J_blockQ");
            var sn = th.parent().parent().index();
            if (sn == $("#dragsort blockquote").length - 1) {
                return false
            } else {
                sn++;
                $("#dragsort").find("blockquote:eq(" + sn + ")").after(th.parent().parent().clone().hide());
                sn++;
                $("#dragsort").find("blockquote:eq(" + sn + ")").fadeIn("800");
                pa.remove();
                orderNumber()
            }
        },
        Event_delTextarea: function (th) {
            var pa = th.closest(".J_blockQ");
            var stepnum = $(".J_blockQ").length;
            if (stepnum > 3) {
                var stepid = th.parent().find("input").val();
                var recipeid = $("#recipeinfo_id").val();
                if (stepid != "") {
                    msc.ui.dialog.alert("删除步骤后将无法恢复,您确定要删除么?", function () {
                        $.post(msc.tools.getAjaxUrl({
                            ac: "recipe",
                            op: "delete_steps_pic"
                        }), {
                            recipeid: recipeid,
                            stepid: stepid
                        }, function (result) {
                            if (result.error == 0) {
                                pa.fadeOut("800", function () {
                                    pa.remove();
                                    orderNumber()
                                });
                                msc.ui.dialog.success("删除成功")
                            } else {
                                msc.ui.dialog.error("出现错误，请重试")
                            }
                            return false
                        }, "json")
                    }, $.noop)
                } else {
                    var delImg = pa.find(".J_imghidden").val();
                    if (delImg != "") {
                        $.get(msc.tools.getAjaxUrl({
                            ac: "recipe",
                            op: "del_recipe_upai"
                        }), {
                            "img": delImg
                        }, function (d) { }, "json")
                    }
                    pa.fadeOut("800", function () {
                        pa.remove();
                        orderNumber()
                    })
                }
            } else {
                msc.ui.dialog.error("您至少需要填写三步")
            }
        },
        Event_J_addElem_box: function (th) {
            var pa = th.parent();
            $(".J_eleBox").html("");
            if (th.hasClass("on")) {
                th.removeClass("on")
            } else {
                th.addClass("on")
            }
            var txts = "";
            var vss = "";
            pa.find(".on").each(function (ind, ele) {
                var vals = $(ele).attr("value");
                var txt = $(ele).text();
                txts = txt + ",";
                if (vals == null) {
                    return
                }
                vss += vals + ",";
                $(".J_eleBox").append("<span class='red'>" + txts + "</span>")
            });
            $(".J_addElem_box_value").val(vss.substr(0, vss.length - 1))
        },
        Event_more: function (th) {
            var st = th.attr("data-statu");
            if (st == null || st == "0") {
                th.html("收起");
                $(".J_addElem_box").css("height", "auto");
                th.attr("data-statu", "1")
            } else {
                th.html("更多");
                $(".J_addElem_box").css("height", "40px");
                th.attr("data-statu", "0")
            }
        },
        Event_upload: function (win, ele) {
            console.log(win);
            var str = $(win.contentWindow.document.body).find("#upai_url").val();
            if (str) {
                var delImg = ele.parent().find(".J_imghidden").val();
                if (delImg != "" && !/p320|p800/i.test(delImg)) {
                    $.get(msc.tools.getAjaxUrl({
                        ac: "recipe",
                        op: "del_recipe_upai"
                    }), {
                        "img": delImg
                    }, function (d) { }, "json")
                }
                ele.parent().find(".J_imghidden").val(upUrl + str).end().find(".div_file_img").css("backgroundImage", "none").html("<img class='file_img' src='" + str + "' width=100% />");
                ele.closest(".J_fileImag").find("iframe").remove("")
            }
        },
        Event_util: function () {
            var self = this;
            $(".J_fileImag input").fadeTo(0, 0);
            $(".J_fileImag").mousemove(function (ev) {
                var th = $(this);
                var file = th.find("input[type='file']");
                var x = ev.pageX - th.offset().left - 40;
                var y = ev.pageY - th.offset().top - 40;
                file.css({
                    "left": x + "px",
                    "top": y + "px",
                    "display": "block"
                })
            });
            $(".J_fileImag input[type='file']").click(function (event) {
                var th = $(this);
                th.closest(".J_fileImag").find("iframe").remove().end().append('<iframe id="J_iframe_0" src="/Upload/UploadImgOne" width="200" height="200"></iframe>');
            });
            $(".J_fileImag input[type='file']").mousedown(function (event) { });
            $(".J_fileImag input[type='file']").change(function () {
                var th = $(this);
                var id = th.attr("id");
                var ele = th.clone(true, true);
                th.after(ele);
                var _tpl = "";
                var win = th.closest(".J_fileImag").find("iframe:eq(0)")[0];
                var $win_b = $(win.contentWindow.document.body);;
                $win_b.find("form").append(th);
                $win_b.find("form").submit();
                ele.parent().find(".file_img").remove().end().find(".div_file_img").remove().end().append("<div class='div_file_img'><span>正在上传中...</span></div>");
                if (+[1, ]) {
                    win.onload = function () {
                        self.Event_upload(win, ele)
                    }
                } else {
                    win.onreadystatechange = function () {
                        (this.readyState && this.readyState == "complete") ? self.Event_upload(win, ele) : ""
                    }
                }
            })
        }
    };
    mycenter.Event_util();
    var upload = function (arg) {
        if (typeof arg == "undefined") {
            msc.ui.dialog.error("参数错误！");
            return
        } else {
            swf._create(arg)
        }
    };
    var swf = {
        _create: function (arg) {
            var self = this;
            var arr = arg.split(",");
            if ($(arr)[0].length <= 0) {
                msc.ui.dialog.error(arg + "：加载错误！");
                return
            }
            var i = 0;
            for (; i < arr.length; i++) {
                var p_w = $(arr[i]);
                p_w.addClass("J_uploadflash");
                p_w.css({
                    "position": "relative",
                    "top": "",
                    "left": "0"
                });
                self.setswf(p_w)
            }
            $("body").on("click", ".J_uploadflash,.J_fileImag,.multi_step", function () {
                var th = $(this);
                var URL = msc.tools.getAjaxUrl({
                    ac: "recipe",
                    op: "upload_last_pic"
                });
                if (th.hasClass("J_uploadflash")) {
                    var url = "";
                    msc.tools.uploadImg({
                        url: upUrl + $("#upai_bucket").val() + "/",
                        title: "上传您的菜谱",
                        policy: $("#upai_policy").val(),
                        signature: $("#upai_signature").val(),
                        success: self.access_handle
                    })
                } else {
                    if (th.hasClass("J_fileImag")) {
                        var ipt = th.find("input")[0];
                        ipt.click();
                        ipt.onchange = function () {
                            $.get(upUrl  +URL, function (da) { })
                        }
                    } else {
                        if (th.hasClass("multi_step")) {
                            var url = "";
                            msc.tools.uploadImg({
                                url: upUrl + $("#upai_bucket").val() + "/",
                                title: "上传您的菜谱步骤",
                                policy: $("#upai_policy").val(),
                                signature: $("#upai_signature").val(),
                                success: self.access_handle2
                            })
                        }
                    }
                }
            })
        },
        setswf: function (th) {
            var self = this
        },
        access_handle: function (data) {
            var self = this;
            var config = "",
                arr;
            if (data.length < 1) {
                return true
            }
            arr = $.map(data, function (value) {
                return value.src
            });
            msc.ui.dialog.loading();
            $.post(msc.tools.getAjaxUrl({
                ac: "recipe",
                op: "save_last_pic",
                ifedit: $("#ifedit").val()
            }), {
                recipeid: $("#recipeid").val(),
                length: data.length,
                pic: arr.join(",")
            }, function (res) {
                if (res.error === 0) {
                    swf.render_handle(arr, res.data)
                } else {
                    msc.ui.dialog.error(res.msg || "添加失败")
                }
                msc.ui.dialog.loading.close()
            }, "json")
        },
        access_handle2: function (data) {
            var self = this;
            var config = "",
                arr;
            if (data.length < 1) {
                return true
            }
            arr = $.map(data, function (value) {
                return value.src
            });
            msc.ui.dialog.loading();
            msc.ui.dialog.loading.close();
            var step_bgs = $("#dragsort blockquote").length;
            var step_last = $("#dragsort img.file_img:last").closest("blockquote").index();
            var num_pic = step_bgs - step_last - 1;
            var ii;
            for (ii = 0; ii < arr.length; ii++) {
                if (ii < num_pic) {
                    $("#dragsort blockquote:eq(" + (step_last + 1) + ") .J_imghidden").val(arr[ii]);
                    $("#dragsort blockquote:eq(" + (step_last + 1) + ") .J_fileImag").append('<div class="div_file_img" style="background-image: none;"><img src="' + arr[ii] + '!p320" class="file_img" width=100% /></div>');
                    step_last++
                } else {
                    $("#dragsort").append('<blockquote class="cp_block J_blockQ clear" style="display:none;cursor:move;">' + '<div class="left addicon J_fileImag" >' + '<input type="hidden" value="' + arr[ii] + '" name="step_img[]" class="J_imghidden" />' + '<input type="file" name="file"  value=""  />' + '<p class="p1">点击上传步骤图</p>' + '<p class="p3">（可不填）</p><div class="div_file_img" style="background-image: none;"><img src="' + arr[ii] + '!p320" class="file_img" width=100% /></div>' + "</div>" + '<div class="left">' + '<input type="hidden" name="stepid[]" value="">' + '<textArea name="note[]" class="textArea J_input">请输入做法说明菜谱描述，最多输入1000字</textArea>' + '<span class="J_step_num"></span>' + '<a href="javascript:;" class="add J_addTextarea"></a><a class="up J_upTextarea" href="javascript:;"></a><a class="down J_downTextarea" href="javascript:;"></a><a href="javascript:;" class="delete J_delTextarea"></a>' + "</div>" + "</blockquote>");
                    $("#dragsort blockquote:last").fadeIn("600")
                }
            }
            orderNumber();
            mycenter.Event_util()
        },
        render_handle: function (arr, data) {
            $(".J_swf").append('<div class="f_img"><b></b><img src="' + arr[0] + '!p320"  /></div>');
            $("#allpic").val(arr.join(","));
            $(".J_uploadflash").removeClass("J_uploadflash")
        },
    };
    msc.tools.upload = upload
})(jQuery, window);
(function ($, msc) {
    var DIALOG = msc.ui.dialog,
        NOOP = $.noop,
        BASE = "http://static.meishichina.com/v6/img/uploadImg/",
        PROXY = $.proxy,
        uploadImg;
    uploadImg = msc.tools.uploadImg = function (config) {
        if (DIALOG.get("uploadImg")) {
            return false
        }
        if ("function" === typeof config) {
            config = {
                success: config
            }
        }
        config = $.extend(true, {
            success: NOOP,
            url: "",
            error: NOOP
        }, config || {});
        return new Class(config)
    };
    uploadImg.formatSize = function (size, pointLength, units) {
        var unit;
        units = units || ["B", "K", "M", "G", "TB"];
        while ((unit = units.shift()) && size > 1024) {
            size = size / 1024
        }
        return (unit === "B" ? size : size.toFixed(pointLength || 2)) + unit
    };

    function Class(config) {
        this.config = config;
        return this.init()
    }
    Class.prototype.init = function () {
        var self = this,
            dom = self._dom = {};
        self.status = null;
        self.fileSize = 0;
        self.fileLength = 0;
        self.successFileLength = 0;
        self._data = {};
        self.percentages = {};
        self.dialog = DIALOG({
            title: self.config.title || "上传图片",
            lock: true,
            id: "uploadImg",
            content: '<div class="ui-uploadImg">' + '<div class="ui-uploadImg-list">' + '<div class="ui-webkit-scrollbar">' + '<ul><li class="last"><div id="spanSWFUploadButton"></div></li></ul>' + "</div>" + "</div>" + '<div class="ui-uploadImg-btn">' + '<div class="left"><a href="#" class="ui-btn-red-2 J_uploadbtn">开始上传</a><a href="javascript:;" class="ui-btn-gray-2">取消</a></div>' + '<div class="right">' + '<div class="ui-uploadImg-status">...</div>' + "</div>" + "</div>" + "</div>",
            initialize: PROXY(self._initialize, self),
            beforeunload: PROXY(self._beforeunload, self)
        });
        self.dialog._$("close").hide();
        dom.$wrap = self.dialog._$("content").find(".ui-uploadImg");
        dom.$list = dom.$wrap.find("ul");
        dom.$startBtn = dom.$wrap.find(".ui-btn-red-2");
        dom.$cancelBtn = dom.$wrap.find(".ui-btn-gray-2");
        dom.$statusBar = dom.$wrap.find(".ui-uploadImg-status");
        self._bind()
    };
    Class.prototype._bind = function () {
        var self = this,
            dom = self._dom,
            dialog = self.dialog;
        dom.$cancelBtn.click(function () {
            dialog.close()
        });
        dom.$startBtn.click(PROXY(self.startUpload, self));
        dom.$list.on("click", "span.delete", function () {
            var that = this,
                $li = $(that).closest("li"),
                id = $li.attr("data-id"),
                api = self.percentages[id];
            if (self.status === 2) {
                return false
            }
            if (api) {
                self.fileSize -= api["size"];
                self.fileLength -= 1;
                delete self.percentages[id]
            }
            if (self._data[id]) {
                delete self._data[id];
                self.fileLength -= 1;
                var delImg = $("#J_upload_item_" + id + " img").attr("data-src");
                $.get(msc.tools.getAjaxUrl({
                    ac: "recipe",
                    op: "del_recipe_upai"
                }), {
                    "img": delImg
                }, function (d) { }, "json")
            } else {
                self.flash.cancelUpload(id, false)
            }
            if (self.fileLength < 1) {
                self.setState(0)
            } else {
                if (self.successFileLength >= self.fileLength) {
                    self.setState(4)
                }
            }
            self.updateStatus();
            $li.remove();
            $li = null;
            return false
        })
    };
    Class.prototype.startUpload = function () {
        var self = this,
            status = self.status,
            data;
        if (status === 0) {
            DIALOG.error("请先添加图片")
        } else {
            if (status === 1) {
                self.flash.startUpload();
                self.setState(2)
            } else {
                if (status === 2) { } else {
                    if (status === 3) { } else {
                        if (status === 4) {
                            data = [];
                            $.each(self._data, function () {
                                data.push(this)
                            });
                            if (self.config.success.call(self, data) !== false) {
                                self.config.error = NOOP;
                                self.status = 5;
                                self.dialog.close()
                            }
                        }
                    }
                }
            }
        }
        return false
    };
    Class.prototype._beforeunload = function () {
        var self = this,
            key, status = self.status;
        if (status === 0 || status === 5) {
            self.flash.stopUpload();
            self.flash.destroy();
            self.config.error();
            for (key in self) {
                delete self[key]
            }
            return true
        } else {
            if (status === 1) {
                DIALOG.alert("此时关闭窗口图片将不会被保存， 确定关闭吗？", function () {
                    self.status = 5;
                    self.dialog.close()
                }, NOOP)
            } else {
                if (status === 2) {
                    DIALOG.alert("此时关闭窗口图片将不会被保存， 确定关闭吗？", function () {
                        self.status = 5;
                        self.dialog.close()
                    }, NOOP)
                } else {
                    if (status === 3) { } else {
                        if (status === 4) {
                            if (self.successFileLength < 1) {
                                self.status = 5;
                                self.config.error = NOOP;
                                self.dialog.close()
                            } else {
                                DIALOG.alert("此时关闭窗口图片将不会被保存， 确定关闭吗？", function () {
                                    var delImgs = "";
                                    $(".ui-uploadImg .pic img").each(function () {
                                        delImgs += $(this).attr("data-src") + ","
                                    });
                                    $.get(msc.tools.getAjaxUrl({
                                        ac: "recipe",
                                        op: "del_recipe_upai"
                                    }), {
                                        "img": delImgs
                                    }, function (d) { }, "json");
                                    self.status = 5;
                                    self.dialog.close()
                                }, NOOP)
                            }
                        } else { }
                    }
                }
            }
        }
        return false
    };
    Class.prototype.setState = function (val) {
        var self = this,
            text, className;
        if (self.status !== val) {
            self.status = val;
            text = "开始上传";
            className = "ui-btn-red-2";
            switch (val) {
                case 0:
                    className += " ui-btn-gray-2";
                    break;
                case 1:
                    break;
                case 2:
                    className += " ui-btn-gray-2";
                    text = "正在上传";
                    break;
                case 3:
                    text = "继续上传";
                    break;
                case 4:
                    text = "完成";
                    break;
                case 5:
                    break;
                default:
                    break
            }
            self._dom.$startBtn[0].innerHTML = text;
            self._dom.$startBtn[0].className = className
        }
    };
    Class.prototype.updateStatus = function () {
        var text = "",
            self = this,
            status = self.status;
        if (status === 0) {
            text = "请先添加图片"
        } else {
            if (status === 1) {
                if (self.successFileLength > 0) {
                    if (self.fileLength - self.successFileLength > 0) {
                        text = "一共有" + self.fileLength + "张图片，新添加" + (self.fileLength - self.successFileLength) + "张图片，共" + uploadImg.formatSize(self.fileSize)
                    } else {
                        text = "成功上传" + self.fileLength + "张图片"
                    }
                } else {
                    text = "一共有" + self.fileLength + "张图片，共" + uploadImg.formatSize(self.fileSize)
                }
            } else {
                if (status == 2) {
                    text = "上传中, 一共 " + self.fileLength + "张图片, 已经完成" + self.successFileLength + "张图片"
                } else {
                    if (status === 4) {
                        if (self.fileLength - self.successFileLength > 0) {
                            text = "上传完成, 一共" + self.fileLength + "张图片, 失败" + (self.fileLength - self.successFileLength) + "张图片"
                        } else {
                            text = "上传完成, 成功上传" + self.fileLength + "张图片"
                        }
                    }
                }
            }
        }
        self._dom.$statusBar[0].innerHTML = text
    };
    Class.prototype._fileQueued_handler = function (file) {
        var self = this;
        if (self.status === 2) {
            DIALOG.warning("一会再选择吧")
        } else {
            self.percentages[file.id] = file;
            self.fileLength += 1;
            self.fileSize += file.size;
            self.addFile(file);
            self.setState(1);
            self.updateStatus()
        }
    };
    Class.prototype._fileQueuederror_handler = function (object, code, message) {
        if (code == -100) {
            DIALOG.warning("您最多可上传" + this.config.file_queue_limit + "张图片")
        }
    };
    Class.prototype.addFile = function (file) {
        var self = this,
            dom = self._dom,
            str = "";
        str += '<li id="J_upload_item_' + file.id + '" data-id="' + file.id + '"><div class="detail">';
        str += '<div class="pic"><img src="' + upUrl + 'images/placeholder.jpg" alt="' + file.name + '" width="140" height="140"></div>';
        str += '<div class="subtitle">' + file.name + "</div>";
        str += '<div class="subtools"><span class="delete">删除</span></div>';
        str += '<div class="subprogress"></div>';
        str += "</div></li>";
        dom.$list.find("li.last").before(str)
    };
    Class.prototype._success_handler = function (file, res, a) {
        var self = this,
            id = file.id,
            flash = self.flash,
            $li = $("#J_upload_item_" + id),
            $subtools = $li.find(".subtools"),
            str;
        try {
            res = $.parseJSON(res)
        } catch (e) {
            res = {
                code: -1,
                message: "返回值错误"
            }
        }
        if (res.code == 200) {
            $subtools.append('<span class="success">成功</span>');
            $li.find("img").attr("src", res.url);
            $li.find("img").attr("data-src", res.url);
            self.fileSize -= file.size;
            self.successFileLength += 1;
            delete self.percentages[file.id];
            self._data[file.id] = {
                src:   res.url,
                size: file.size,
                name: file.name
            }
        } else {
            if (res.code === -1) {
                str = "未知错误"
            } else {
                str = res.message
            }
        }
        if (str) {
            $subtools.append('<span class="error">' + str + "</span>");
            $li.find("img").attr("src", BASE + "error.jpg");
            str = null
        }
    };
    Class.prototype._error_handler = function (file) {
        var $li = $("#J_upload_item_" + file.id),
            $subtools = $li.find(".subtools");
        $subtools.append('<span class="error">上传失败</span>');
        $li.find("img").attr("src", BASE + "error.jpg")
    };
    Class.prototype._complete_handler = function (file) {
        var self = this;
        if (self.status === 2 && self.flash.getStats()["files_queued"] > 0) {
            self.flash.startUpload()
        } else {
            self.flash.getStats()["files_queued"] < 1 && self.setState(4)
        }
        $("#J_upload_item_" + file.id + " .subprogress").fadeOut();
        self.updateStatus()
    };
    Class.prototype._progress_handler = function (file, bytesLoaded, bytesTotal) {
        $("#J_upload_item_" + file.id + " .subprogress").stop().animate({
            width: Math.ceil((bytesLoaded / bytesTotal) * 100) + "%"
        }, 200)
    };
    Class.prototype._initialize = function () {
        var self = this,
            config = self.config;
        self.flash = new SWFUpload({
            upload_url: config.url,
            flash_url: "http://static.meishichina.com/v6/swfupload/swfupload.swf",
            file_post_name: "file",
            post_params: {
                "policy": config.policy,
                "signature": config.signature
            },
            file_types: "*.jpg;*.gif;*.png;*.jpeg",
            file_upload_limit: config.file_queue_limit || 0,
            file_queue_limit: config.file_queue_limit || 0,
            button_placeholder_id: "spanSWFUploadButton",
            button_width: 140,
            button_height: 140,
            button_cursor: SWFUpload.CURSOR.HAND,
            button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,
            file_queued_handler: PROXY(self._fileQueued_handler, self),
            file_queue_error_handler: PROXY(self._fileQueuederror_handler, self),
            upload_success_handler: PROXY(self._success_handler, self),
            upload_error_handler: PROXY(self._error_handler, self),
            upload_complete_handler: PROXY(self._complete_handler, self),
            upload_progress_handler: PROXY(self._progress_handler, self)
        });
        setTimeout(function () {
            self.setState(0);
            self.updateStatus()
        })
    }
}(jQuery, msc));
(function (original) {
    jQuery.fn.clone = function () {
        var result = original.apply(this, arguments),
            my_textareas = this.find("textarea").add(this.filter("textarea")),
            result_textareas = result.find("textarea").add(result.filter("textarea")),
            my_selects = this.find("select").add(this.filter("select")),
            result_selects = result.find("select").add(result.filter("select"));
        for (var i = 0, l = my_textareas.length; i < l; ++i) {
            $(result_textareas[i]).val($(my_textareas[i]).val())
        }
        for (var i = 0, l = my_selects.length; i < l; ++i) {
            result_selects[i].selectedIndex = my_selects[i].selectedIndex
        }
        return result
    }
})(jQuery.fn.clone);

function orderNumber() {
    var i = 1;
    $("#dragsort blockquote").each(function () {
        $(this).find(".J_step_num").html(i + "、");
        i++
    })
};