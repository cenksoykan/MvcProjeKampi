(function () {
    'use strict'
    validationStyle();
    tooltipTrigger();
    $(':checkbox').click(checkedSwitch);
    $(':checkbox[name=selectAll]').click(function () {
        $(':checkbox[name=domainList]').prop('checked', this.checked);
    });
})()

$(document).ready(function () {
    $('#summernote').summernote({
        lang: 'tr-TR',
        minHeight: 360,
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'italic', 'underline', 'clear']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link']],
            ['view', ['codeview']]
        ]
        //toolbar: [
        //    ['style', ['style']],
        //    ['font', ['bold', 'italic', 'underline', 'clear']],
        //    ['fontname', ['fontname']],
        //    ['color', ['color']],
        //    ['para', ['ul', 'ol', 'paragraph']],
        //    ['table', ['table']],
        //    ['insert', ['link', 'picture', 'video']],
        //    ['view', ['fullscreen', 'codeview', 'help']]
        //]
    });
});

function validationStyle() {
    $('.field-validation-error').toggleClass('invalid-feedback', true);
    $('.input-validation-error').toggleClass('is-invalid', true);
    $('.field-validation-valid').toggleClass('valid-feedback', true);
    $('.input-validation-valid').toggleClass('is-valid', true);
}

function tooltipTrigger() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.forEach(function (tooltipTriggerEl) {
        new bootstrap.Tooltip(tooltipTriggerEl)
    })
}

function checkedSwitch() {
    this.value = this.checked;
}

function shuffle(array) {
    var m = array.length, t, i;
    while (m) {
        i = Math.floor(Math.random() * m--);
        t = array[m];
        array[m] = array[i];
        array[i] = t;
    }
    return array;
}

var Swal = Swal.mixin({
    confirmButtonText: 'Tamam',
    denyButtonText: 'Hayır',
    cancelButtonText: 'İptal',
    confirmButtonColor: '#0d6efd',
    denyButtonColor: '#DC3545',
    cancelButtonColor: '#6C757D',
    backdrop: true
});

var SwalTimer = Swal.mixin({
    showConfirmButton: false,
    timer: 1200
});
