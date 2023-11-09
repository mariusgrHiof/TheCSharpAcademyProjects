console.log('Program started');

function getTodos() {
    console.log('Getting todos...');
    fetch('api/todoItems')
        .then(response => response.json())
        .then(data => displayItems(data));
}

function displayItems(data) {
    const body = document.getElementById('body');
    const ul = document.createElement('ul');

    for (var i = 0; i < data.length; i++) {
        const { id, name, isComplete } = data[i];
        const li = document.createElement('li');
        li.textContent = `${id} ${name} ${isComplete}`;
        ul.appendChild(li);
    }
    body.appendChild(ul);
 }
