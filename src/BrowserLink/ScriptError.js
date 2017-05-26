(function (browserLink, $) {

    var _project;
    var _enabled;

    function initialize(project, enabled) {
        _project = project;
        _enabled = enabled;
    }

    window.addEventListener("error", function (err) {
        if (_enabled && err && err.error) {
            var url = document.createElement('a');
            url.href = err.filename
            var fileName = url.pathname;

            browserLink.invoke("Report", fileName, err.lineno, err.colno, err.message, err.error.stack, _project);
        }
    });

    return {
        initialize: initialize
    };
});