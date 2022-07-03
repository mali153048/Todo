// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function get(url, successCallback, errCallback) {
    $.ajax({
        type: 'GET',
        url: url,
        contentType: "application/json; charset=utf-8",
        success: (data) => {
            successCallback(data);
        }, error: () => {
            errCallback();
        }
    })
}


function del(url, successCallback, errCallback) {
    $.ajax({
        type: 'DELETE',
        url: url,
        contentType: "application/json; charset=utf-8",
        success: (data) => {
            successCallback(data);
        }, error: () => {
            errCallback();
        }
    })
}