const path = require("path")

module.exports = {
    mode: "none",
    entry: "./src/ElmishMaze.fsproj",
    devServer: {
        contentBase: path.join(__dirname, "./dist")
    },
    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: "fable-loader"
        }]
    }
}