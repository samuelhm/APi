import bootstrap from 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import "../src/site.css";
import validarFormularioRegister from "../src/ValidarFormularioRegister";

document.addEventListener('DOMContentLoaded', () => {
    validarFormularioRegister();
});