console.log("Script running");

function getTransactions() {
  console.log("Getting transctions...");
  fetch("/api/Transactions/GetTransactions")
    .then(response => response.json())
    .then(data => displayItems(data));

}



function displayItems(transactions) {
  const tableBody = document.querySelector("#tableBody");

  for (var i = 0; i < transactions.length; i++) {
    const {id, name, date, amount, categoryDto } = transactions[i];
    const tr = document.createElement("tr");
    const tdId = document.createElement("td");
    const tdName = document.createElement("td");
    const tdDate = document.createElement("td");
    const tdAmount = document.createElement("td");
    const tdCategoryName = document.createElement("td");
    let tdButtons = document.createElement('td');
    let editButton = document.createElement('button');
    let deleteButton = document.createElement('button');

    tr.setAttribute('data-id', id);

    editButton.textContent = 'Edit';
    editButton.classList.add('btn');
    editButton.classList.add('btn-info');
    editButton.addEventListener('click', () => {
      displayEditForm(id, name, amount, categoryName);
    });

    tdId.textContent = id;
    tdName.textContent = name;
    tdDate.textContent = date;
    tdAmount.textContent = amount;
    tdCategoryName.textContent = categoryDto.name;
    

    tr.appendChild(tdId);
    tr.appendChild(tdName);
    tr.appendChild(tdDate);
    tr.appendChild(tdAmount);
    tr.appendChild(tdCategoryName);
    tr.appendChild(editButton);
    tableBody.appendChild(tr);
  }
  
  

}


function displayEditForm(id, name, amount, categoryName) {
  const h2 = document.createElement('h2');
  const editForm = document.getElementById('editForm');

  const divFormGroupTransactionName = document.createElement('div');
  const divFormGroupTransactionAmount = document.createElement('div');
  const divFormGroupCategoryName = document.createElement('div');

  const transactionNameLabel = document.createElement('label');
  const transactionAmountLabel = document.createElement('label');
  const categoryNameLabel = document.createElement('label');

  const transactionAmountInput = document.createElement('input');
  const transactionNameInput = document.createElement('input');
  const categoryNameInput = document.createElement('input');

  const submitButton = document.createElement('button');
  const cancelButton = document.createElement('button');



  editForm.innerHTML = '';
  editForm.style.display = 'block';
  editForm.classList.add('px-2');

  h2.textContent = "Edit Transaction";
  h2.classList.add('mt-2');

  divFormGroupTransactionName.classList.add('form-group');
  divFormGroupTransactionName.classList.add('mt-2');
  divFormGroupTransactionAmount.classList.add('form-group');
  divFormGroupTransactionAmount.classList.add('mt-2');
  divFormGroupCategoryName.classList.add('form-group');
  divFormGroupCategoryName.classList.add('mt-2');

  transactionNameLabel.textContent = 'Transaction';
  transactionNameLabel.style.display = 'block';
  transactionAmountLabel.textContent = 'Transaction';
  transactionAmountLabel.style.display = 'block';
  categoryNameLabel.textContent = 'Transaction';
  categoryNameLabel.style.display = 'block';

  transactionNameInput.type = 'text';
  transactionNameInput.value = name;
  transactionAmountInput.type = 'number';
  transactionAmountInput.value = amount;
  categoryNameInput.type = 'text';
  categoryNameInput.value = categoryName;


  cancelButton.classList.add('btn');
  cancelButton.classList.add('btn-info');
  cancelButton.classList.add('mt-2');
  cancelButton.type = 'button';
  cancelButton.addEventListener('click', () => {
    //closeEditForm();
  });
  cancelButton.textContent = 'Cancel';

  submitButton.classList.add('btn');
  submitButton.classList.add('btn-primary');
  submitButton.classList.add('mt-2');
  submitButton.style.marginLeft = '6px';

  submitButton.type = 'submit';
  submitButton.addEventListener('click', () => {
    //editTodo(id, nameInput.value, isCompleteInput.checked);
    //closeEditForm();

  });
  submitButton.textContent = 'Submit';



  divFormGroupTransactionName.appendChild(transactionNameLabel);
  divFormGroupTransactionName.appendChild(transactionNameInput);
  divFormGroupTransactionAmount.appendChild(transactionAmountLabel);
  divFormGroupTransactionAmount.appendChild(transactionAmountInput);
  divFormGroupCategoryName.appendChild(categoryNameLabel);
  divFormGroupCategoryName.appendChild(categoryNameInput);


  editForm.appendChild(h2);
  editForm.appendChild(divFormGroupTransactionName);
  editForm.appendChild(divFormGroupTransactionAmount);
  editForm.appendChild(divFormGroupCategoryName);
  editForm.appendChild(cancelButton);
  editForm.appendChild(submitButton);
}
