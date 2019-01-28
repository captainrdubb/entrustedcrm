const MongoClient = require('mongodb').MongoClient;
const config = require('./config');
const assert = require('assert');

const getClient = async function () {
    return await MongoClient.connect(config.connectionUrl, { useNewUrlParser: true });
}

const getDatabase = function (client) {
    return client.db(config.dbName);
}

async function mongoConnect() {
    console.log('connecting to mongo');
    const client = await getClient();
    const db = getDatabase(client);
    console.log('connected to database: ' + config.dbName);
    return {
        db: () => db,
        dispose: () => client.close()
    };
}

module.exports = mongoConnect;