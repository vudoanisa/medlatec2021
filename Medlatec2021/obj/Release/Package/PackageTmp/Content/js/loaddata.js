
function confirm_delete() {
    const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: 'btn btn-success btn-rounded',
        cancelButtonClass: 'btn btn-danger btn-rounded mr-3',
        buttonsStyling: false
    });

    swalWithBootstrapButtons({
        title: 'Bạn chắc chắn chứ?',
        text: "Bạn có chắc chắn xóa những lựa chọn này không?",
        type: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Không, giữ lại!',
        confirmButtonText: 'Có, xóa luôn!',
        padding: '2em',
        width: '35em'
    }).then(function (result) {
        if (result.value) {
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swalWithBootstrapButtons(
                'Đã hủy',
                'Lựa chọn đã được giữ lại :)',
                'error'
            );
        }
    });
}

function alert_swee(title, content) {
    swal({
        title: title,
        html: content + '<br/> Thông báo tự động tắt sau 3s.',
        type: 'warning',
        padding: '2em',
        timer: 3000,
        onOpen: function () {
            swal.showLoading();
        }
    }).then(function (result) {
        if (result.dismiss === swal.DismissReason.timer) {
            console.log('I was closed by the timer');
        }
    });
}

function alert_redirect(title, content, url) {
    const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: 'btn btn-success btn-rounded',
        cancelButtonClass: 'btn btn-danger btn-rounded mr-3',
        buttonsStyling: false
    });

    swalWithBootstrapButtons({
        title: title,
        text: content,
        type: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Hủy',
        confirmButtonText: 'OK!',
        padding: '2em',
        width: '35em'
    }).then(function (result) {
        if (result.value) {
            location.href = url;
        }
    });
}

function swee_alert(title, content) {
    swal({
        title: title,
        html: content,
        type: 'success',
        padding: '2em',
        width: '35em'
    });
}

$('.widget-content .mixin').on('click', function () {
    const toast = swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000,
        padding: '2em'
    });
    toast({
        type: 'success',
        title: 'Signed in successfully',
        padding: '2em'
    })

});


$('.phone-fm').on('change', function (evt) {
    $(this).val(function (_, val) {
        val = val.replace(/(\d{4})(\d{3})(\d{3})/, "$1.$2.$3");
        val = val.replace(/\s/g, '');
        if (val.length != 12) { $('#phone').html('Quý khách cần nhập đúng định dạng của số điện thoại.'); $(this).addClass('borde-error'); return; }
        $(this).removeClass('borde-error');
        $(this).parent().find('.error').html('');
        return val;
    });
});

function hasNumber(myString) {
    return /\d/.test(myString);
}
$('.name').on('change', function (evt) {
    $(this).val(function (_, val) {
        var re = /^[a-zA-Z ]+$/;
        if (hasNumber(val)) {
            $('#name').html('Họ tên không bao gồm số và ký tự đặc biệt .');
            $(this).addClass('borde-error');
            $(this).val("");
            return;
        }
        else {
            $(this).removeClass('borde-error');
            $(this).parent().find('.error').html('');
        }

        return val;
    });
});

//$("input[class^='form-control']").on('change', function (evt) {
//    $(this).val(function (_, val) {
//        if (val.trim() == '') { check_input(); return; }
//        $(this).removeClass('borde-error');
//        $(this).parent().find('.error').html('');
//        return val;
//    });
//});

function check_input() {
    var mapInput = $(".pull-left").map(function () {
        return this;
    }).get();
    var check = 0;

    for (var i = 0; i < mapInput.length; i++) {
        if ($(mapInput[i]).val().trim() == '') {
            $(mapInput[i]).addClass('borde-error');
            var title = $(mapInput[i]).parent().find('.control-label').text();
            $(mapInput[i]).parent().find('.error').html('Quý khách cần nhập đủ ' + title);
            check++;
        }
        else {
            $(mapInput[i]).removeClass('borde-error');
            $(mapInput[i]).parent().find('.error').html('');
        }
    }
    if ($('#point').val() == 0) {
        check++; $('.stars').addClass('borde-error');
        $('.stars').parent().find('.error').html('Quý khách vui lòng dánh giá chất lượng dịch vụ của Medlatec *');
    } else {
        $('.stars').removeClass('borde-error');
        $('.stars').parent().find('.error').html('');
    }
    var oaaa = $('#organize').val();
    if (oaaa == 0) {
        check++;
        $('.chosen-container').addClass('borde-error');
        $('#organize').parent().find('.error').html('Quý khách vui lòng chọn đơn vị khám bệnh *');
    }
    else {
        $('.chosen-container').removeClass('borde-error');
        $('#organize').parent().find('.error').html('');
    }
    if ($('#Gender').val() == '') {
        check++;
        $('.gender').addClass('borde-error');
        $('.gender').parent().find('.error').html('Quý khách vui lòng chọn giới tính *');
    }
    else {
        $('.gender').removeClass('borde-error');
        $('.gender').parent().find('.error').html('');
    }
    return check;
}



function order_post() {
    var form = $('#contactForm').serialize();
    $.ajax({
        url: 'https://cskh.medlatec.vn/dashboard/Api/Feedback/',
        type: 'post',
        data: form,
        success: function (data) {
            var mess = data.Message;
            var content = data.Html;
            if (mess != '') alert_swee('Thông báo!', mess);
            if (content != '') alert_swee('Thông báo!', content);
        },
        error: function () { }
    });
}