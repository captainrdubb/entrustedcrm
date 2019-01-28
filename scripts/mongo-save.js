const data = require('./data');

const saveCustomers = async function (mongoWrapper) {
    console.log('saving customers');
    const db = mongoWrapper.db();
    const collection = db.collection("Customer");
    const result = await collection.insertMany(data.customers);
    console.log(result.result);
}

const saveEmployees = async function (mongoWrapper) {
    console.log('saving employees');
    const db = mongoWrapper.db();
    const collection = db.collection("EntrustedUser");
    const result = await collection.insertMany(data.entrustedUsers);
    console.log(result.result);
}

async function loadData(mongoWraper) {
    await saveEmployees(mongoWraper);
    await saveCustomers(mongoWraper);
}

module.exports = loadData;