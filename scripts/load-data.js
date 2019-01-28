const connect = require('./mongo-connect');
const save = require('./mongo-save');

async function loadData() {
    try {
        console.log('load data start');
        const mongoWrapper = await connect();
        await save(mongoWrapper);
        mongoWrapper.dispose();
        console.log('load data finished');
    }
    catch(error)
    {
        console.log(error);
    }
}

loadData();