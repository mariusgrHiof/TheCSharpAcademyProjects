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
    const ul = document.createElement('ul');

    for (var i = 0; i < data.length; i++) {
        const { id, name, isComplete } = data[i];
        const li = document.createElement('li');
        li.textContent = `${id} ${name} ${isComplete}`;
        ul.appendChild(li);
    }
    body.appendChild(ul);
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