var $namespace = function (name, separator, container) {
    var ns = name.split(separator || '.'), o = container || window, i, len;
    for (i = 0, len = ns.length; i < len; i++) {
        o = o[ns[i]] = o[ns[i]] || {};
    }

    return o;
};


$namespace("xteam");
$namespace("xteam.codeMirror");
$namespace("xteam.http");

xteam.codeMirror = (function () {

    var c = {};

    let codemirror;

	c.GetCodeMirrorValue = function() {
	    return $.trim(codemirror.getValue());
	}
	
    c.SetCodeMirrorById = function (id, readonly = false) {

        var sqlcmd = document.getElementById(id);

        codemirror = CodeMirror.fromTextArea(sqlcmd,
        {
            mode: "text/x-mssql",
            indentWithTabs: true,
            smartIndent: true,
            lineNumbers: true,
            lineWrapping: true,
            matchBrackets: true,
            autofocus: false,
            readOnly: readonly,
            firstLineNumber: 1,
            extraKeys: { "Tab": "autocomplete" }
        });

        codemirror.setOption("theme", "default");
        codemirror.refresh();
    }

	c.ClearCodeMirror = function() {
        codemirror.setValue("");
	}

    return c;
})();

xteam.http = (function () {

    var h = {};

    var error = function (jqXhr, textStatus, errorThrown) {
        if (jqXhr.status === 401) {
            window.location = jqXhr.statusText;
        } else if (jqXhr.status === 404 || jqXhr.status === 500) {
            window.location.pathname = jqXhr.statusText;
        }
    }

    h.AjaxPost = function (url, data, success, dataType) {
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            dataType: dataType ? dataType : "json",
            success: success,
            error: error
        });
    }

    h.AjaxGet = function (url, success) {
        $.ajax({
            type: "GET",
            url: url,
            dataType: "json",
            success: success,
            error: error
        });
    }

    return h;
})();