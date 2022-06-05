async function GetAutorization(data) {
    const response = await fetch("/api/UserPage/GetAutorization", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetSubstances() {
    const response = await fetch("/api/UserPage/GetSubClasses", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const substances = await response.json();
        let rows = document.querySelector("tbody");
        substances.forEach(sub => rows.append(RowSub(sub)));
    }
}
async function GetSearch(name) {
    const response = await fetch("/api/UserPage/GetSearch/" + name, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const substances = await response.json();
        let rows = document.querySelector("tbody");
        DeleteAllChild(rows);
        substances.forEach(sub => rows.append(RowSub(sub)));
    }
}
//------------------------------------------------------------------------------
function DeleteAllChild(node) {
    while (node.firstChild) {
        node.removeChild(node.firstChild);
    }
}
// создание строки для таблицы
function RowSub(sub) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", sub.id);

    const nameTd = document.createElement("td");
    nameTd.innerHTML = sub.name;
    tr.append(nameTd);

    const mainClassTd = document.createElement("td");
    mainClassTd.innerHTML = sub.mainClass;
    tr.append(mainClassTd);

    const chapterTd = document.createElement("td");
    chapterTd.innerHTML = sub.chapter;
    tr.append(chapterTd);

    const groupTd = document.createElement("td");
    groupTd.innerHTML = sub.group;
    tr.append(groupTd);

    const subGroupTd = document.createElement("td");
    subGroupTd.innerHTML = sub.subGroup;
    tr.append(subGroupTd);

    const buttonlink = document.createElement("td");
    const link = document.createElement("button");
    link.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
    link.setAttribute("data-id", sub.Id);
    link.append("Открыть");
    link.addEventListener("click", e => {
        e.preventDefault();
        document.location.href = 'Classifications.html?' + encodeURI(sub.id);
    });
    buttonlink.append(link);
    tr.append(buttonlink);

    return tr;
}

function ChemicalClassifier() {
    document.location.href = 'ChemicalClassifier.html';
}
function ClassifierSymptoms() {
    document.location.href = 'ClassifierSymptoms.html';
}
function ToxicClassifier() {
    document.location.href = 'ToxicClassifier.html';
}
function PathClassifier() {
    document.location.href = 'PathClassifier.html';
}
async function Autorization() {
    let login = document.getElementById("login");
    let password = document.getElementById("password");
    let flag = await GetAutorization([login.value, password.value]);
    if (flag) { document.location.href = 'AdminWindow.html'; }
    else { alert("Не верный логин или пароль");}
}

async function Search() {
    let search = document.getElementById("search");
    GetSearch(search.value);
}