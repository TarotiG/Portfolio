const path = require('path');

module.exports = {
    entry: {
        index: './index.jsx',
        certificate: './Componenten/Certificate/Certificate.jsx',
        certificateGallery: './Componenten/Certificate/CertificateGallery.jsx',
        project: './Componenten/Project/Project.jsx',
        projectDescription: './Componenten/Project/ProjectDescription.jsx',
        projectCodeView: './Componenten/Project/ProjectCodeView.jsx',
        pdfViewer: './Componenten/Utilities/PDFViewer.jsx',
        //liveCode: './React/Componenten/LiveCode/',
        //mockApp: './React/Componenten/MockApp/',
        // je kunt hier meer entry points toevoegen als je meerdere bundles wil
    },
    output: {
        path: path.resolve(__dirname, 'C:\\Users\\tyron\\source\\repos\\DevPortfolio\\Frontend\\wwwroot\\js\\'),
        filename: '[name].bundle.js', // bijvoorbeeld: mywidget.bundle.js
        clean: true, // ruim oude bundles op
    },
    resolve: {
        extensions: ['.js', '.jsx'],
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [
                            '@babel/preset-env',
                            '@babel/preset-react',
                        ],
                    },
                },
            },
        ],
    },
    mode: 'development', // of 'production' voor minified output
    devtool: 'source-map', // handig tijdens development
};
