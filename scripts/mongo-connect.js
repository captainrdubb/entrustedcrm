const MongoClient = require('mongodb').MongoClient;
const config = require('./config.js');

const getClient = function () {
    return new MongoClient(config.uconnectionUrl);
}

const getDatabase = function (client) {
    return client.db(config.dbName);
}

function mongoConnect() {
    const client = getClient();
    const db = getDatabase(client);
    return {
        db: () => db,
        dispose: () => client.close()
    };
}