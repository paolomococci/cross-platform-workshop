/* extract of javascript code to calculate the length of the data to be sent in JSON format */

const data = {
  "": ""
}

const dataLength = JSON.stringify(data).length;

console.log(dataLength);
