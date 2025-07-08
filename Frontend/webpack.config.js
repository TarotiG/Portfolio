const path = require('path');

module.exports = {
    entry: {
        mywidget: './React/index.js',
        // je kunt hier meer entry points toevoegen als je meerdere bundles wil
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
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
