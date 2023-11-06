const path = require('path');

module.exports = {
    mode: 'development', // Cambia a 'production' para la compilación de producción
    entry: './src/index.js', // El punto de entrada de tu aplicación
    output: {
        filename: 'bundle.js', // El archivo de salida
        path: path.resolve(__dirname, 'wwwroot/dist'), // La ruta de salida
    },
    module: {
        rules: [
            // Reglas para CSS
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
            },
            // Puedes agregar más reglas para otros tipos de archivos si es necesario
        ],
    },
};