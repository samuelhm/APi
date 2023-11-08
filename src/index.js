import bootstrap from 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import "../src/site.css";
import validarFormularioRegister from "../src/ValidarFormularioRegister";

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('registrationForm')) { //Validar solo si existe el formulario con id registrationForm
        validarFormularioRegister();
    }
});