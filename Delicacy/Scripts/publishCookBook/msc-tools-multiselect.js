(function($, window, msc) {



	/*页面中单选的对应radio:单选id

	<select name="" id="kitcen" type="checkbox" index="1">
		<option  value="">厨具</option>
		<option name="chju1" value="2">炒锅</option>
		<option name="chju2" value="3">煮锅</option>
	</select>
	1、第一个option为默认显示内容，在下拉菜单里没有
	2、id 必须要有
	2-1、value值必填
	3、type 类型为  checkbox 或者  radio
	4  index 默认选中（单选）
	请给每个option添加name值，否则页面中提交不到数据
页面中复选的对应checkbox:复选id
*/
    
	/*msc.tools.multiselect({"radio":"diff,taste,process,consum","checkbox":"kitcen"})
	参数说明
	{
		radio：页面中需要radio的 id
		checkbox：页面中需要转换checkbox的id
	
		}
	 */

	var multiselect = function(arg) {


		ms.create(arg);

		$("body").click(function(event) {
			/* Act on the event */

			var tar = $(event.target);

			if (tar.closest('.multiselect').length <= 0) {
				ms.End();
			}



		});


	}

	var ms = {
		create: function(arg) {

			var tt1 = '<div class="multiselect select_{%multiselect%}"><input type="hidden" name="{%tar%}" id="J_{%tar%}" value=""><a tar="{%tar%}" href="javascript:;" check="false"  class="multi_txt {%classname%}" title="{%title%}">{%title%}</a><ul class="">';
			var self = this;
            var _id = 0;
            var _check = 0;

			if (arg && arg.radio) { //单选

				var arr = arg.radio.split(","),
					i = 0;
				for (; i < arr.length; i++,_id++) {

					var $ele = $("#" + arr[i]),
						_check = $ele.attr("index")||0,
						$opt = $("#" + arr[i]).find("option"),
						$checked = $("#" + arr[i]).find("option:eq("+_check+")").text(),
					_li = '<li><a href="javascript:;"><label class="J_radio"><input type="radio" {%checked%} name="{%name%}" value="{%value%}" />{%txt%}</label></a></li>',
					_tli = "",
					_top = tt1.replace(/\{%multiselect%\}/ig,_id)
							  .replace(/\{%title%\}/ig, $checked)
							  .replace(/\{%tar%\}/ig,arr[i])
						      .replace(/\{%classname%\}/ig, "multi_" + i);
	            
		
					$opt.each(function(ind, ele) {
						var ele = $(ele);
						if (ele.val() == "") {
							return
						}
						_tli += _li.replace(/\{%checked%\}/ig,(ind==_check)? "checked='checked'":"" )
							.replace(/\{%name%\}/ig, ele.attr("name"))
							.replace(/\{%value%\}/ig, ele.attr("value"))
							.replace(/\{%txt%\}/ig, ele.text());

					});
					$ele.after(_top + _tli + '</ul></div>');

				}



			}

			if (arg && arg.checkbox) { //多选

				var arr = arg.checkbox.split(","),
					i = 0 ;
					for (; i < arr.length; i++,_id++) {

						var $ele = $("#" + arr[i]),
							$opt = $("#" + arr[i]).find("option"),
							_check=($ele.attr("index"))? $ele.attr("index").split(","):0,
							$checked = $("#" + arr[i]).find("option:eq(0)").text(),
						_li = '<li><a href="javascript:;"><label class="J_checkbox"><input names="{%name%}"  {%checked%}  type="checkbox" value="{%value%}" />{%txt%}</label></a></li>',
						_tli = "",
						_top = tt1.replace(/\{%multiselect%\}/ig,_id)
								  .replace(/\{%title%\}/ig, $checked)
								  .replace(/\{%tar%\}/ig,arr[i])
							      .replace(/\{%classname%\}/ig, "multi_" + i);
						

						$opt.each(function(ind, ele) {
							var ele = $(ele);
							if (ele.val() == "") {
								return
							}


							_tli += _li.replace(/\{%checked%\}/ig,(ele.attr("checked"))? "checked='"+ele.attr("checked")+"'":"" )
									   .replace(/\{%name%\}/ig,(ele.attr("name")))
									   .replace(/\{%value%\}/ig, ele.attr("value"))
									   .replace(/\{%txt%\}/ig, ele.text());

						});

						$ele.after(_top + _tli + '</ul></div>');

						
					}


			}
			$(".multiselect").each(function(ind,ele){
					var ele = $(ele);
					var width =  ele.find(".multi_txt").outerWidth();
								 ele.css("width",width+"px");

			});

			$(".multiselect").on("click", ".multi_txt,label.J_radio,.J_checkbox", function(ev) {
				var th = $(this);
				if (th.hasClass('multi_txt')) {
					ms.Event_click(th);
				} else if (th.hasClass('J_radio')) {
					//var ev = ev.originalEvent;
                    
					self.Event_label(th);

				}else if(th.hasClass('J_checkbox')){
					self.Event_checkbox(th);
				}

			});

		},
		Event_label: function(th) {
			var self = this;
			var pa = th.closest('.multiselect');
			var txt = pa.find(".multi_txt");
			var ul = pa.find(">ul");
			txt.text(th.text())
			   .attr("check", "true")
			   .addClass('color_5b')
			   .attr("title",th.text());
			self.End();
			return this;
		},
		Event_checkbox:function(th){
			var self = this;
			var pa = th.closest('.multiselect');
			var txt = pa.find(".multi_txt");
			var ul = pa.find(">ul");
			var _ck = ul.find("input:checked").parent();
			var value = "";
			var vals = "";
			var select = $("#J_"+txt.attr("tar"));

				_ck.each(function(ind,ele){

					value+=$(ele).text()+",";
					vals+=$(ele).find("input").val()+",";
				})

				txt.text(value)
				   .attr("title",value)
				   .addClass('color_5b')
				   .attr("check", "true");
               //  alert(select);
		        select.val(vals.substr(0,vals.length-1));
			return this;

		},
		Event_click: function(th) {
			var self = this;
			
			if (/multi_txt_show/.test(th.attr('class')))
				this.End();
			else{
				this.End();
			th.addClass('multi_txt_show');
			var pa = th.parent();
			pa.addClass('multiselect_show');
			var ul = pa.find('>ul');
			var dw = $("body").outerWidth();
			var x = parseInt(th.offset().left) + ul.outerWidth();
			if (x >= dw) {
				ul.css("right", "0");
			}
			ul.stop(true).slideDown('100')
				.addClass('ul_show');

			}

		},
		End: function() {
			$(".multi_txt").removeClass('multi_txt_show');
			$(".multiselect").removeClass('multiselect_show')
				.find(">ul").stop(true).slideUp(100);
			
			
		}

	}

	window.msc.tools.multiselect = multiselect;



})(jQuery, window, window.msc)