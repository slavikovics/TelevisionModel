var saveButton = document.getElementById('buttonSave');

saveButton.addEventListener('click', function(){
  fetch('/Television/Save/', {method: 'POST'})
})

var alertElement = document.getElementById('alert');
var closeButton = alertElement.querySelector('.btn-close');

function showAlert() {
  alertElement.classList.add('show');
}

function hideAlert() {
  alertElement.classList.remove('show');
  setTimeout(function() {
    alertElement.style.display = 'none';
}, 500);
}

closeButton.addEventListener('click', hideAlert);
setTimeout(hideAlert, 3000);

window.onload = showAlert;