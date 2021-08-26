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


(function () {
    'use strict'
    tooltipTrigger();
    validationStyle();
})()
