$(function () {
    var controllerName = document.getElementById("helper").getAttribute("data-controller-name");
    var actionName = document.getElementById("helper").getAttribute("data-action-name");
    var tableName = document.getElementById("helper").getAttribute("data-table-name");

    // Reference the hub.
    var hubNotif = $.connection.echoHub;

    // Start the connection.
    $.connection.hub.start().done(function () {
        getAll(controllerName, actionName, tableName);
    });

    // Notify while anyChanges.
    hubNotif.client.updatedData = function () {
        getAll(controllerName, actionName, tableName);
    };
});

function getAll(controllerName, actionName, tableName) {
    var model = $('.' + tableName);

    $.ajax({
        url: '/Admin/' + controllerName + '/' + actionName,
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            model.empty().append(result);
        }
    });
}