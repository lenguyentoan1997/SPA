$(function () {
    var controllerName = document.getElementById("helper").getAttribute("data-controller-name");

    // Reference the hub.
    var hubNotif = $.connection.echoHub;

    // Start the connection.
    $.connection.hub.start().done(function () {
        getAll(controllerName);
    });

    // Notify while anyChanges.
    hubNotif.client.updatedData = function () {
        getAll(controllerName);
    };
});

function getAll(controllerName) {
    var model = $('.data-table');

    $.ajax({
        url: '/Admin/' + controllerName + '/GetAllData',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            model.empty().append(result);
        }
    });
}