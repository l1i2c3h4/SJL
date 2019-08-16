$SjlUtility = {
    confirmDelete: function() { return confirm("你确实要删除吗？"); },
    addButtonClass: function() {
        $('input:button').addClass("ui-button ui-state-default ui-corner-all");
        $('input:button').hover(function() { $(this).addClass("ui-state-hover"); }, function() { $(this).removeClass("ui-state-hover"); });
        $('input:submit').addClass("ui-button ui-state-default ui-corner-all");
        $('input:submit').hover(function() { $(this).addClass("ui-state-hover"); }, function() { $(this).removeClass("ui-state-hover"); });
    }
};
//JQuery Plugin
/*
* fill dropdownlist with the data from a web service
* url: web service url
* options:
*   arg: json string, web service argment
*   valueMember, displayMember: string. the value and display member of the returned object.
*/
(function($) {
    $.fn.fillDropDownList = function(url, options) {
        var list = $(this);
        $(list[0]).empty();
        $.ajaxSetup({ async: false });
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: url,
            data: options.arg,
            dataType: "json",
            success: function(result) {
                list.append("<option value='-1'>--请选择--</option>");
                var array = result.d;
                for (var i = 0; i < $(array).size(); i++) {
                    var e = array[i];
                    var s = "<option value='" + e[options.valueMember] + "'>" + e[options.displayMember] + "</option>";
                    list.append(s);
                }
            },
            failure: function() { alert('error when calling the web service at :' + url); }
        });
        return list;
    };
    /*
    * Cascading DropDownList
    * target: the lower levle dropdownlist control
    * url: web service url
    * options:  valueMember, displayMember, arg.  same as fillDropDownList
    *           cascadingArgName: the name of the argument used to call webservice
    */
    $.fn.cascadingDropDown = function(target, url, options) { 
    var i = 0;
    i = 10;
    $(this).change(function() {
        options.arg = options.arg.substr(0, options.arg.lastIndexOf('}'));
        options.arg = options.arg + "," + options.cascadingArgName +":"+ $(this).val() + "}";
        $(target).fillDropDownList(url, options);
    });
    };
})(jQuery);



