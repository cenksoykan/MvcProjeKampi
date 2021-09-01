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
            ['font', ['bold', 'underline', 'clear']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'picture', 'video']],
            ['view', ['codeview']],
            ['style', ['style']],
            ['fontname', ['fontname']]
        ]
        //toolbar: [
        //    ['style', ['style']],
        //    ['font', ['bold', 'underline', 'clear']],
        //    ['fontname', ['fontname']],
        //    ['color', ['color']],
        //    ['para', ['ul', 'ol', 'paragraph']],
        //    ['table', ['table']],
        //    ['insert', ['link', 'picture', 'video']],
        //    ['view', ['fullscreen', 'codeview', 'help']]
        //]
    });
});
