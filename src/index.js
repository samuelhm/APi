import bootstrap from 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import "../src/site.css";

import checkEmailUniqueness from '../src/validarEmail';

// Asegúrate de que el DOM esté completamente cargado antes de añadir manejadores de eventos
document.addEventListener('DOMContentLoaded', function () {
    // Asumiendo que tienes campos con estos ID en tu formulario
    checkEmailUniqueness('Email', 'registrationForm');
});