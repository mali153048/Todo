

$('#btn-add-todo').on('click', function () {

    let title = $('#todo-title').val();

    if (!title) {
        $('#err-msg-title').removeClass('visually-hidden');
        return;
    }
    else {
        $('#err-msg-title').addClass('visually-hidden');
        $('#newtodo-form').submit()
    }

});


function onEdit(id) {
    let url = '/home/edit?id=' + id;
    get(url, onEditSuccess, onError);
}

function onEditSuccess(data) {
    debugger
    if (data && data.success) {
        $('#todo-title').val(data.data.title);
        $('#todo-id').val(data.data.id);
        $('#exampleModal').modal('show');
    }
    else {
        alert('Oops! An error occurred. Please try again later.');
    }
}


function onDelete(id, type) {

    if (confirm("Are you sure you want to delete " + id)) {

        let url = '/home/delete?id=' + id;

        if (type == 'todo')
            del(url, onDeleteSuccess, onError);
        else
            del(url, onTaskDeleteSuccess, onError);
    }

}

function onDeleteSuccess(data) {
    debugger
    if (data && data.success) {
        $('#' + data.data).remove();
        alert("TODO deleted successfully.")
    }
    else {
        alert('Oops! An error occurred. Please try again later.');
    }
}


function onDetails(id) {

    let url = '/home/details?id=' + id;

    get(url, onDetailsSuccess, onError);


}

function onDetailsSuccess(data) {

    $('#frm-edit-task').addClass('visually-hidden');
    if (data && data.success) {

        var todos = data.data.todos;

        var todo = todos.filter(x => x.parentID == null);
        var task = todos.filter(x => x.parentID != null);

        if (todo.length > 0 && todo) {
            $('#parent-task-id').val(todo[0].id)
            $('#todo-title-heading').text(todo[0].title.toString());
            $('#todo-idd').text(todo[0].id.toString());
            $('#todo-cat').text(new Date(todo[0].createdAt).toLocaleDateString("en-US"));
            $('#todo-mat').text(new Date(todo[0].modifiedAt).toLocaleDateString("en-US"));
        }
        if (task.length > 0 && task) {
            $('#frm-task').addClass('visually-hidden');

            $('#task-id').text(task[0].id.toString())
            $('#task-title-name').text(task[0].title.toString());
            $('#task-cat').text(new Date(task[0].createdAt).toLocaleDateString("en-US"));
            $('#task-mat').text(new Date(task[0].modifiedAt).toLocaleDateString("en-US"));

            $('.task-details').removeClass('visually-hidden');

            $('#edit-task-id').val(task[0].id.toString())
            $('#edit-task-title').val(task[0].title.toString());
            $('#edit-task-parentid').val(task[0].parentID);
        }
        else {
            $('#frm-task').removeClass('visually-hidden');
            $('.task-details').addClass('visually-hidden');
        }

        $('#detailsModal').modal('show');

    }
    else {
        alert('Oops! An error occurred. Please try again later.');
    }
}


$('#btn-add-task').on('click', function () {
    let title = $('#txt-task').val();

    if (!title) {
        $('#err-msg-task-title').removeClass('visually-hidden');
        return;
    }
    else {
        $('#err-msg-task-title').addClass('visually-hidden');
        $('#frm-task').submit()
    }
})

$('#btn-del-task').on('click', function () {
    let id = $('#task-id').text();
    onDelete(parseInt(id), 'task');
})

function onTaskDeleteSuccess() {
    $('#detailsModal').modal('hide');
}


$('#btn-edit-task').on('click', function () {
    $('.task-details').addClass('visually-hidden');
    $('#frm-edit-task').removeClass('visually-hidden');
})

$('#btn-cancel-edit').on('click', function () {
    $('.task-details').removeClass('visually-hidden');
    $('#frm-edit-task').addClass('visually-hidden');
})


$('#btn-edit-save').on('click', function () {

    let title = $('#edit-task-title').val();

    if (!title) {
        $('#err-msg-edit').removeClass('visually-hidden');
        return;
    }
    else {
        $('#err-msg-edit').addClass('visually-hidden');
        $('#frm-edit-task').submit()
    }
})

function onError() {
    alert('Oops! An error occurred. Please try again later.');
}