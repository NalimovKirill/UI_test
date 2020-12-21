const http = require('http');
const url = require('url');
const port = 6006;

const requestHandler = (request, response) => {

    const query = url.parse(request.url, true).query;

    if (query && query.count && (query.count > 0)) {

        let apiObjects = [
            {countOfProduct: "1", label: "Хлеб", price: "130"},
            {countOfProduct: "2", label: "Масло", price: "110"},
            {countOfProduct: "4", label: "Томат", price: "120"},
            {countOfProduct: "10", label: "Подсолнух", price: "90"},
            {countOfProduct: "11", label: "Пшеница", price: "50"},
            {countOfProduct: "13", label: "Хлеб", price: "150"},
            {countOfProduct: "3", label: "Масло", price: "100"},
            {countOfProduct: "11", label: "Томат", price: "130"},
            {countOfProduct: "5", label: "Подсолнух", price: "160"},
            {countOfProduct: "15", label: "Хлеб", price: "110"},
            {countOfProduct: "7", label: "Масло", price: "70"},
            {countOfProduct: "1", label: "Томат", price: "95"},
            {countOfProduct: "1", label: "Подсолнух", price: "65"},
            {countOfProduct: "8", label: "Пшеница", price: "80"},
            {countOfProduct: "1", label: "Хлеб", price: "130"},
            {countOfProduct: "1", label: "Масло", price: "150"},
            {countOfProduct: "11", label: "Томат", price: "70"},
            {countOfProduct: "1", label: "Подсолнух", price: "90"},
            {countOfProduct: "2", label: "Пшеница", price: "100"}


        ];

        let limit = query.count;
        if (limit > apiObjects.length) {
            limit = apiObjects.length;
        }

        apiObjects = apiObjects.slice(0, limit);
        response.end(JSON.stringify(apiObjects));

    } else {

        response.writeHead(404);
        response.end("Not Found");
    }
};

const server = http.createServer(requestHandler);

server.listen(port, (err) => {

    if (err) {
        return console.log(`Internal Server Error: ${err}`);
    }

    console.log(`Listening on port: ${port}`);
});