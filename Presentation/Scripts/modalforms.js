// modalform.js

$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        // hide dropdown if any (this is used wehen invoking modal from link in bootstrap dropdown )
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');

        $('#genericModalContent').load(this.href, function () {
            $('#genericModal').modal({
                backdrop: 'static',
                keyboard: false
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});


function bindForm(dialog) {
    $('form', dialog).submit(function () {

        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {

                if (result.success) {

                    
                    $('#genericModalContent').modal('hide');
                    $('#genericModal').modal('hide');
                    location.href = result.url;
                   
                }
                else {
                    $('#genericModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        return false;
    });
}