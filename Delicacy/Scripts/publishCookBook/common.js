/**
 * @name 用户中心js
 * @namespace msc
 * @date 20140317
 * @description 用户中心js,debug
 */
(function($, msc) {

	

		var my = msc.register("msc.my");


		/**
		 * 前端用户主入口
		 */
		my.run = function(arr) {
			if (arguments.length > 1) {
				arr = Array.prototype.slice.call(arguments, 0);
			}
			if ("string" === typeof(arr)) {
				arr = [arr];
			}
			for (var i = 0; i < arr.length; i++) {
				if ("function" === typeof(my["_" + arr[i]])) {
					my["_" + arr[i]]();
					my["_" + arr[i]] = $.noop;
				}
			}
			return my;
		}

		/**
		 * 加载公用的
		 */
		my._common = function() {
			msc.user.init();
			msc.goTop.footerEle = $("#J_help_wrap");
			msc.goTop.init();
		}

		/**
		 * 图片加载
		 */
		my._imgLoad = function() {
			$("img.imgLoad[data-src!='']").imgLoad();
		}


		/**
		 * 关注
		 */
		my._follow = function() {

			//必须在用户初始完后才执行
			msc.user.ready(function() {
				$("#J_follow_list").on("click", '.substatus a', function() {
					var that = this;

					//如果标识不存在
					if (that.className !== 'on') {
						that.className = 'on';
						that.getElementsByTagName("span")[0].innerHTML = '关注中';
						msc.user.set_follow_mei(that.getAttribute("data-uid"), function() {
							that.getElementsByTagName("span")[0].innerHTML = '已关注';
						}, function(res) {
							that.getElementsByTagName("span")[0].innerHTML = '关注';
							that.className = '';
							res.error !== 10001 && msc.ui.dialog.error(res.msg || '一会再关注吧');
						});
					}

					return false;
				});

				$("#J_follow_reload").click(function() {
					var that = this;

					if (that.innerHTML === '换一换') {
						that.innerHTML = '请稍等';

						msc.user.get_follow_mei({
							size: 6,
							page: msc.tools.random(1, 50),
							success: function(res) {
								var i, len, str,
									data = res.data;
								if (data && data.length) {
									for (i = 0, len = data.length, str = ''; i < len; i++) {
										str += '<li><a href="http://home.meishichina.com/space-' + data[i].uid + '.html" target="_blank"><img class="imgLoad" src="' + data[i].avatar + '" alt="' + data[i].username + '" width="120" height="120"></a><p class="subline"><a target="_blank" href="http://home.meishichina.com/space-' + data[i].uid + '.html">' + data[i].username + '</a></p><p class="substatus" style="display:none"><a href="#" data-uid="' + data[i].uid + '"><i class="icon1"></i><span>关注</span></a></p></li>';
									}

									$("#J_follow_list").html(str);
								} else {
									msc.ui.dialog.error('一会再试吧');
								}
								that.innerHTML = '换一换';
							},
							error: function() { //如果出错或者没有登录
								that.innerHTML = '换一换';
							}
						});
					}

					return false;
				});

			});

		}

		/*用户搜索*/
//搜索
$(".search_Text").click(function(){$(this).stop("true").animate({width:"296px"},200,function(){var f=$(this).attr("data-first");if(f=="on"){$(this).val("");$(this).attr("data-first","off")}return}).removeClass("gay")});$("#search").click(function(){if($("#q").val().replace(/\s+/g,"").replace("　","")!='')$("#form_search").attr("action","http://home.meishichina.com/search/"+$("#q").val()+"/");$("#form_search").submit()});$('#q').keydown(function(event){if(event.keyCode==13){if($("#q").val().replace(/\s+/g,"").replace("　","")!='')$("#form_search").attr("action","http://home.meishichina.com/search/"+$("#q").val()+"/")}});


		}(jQuery, msc));