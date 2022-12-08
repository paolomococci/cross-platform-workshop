/* extract of javascript code to calculate the length of the data to be sent in JSON format */

const data = {
  "id": 2,
  "Name": "SomeTwo avenue",
  "Civic": "101/D",
  "City": "SomeTwoCity",
  "District": "SomeTwoDistrict",
  "Postcode": "010110",
  "Country": "SomeTwoCountry",
  "Email": "some.two@example.local",
  "Phone": "039035801010110",
  "Fax": "039035801010111",
  "carriers": [],
  "customers": [],
  "employees": [],
  "suppliers": []
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
