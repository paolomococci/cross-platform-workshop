/* extract of javascript code to calculate the length of the data to be sent in JSON format */

const data = {
  "StreetOrSquare": "SomeOne Street",
  "Civic": "15/B",
  "City": "SomeOneCity",
  "District": "SomeOneDistrict",
  "Postcode": "010101",
  "Country": "SomeOneCountry",
  "Email": "some.one@example.local",
  "Phone": "039035801010101",
  "Fax": "039035801010102"
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
