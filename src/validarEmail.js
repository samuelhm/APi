const checkEmailUniqueness = (emailFieldId, formId) => {
    const emailField = document.getElementById(emailFieldId);
    const form = document.getElementById(formId);

    emailField.addEventListener('blur', function () {
        const emailValue = emailField.value;

        if (emailValue) {
            fetch(`/Account/IsEmailInUse?email=${encodeURIComponent(emailValue)}`)
                .then((response) => response.json())
                .then((data) => {
                    if (data !== true) {
                        emailField.setCustomValidity(data);
                    } else {
                        emailField.setCustomValidity('');
                    }
                    form.classList.add('was-validated');
                });
        }
    });

    form.addEventListener('submit', function (event) {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
    }, false);
};

export default checkEmailUniqueness;