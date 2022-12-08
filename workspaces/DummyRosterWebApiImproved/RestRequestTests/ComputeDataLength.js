/* extract of javascript code to calculate the length of the data to be sent in JSON format */

const data = {
  "Name": "SomeThree Street",
  "Civic": "101",
  "City": "SomeThreeCity",
  "District": "SomeThreeDistrict",
  "Postcode": "010110",
  "Country": "SomeThreeCountry",
  "Email": "some.three@example.local",
  "Phone": "039035801010113",
  "Fax": "039035801010114"
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
