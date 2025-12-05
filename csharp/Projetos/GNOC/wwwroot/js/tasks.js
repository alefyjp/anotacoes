
var lastResponse;
function tableRender(response, id) {
    const tBody = document.getElementById(id);
    tBody.innerHTML = ""; // limpa antes de renderizar

    for (let i = 0; i < response.length; i++)
    {
        var item = response[i];
        var tr = document.createElement("tr");

        /*Definindo a cor da tag de prioridade */
        if (item.prioritLevel == "Alta")
        {
            tdPriority = `<td><span class="priorityTag priority-hight"><i class="fa-solid fa-triangle-exclamation"></i> alta</span></td>`;
        }
        else
        {
            tdPriority = `<td><span class="priorityTag priority-normal"><i class="fa-solid fa-face-smile"></i> normal</span></td>`;
        }

        tr.innerHTML = `
          <td>${item.status}</td>
          <td>${item.title}</td>
          <td>${item.description}</td>
          <td>${item.comment}</td>
          <td>${item.sectorName}</td>
          <td>${item.deliveryDate}</td>
          ${tdPriority}
          <td>${item.requesterName}</td>
          <td>${item.agentName}</td>
          <td>
            <button class="btn btn-warning btn-sm" onclick="getTask(${item.id})">
              <i class="fa-solid fa-eye"></i>
            </button>
          </td>
        `;

            tBody.appendChild(tr);
        }
}



/* MODAL ***********************************************************************/
function openModal(id) {
    var modal = document.getElementById(id);
    modal.style.display = 'block';
    modal.classList.add('show')
}

function closeModal(id) {
    var modal = document.getElementById(id);
    modal.style.display = 'none';
    modal.classList.remove('show')
}

/* GET ***********************************************************************/
function getAllTasks()
{
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        lastResponse = JSON.parse(this.responseText)
        tableRender(lastResponse, "tbUsers");
    }
    xhttp.open("GET", "https://localhost:7247/Tasks/Show", true);
    xhttp.send();
}

function getTask(id) {
    task = lastResponse.find(response => response.id === id);
    openModal(task, "task-modal")
}

/* CREATE ***********************************************************************/
function createTask(event) {
    // Impede o envio normal do formulário (que recarregaria a página)
    event.preventDefault();
    //Nova tarefa
    var newTask = {
        title: document.getElementById("title-form-create").value,
        description: document.getElementById("description-form-create").value,
        //sectorId: document.getElementById("sectorid-form-create").value,
        //sectorName: document.getElementById("sectorname-form-create").value,
        //status: document.getElementById("status-form-create").value,
        //deliveryDate: document.getElementById("deliverydate-form-create").value,
        //priorityLevel: document.getElementById("prioritylevel-form-create").value,
        //requesterName: document.getElementById("requestername-form-create").value,
        //agentName: document.getElementById("agentname-form-create").value,
        //comment: document.getElementById("comment-form-create").value
    };

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "https://localhost:7247/Tasks/Create", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    // Define o que fazer quando a resposta chegar
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) { // 4 = requisição finalizada
            if (xhr.status === 200 || xhr.status === 201) {
                alert("Tarefa criada com sucesso!");
                console.log("Resposta do servidor:", xhr.responseText);
            } else {
                alert("Erro ao criar a tarefa. Código: " + xhr.status);
                console.error("Erro:", xhr.responseText);
            }
        }
    };

    // Envia o objeto como JSON
    xhr.send(JSON.stringify(newTask));
}
/* INICIO ***********************************************************************/
getAllTasks();
