let saveButton = document.getElementById('buttonSave');
let alertElement = document.getElementById('alert');
let closeButton = null;
let autoHideTimer = null;

saveButton.addEventListener('click', () => {
  let response = "";
  saveButton.disabled = true;
  
  fetch('/Television/Save/', { method: 'POST' })
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.text();
      })
      .then(responseText => {
        response = responseText;
      })
      .catch(error => {
        response = 'Cannot connect to a server';
      })
      .finally(() => {
        alertElement.innerHTML = 
          `${response}
          <button type="button" class="btn-close" aria-label="Close"></button>`;
        
        setUpCloseAlert();
        showAlert();
      });
});

function setUpCloseAlert() {
    closeButton = alertElement.querySelector('.btn-close')
    if (!closeButton) return;
    
    closeButton.addEventListener('click', hideAlertWithCloseButton);
}

function hideAlertWithCloseButton() {
    clearTimeout(autoHideTimer);
    hideAlert();
}

function showAlert() {
  if (alertElement.innerText === '') return;
  alertElement.style.display = 'block';
  alertElement.classList.add('show');
  autoHideTimer = setTimeout(hideAlert, 3000);
}

function hideAlert() {
  closeButton.removeEventListener('click', hideAlertWithCloseButton);
  alertElement.classList.remove('show');
}

setUpCloseAlert();
window.onload = showAlert;