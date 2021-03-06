const MUUID = require('uuid-mongodb');
data = {
    customers: [
        {
            "key": MUUID.from("faf45d2e-1c36-4fd3-ab49-bd5548d22937"),
            "status": "Prospective",
            "createdOn": "2019-01-27T20:20:31+00:00",
            "givenName": "John",
            "familyName": "Wick",
            "address": '11715 S 27th St. Bellevue, NE 68123',
            "email": 'john.wick@anderson.com',
            "phone": '4025226092'
        },
        {
            "key": MUUID.from("0d87f022-8aa1-40c8-b128-d812e625d61f"),
            "status": "Current",
            "createdOn": "2019-01-28T23:55:00+00:00",
            "givenName": "Bryan",
            "familyName": "Mills",
            "address": "",
            "email": "bryan.mills@dod.gov",
            "phone": "",
        }
    ],
    entrustedUsers: [
        {
            "key": MUUID.from("9cf080d9-b06c-4fc6-9091-743b061b2067"),
            "givenName": "John",
            "familyName": "Rambo",
            "employeeId": '123456'
        }
    ],
    notes: [
        {
            "key": MUUID.from("96e05130-2a2b-4ca2-8a0c-6877d805db32"),
            "customerKey": MUUID.from("faf45d2e-1c36-4fd3-ab49-bd5548d22937"),
            "createdBy": {
                "key": MUUID.from("9cf080d9-b06c-4fc6-9091-743b061b2067"),
                "givenName": "John",
                "familyName": "Rambo",
            },
            "createdOn": "2019-01-27T20:20:31+00:00",
            "text": "A reliable asset"
        }
    ]
}

module.exports = data;