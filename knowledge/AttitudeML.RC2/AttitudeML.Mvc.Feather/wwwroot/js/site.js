const regex = /^[0-9a-zA-Z.,]*$/;

function validateTypedCharacter(event) {
  let key = event.key;
  if (!regex.test(key)) {
    event.preventDefault();
    return false;
  }
}

function validatePastedString(element, event) {
  let key = event.clipboardData.getData('Text')
  if (!regex.test(key)) {
    event.preventDefault();
    return false;
  }
}
