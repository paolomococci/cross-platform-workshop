/* extract of javascript code to calculate the length of the data to be sent in JSON format */

const data = {
  "StreetOrSquare": "SomeTwo Street",
  "Civic": "101",
  "City": "SomeTwoCity",
  "District": "SomeTwoDistrict",
  "Postcode": "010110",
  "Country": "SomeTwoCountry",
  "Email": "some.one@example.local",
  "Phone": "039035801010110",
  "Fax": "039035801010111"
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
