
$(document).ready(function () {

    $('#Button1').click(function () {
        var StudentId = $('#TextBox1').val();
        $.ajax({
            url: 'Details.aspx/GetStudentById',
            method: 'post',
            contentType: 'application/json',
            data: '{SId: ' + StudentId + '}',
            dataType: 'json',
            success: function (data) {
                $('#TextBox2').val(data.d.Name);
                $('#TextBox3').val(data.d.Gender);
                $('#TextBox4').val(data.d.Marks);

            },
            error: function (error) {
                alert(error);
            }
        })
    });
});