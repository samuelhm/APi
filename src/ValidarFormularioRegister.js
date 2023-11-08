const validarFormularioRegister = () => {
    const form = document.getElementById('registrationForm');
    if (!form) {
        return; // Sale de la función si el formulario no existe
    }
    const inputs = form.querySelectorAll('input');
    const checkEmail = async (email) => {
        try {
            const response = await fetch(`/Account/IsEmailInUse?email=${encodeURIComponent(email)}`);
            const isEmailInUse = await response.json();
            return isEmailInUse;
        } catch (error) {
            console.error('Error al verificar el email:', error);
            return false; // O manejar de otra manera
        }
    };
    const checkUser = async (user) => {
        try {
            const response = await fetch(`/Account/IsUserInUse?username=${encodeURIComponent(user)}`);
            const isUserInUse = await response.json();
            return isUserInUse;
        } catch (error) {
            console.error('Error al verificar el Username:', error);
            return false; // O manejar de otra manera
        }
    };
    const validateInput = async (input) => {
        // Limpiar cualquier mensaje de validación previo
        input.setCustomValidity('');
        input.classList.remove('is-valid', 'is-invalid');

        // Validaciones personalizadas basadas en el nombre del input
        if (input.name === 'Username') {
            if (input.value.trim() === '')
            {
                input.setCustomValidity('El nombre de usuario es requerido.');
                input.classList.add('is-invalid');
            } else {
                const isUserInUse = await checkUser(input.value);
                if (typeof isUserInUse === 'string') { // User en uso
                    input.setCustomValidity(isUserInUse);
                    input.classList.add('is-invalid');
                } else {
                    input.classList.add('is-valid');
                }
            }

            // Aquí puedes añadir más reglas para 'Username' si es necesario
        } else if (input.name === 'Email') {
            if (input.value.trim() === '') {
                input.setCustomValidity('El correo electrónico es requerido.');
            } else if (!input.value.includes('@')) { // Ejemplo de validación simple
                input.setCustomValidity('Por favor, ingresa un correo electrónico válido.');
            } else {
                const isEmailInUse = await checkEmail(input.value);
                if (typeof isEmailInUse === 'string') { // Email en uso
                    input.setCustomValidity(isEmailInUse);
                    input.classList.add('is-invalid');
                } else {
                    input.classList.add('is-valid');
                }
            }
            
        } else if (input.name === 'Password') {
            if (input.value.length < 6) {
                input.setCustomValidity('La contraseña debe tener al menos 6 caracteres.');
            } else { input.classList.add('is-valid') }
            // Más reglas para 'Password' si es necesario
        } else if (input.name === 'ConfirmPassword') {
            const password = form.querySelector('input[name="Password"]').value;
            if (input.value !== password) {
                input.setCustomValidity('Las contraseñas no coinciden.');
            } else { input.classList.add('is-valid') }
            // Más reglas para 'ConfirmPassword' si es necesario
        }

        // Trigger la validación para mostrar/ocultar el mensaje de error
        input.reportValidity();
    };

    inputs.forEach(input => {
        // Añadir event listener para cada cambio en el input
        input.addEventListener('change', () => validateInput(input));
    });

    form.addEventListener('submit', (event) => {
        let isFormValid = true;

        inputs.forEach(input => {
            validateInput(input); // Validar todos los campos
            if (!input.checkValidity()) {
                isFormValid = false;
            }
        });

        if (!isFormValid) {
            event.preventDefault(); // Prevenir el envío si hay campos inválidos
        }
    });
};

export default validarFormularioRegister;