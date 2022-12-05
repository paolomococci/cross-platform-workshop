/* excerpt of javascript code to calculate the data length in JSON format */

const data = {
  "id": 3,
  "streetOrSquare": "SomeOne avenue",
  "civic": "20/D",
  "city": "SomeOneCity",
  "district": "SomeOneDistrict",
  "postcode": "010101",
  "country": "SomeOneCountry",
  "email": "some.one@example.local",
  "phone": "039035801010101",
  "fax": "039035801010102",
  "carriers": [],
  "customers": [],
  "employees": [],
  "suppliers": []
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
