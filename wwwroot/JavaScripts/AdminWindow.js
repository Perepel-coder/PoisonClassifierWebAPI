async function GetSubstances() {
    const response = await fetch("/api/UserPage/GetSubClasses", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const substances = await response.json();
        return substances;
    }
}
async function DeleteSubstance(id) {
    const response = await fetch("/api/UserPage/DeleteSubstance/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
//------------------------------------------------------------------------------
async function Load() {
    let substance = await GetSubstances();
    let rows = document.getElementById("subtable");
    substance.forEach(sub => rows.append(RowSub(sub)));
}
function DeleteAllChild(node) {
    while (node.firstChild) {
        node.removeChild(node.firstChild);
    }
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
//------------------------------------------------------------------------------
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

    const buttonClassification = document.createElement("td");
    const linkClassification = document.createElement("button");
    linkClassification.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
    linkClassification.setAttribute("data-id", sub.Id);
    linkClassification.append("Открыть");
    linkClassification.addEventListener("click", e => {
        e.preventDefault();
        document.location.href = 'Classifications.html?' + encodeURI(sub.id);
    });
    buttonClassification.append(linkClassification);
    tr.append(buttonClassification);

    const buttonChange = document.createElement("td");
    const linkChange = document.createElement("button");
    linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
    linkChange.setAttribute("data-id", sub.Id);
    linkChange.append("Изменить");
    linkChange.addEventListener("click", e => {
        e.preventDefault();
        document.location.href = 'AdminData.html?' + encodeURI(sub.id);
    });
    buttonChange.append(linkChange);
    tr.append(buttonChange);

    const buttonDel = document.createElement("td");
    const linkDel = document.createElement("button");
    linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
    linkDel.setAttribute("data-id", sub.Id);
    linkDel.append("Удалить");
    linkDel.addEventListener("click", async e => {
        e.preventDefault();
        let flag = await DeleteSubstance(sub.id);
        while (!flag) {}
        DeleteAllChild(document.getElementById("subtable"));
        Load();
    });
    buttonDel.append(linkDel);
    tr.append(buttonDel);

    return tr;
}

function AddData() {
    document.location.href = 'AdminData.html?' + encodeURI(-1);
}
function CreatSubstanceClassTable() {
    localStorage.setItem('objectToPass', "SubstanceClasses");
    document.location.href = 'CreateData.html';
}
function CreatNatureImpactTable() {
    localStorage.setItem('objectToPass', "NatureImpacts");
    document.location.href = 'CreateData.html';
}
function CreatDegreeImpactTable() {
    localStorage.setItem('objectToPass', "DegreeImpacts");
    document.location.href = 'CreateData.html';
}
function CreatOrigionTable() {
    localStorage.setItem('objectToPass', "Origions");
    document.location.href = 'CreateData.html';
}
function CreatAggregateStateTable() {
    localStorage.setItem('objectToPass', "AggregateStates");
    document.location.href = 'CreateData.html';
}
function CreatSymptomTable() {
    localStorage.setItem('objectToPass', "Symptoms");
    document.location.href = 'CreateData.html';
}
function CreatPathTable() {
    localStorage.setItem('objectToPass', "Paths");
    document.location.href = 'CreateData.html';
}
function CreatOrganTable() {
    localStorage.setItem('objectToPass', "Organs");
    document.location.href = 'CreateData.html';
}