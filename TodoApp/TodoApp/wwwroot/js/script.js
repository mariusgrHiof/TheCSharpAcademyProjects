console.log('Program started');

function getTodos() {
    console.log('Getting todos...');
    fetch('api/todoItems')
        .then(response => response.json())
        .then(data => displayItems(data));
}

function displayItems(data) {
    const body = document.getElementById('body');
    body.innerHTML = '';
  

    for (var i = 0; i < data.length; i++) {
        const {id, name, isComplete } = data[i];
        let tr = document.createElement('tr');
        let tdName = document.createElement('td');
        let tdIsComplete = document.createElement('td');
        let tdButtons = document.createElement('td');

        let editButton = document.createElement('button');
        let deleteButton = document.createElement('button');

        editButton.textContent = 'Edit';
        editButton.classList.add('btn');
        editButton.classList.add('btn-info');
        editButton.addEventListener('click', () => {
            displayEditForm(id,name, isComplete);
        });

        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('btn');
        deleteButton.classList.add('btn-danger');
        deleteButton.style.marginLeft = "20px";


        tdName.textContent = name;
        tdIsComplete.textContent = isComplete;

        tdButtons.appendChild(editButton);
        tdButtons.appendChild(deleteButton);

        tr.appendChild(tdName);
        tr.appendChild(tdIsComplete);
        tr.appendChild(tdButtons);
        body.appendChild(tr);
    }
    
 }

function addTodo() {
   const todoName = document.getElementById('todoName');
   const todoIsComplete = document.getElementById('todoIsComplete');

    const newTodo = {
        name: todoName.value,
        isComplete: todoIsComplete.checked
    }
     
    fetch('api/todoItems', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newTodo)
    })
        .then(response => response.json())
        .then(() => getTodos())
        .catch(error => console.error('Error:', error));

    todoName.value = '';
    todoIsComplete.checked = false;
}

function displayEditForm(id, name, isComplete) {
    const editForm = document.getElementById('editForm');
    editForm.innerHTML = '';
    editForm.style.display = 'block';
    
    const nameInput = document.createElement('input');
    nameInput.type = 'text';
    nameInput.value = name;

    const isCompleteInput = document.createElement('input');
    isCompleteInput.type = 'checkbox';
    isCompleteInput.checked = isComplete;


    var submitButton = document.createElement('button');
    submitButton.type = 'submit';
    submitButton.addEventListener('click', () => {
        editTodo(id, nameInput.value, isCompleteInput.checked);
        getTodos();
        editForm.style.display = 'none';
    });
    submitButton.textContent = 'Submit';

    editForm.appendChild(nameInput);
    editForm.appendChild(isCompleteInput);
    editForm.appendChild(submitButton);

}
function editTodo(id, todoName, todoIsComplete) {
    console.log(`Edit todo with id: ${id}`);

    const updateTodo = {
        id: id,
        name: todoName,
        isComplete: todoIsComplete
    }

    fetch(`api/todoItems/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updateTodo)
    })
        .then(response => console.log('Todo updated'))
        .catch(error => console.error('Error', error));

}