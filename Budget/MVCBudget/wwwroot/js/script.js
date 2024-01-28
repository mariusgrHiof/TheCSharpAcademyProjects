console.log("Script running");

function getTransactions() {
    console.log("Getting transctions...");
    fetch("/api/Transactions")
        .then(response => response.json())
        .then(data => displayItems(data));

}

function getCategories() {
    console.log("Getting categories...");
    fetch("/api/categories")
        .then(response => response.json())
        .then(data => displayCategories(data));

}


function displayCategories(data) {
    const selectElement = document.querySelector("#selectId");

    for (var i = 0; i < data.length; i++) {
        const { id, name } = data[i];
        const option = document.createElement("option");
        option.value = id;
        option.text = name;
        selectElement.appendChild(option);
    }

    
}

function displayItems(transactions) {
    const tableBody = document.querySelector("#tableBody");
    tableBody.innerHTML = "";

    getCategories();

    for (var i = 0; i < transactions.length; i++) {
        const { id, name, date, amount, categoryDto } = transactions[i];
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
            displayEditForm(id, name,date, amount, categoryDto);
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


function displayEditForm(transactionId, name,date, amount, category) {
    const h2 = document.createElement('h2');
    const editForm = document.getElementById('editForm');

    const divFormGroupTransactionName = document.createElement('div');
    const divFormGroupTransactionDate = document.createElement('div');
    const divFormGroupTransactionAmount = document.createElement('div');
    const divFormGroupCategoryName = document.createElement('div');

    const transactionNameLabel = document.createElement('label');
    const transactionDateLabel = document.createElement('label');
    const transactionAmountLabel = document.createElement('label');
    const categoryNameLabel = document.createElement('label');

    const transactionNameInput = document.createElement('input');
    const transactionDateInput = document.createElement('input');
    const transactionAmountInput = document.createElement('input');
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
    divFormGroupTransactionDate.classList.add('form-group');
    divFormGroupTransactionDate.classList.add('mt-2');
    divFormGroupTransactionAmount.classList.add('form-group');
    divFormGroupTransactionAmount.classList.add('mt-2');
    divFormGroupCategoryName.classList.add('form-group');
    divFormGroupCategoryName.classList.add('mt-2');

    transactionNameLabel.textContent = 'Transaction';
    transactionNameLabel.style.display = 'block';
    transactionDateLabel.textContent = 'Date';
    transactionDateLabel.style.display = 'block';
    transactionAmountLabel.textContent = 'Transaction';
    transactionAmountLabel.style.display = 'block';
    categoryNameLabel.textContent = 'Category';
    categoryNameLabel.style.display = 'block';

    transactionNameInput.type = 'text';
    transactionNameInput.value = name;
    transactionDateInput.type = 'date';
    transactionDateInput.value = date;
    transactionAmountInput.type = 'number';
    transactionAmountInput.value = amount;
    categoryNameInput.type = 'text';
    categoryNameInput.value = category.name;


    cancelButton.classList.add('btn');
    cancelButton.classList.add('btn-info');
    cancelButton.classList.add('mt-2');
    cancelButton.type = 'button';
    cancelButton.addEventListener('click', () => {
        closeEditForm();
    });
    cancelButton.textContent = 'Cancel';

    submitButton.classList.add('btn');
    submitButton.classList.add('btn-primary');
    submitButton.classList.add('mt-2');
    submitButton.style.marginLeft = '6px';

    submitButton.type = 'submit';
    submitButton.addEventListener('click', () => {
        editTransaction(transactionId,
            transactionNameInput.value,
            transactionAmountInput.value,
            transactionDateInput.value,
            category);
        closeEditForm();

    });
    submitButton.textContent = 'Submit';



    divFormGroupTransactionName.appendChild(transactionNameLabel);
    divFormGroupTransactionName.appendChild(transactionNameInput);
    divFormGroupTransactionDate.appendChild(transactionDateLabel);
    divFormGroupTransactionDate.appendChild(transactionDateInput);
    divFormGroupTransactionAmount.appendChild(transactionAmountLabel);
    divFormGroupTransactionAmount.appendChild(transactionAmountInput);
    divFormGroupCategoryName.appendChild(categoryNameLabel);
    divFormGroupCategoryName.appendChild(categoryNameInput);


    editForm.appendChild(h2);
    editForm.appendChild(divFormGroupTransactionName);
    editForm.appendChild(divFormGroupTransactionDate);
    editForm.appendChild(divFormGroupTransactionAmount);
    editForm.appendChild(divFormGroupCategoryName);
    editForm.appendChild(cancelButton);
    editForm.appendChild(submitButton);
}

function closeEditForm() {
    const editForm = document.getElementById('editForm');
    editForm.innerHTML = '';
}


function editTransaction(transactionId, name, amount, date, category) {

    const updateTransaction = {
        id: transactionId,
        name,
        amount,
        date,
        category: {
            id: category.id,
            name: category.name,
        }

    }

    fetch(`api/transactions`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updateTransaction)
    })
        .then(() => getTransactions())
        .catch(error => console.error('Error', error));
}

function addTransaction(name, amount, date, categoryId) {
    const formEl = document.getElementById("formEl");
    const selectedCategoryId = document.querySelector("#selectId").value;
    const transactionName = document.querySelector("#transactionName").value;
    const transactionAmount =document.querySelector("#transactionAmount").value;
    const transactionDate = document.querySelector("#transactionDate").value;

    console.log(`Add transaction: Name: ${transactionName} Amount: ${transactionAmount} Category Id: ${selectedCategoryId} Date: ${transactionDate}`);

    var newTransaction = {
        name: transactionName,
        date: transactionDate,
        amount: parseInt(transactionAmount),
        categoryId: selectedCategoryId
    }

    fetch("/api/transactions", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(newTransaction)
    })
        .then(response => response.json())
        .then(data => getTransactions())

    formEl.reset();
}