const classification = {
    natureImpactGroupName: new Set(),
    natureImpactGroupDescription: new Set(),
    natureImpactGroupNameSG: new Set(),
    origionGroup: new Set(),
    origionSubGroup: new Set(),
    symptoms: new Array()
};
const pOSTClassifierSymptoms = {
    natureImpactAndOrigion: new Array(),
    symptoms: new Array()
};
//------------------------------------------------------------------------
async function GetListNatureImpact() {
    const response = await fetch("/api/UserPage/GetNatureImpacts", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ni = await response.json();
        return ni;
    }
}
async function GetListOrigion() {
    const response = await fetch("/api/UserPage/GetOrigion", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const or = await response.json();
        return or;
    }
}
async function GetListSymptom() {
    const response = await fetch("/api/UserPage/GetSymptom", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const symtoms = await response.json();
        return symtoms;
    }
}
async function GetClassifierSymptomsExact(data) {
    const response = await fetch("/api/UserPage/GetClassifierSymptomsExact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetClassifierSymptomsLax(data) {
    const response = await fetch("/api/UserPage/GetClassifierSymptomsLax", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
//------------------------------------------------------------------------
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

    return tr;
}
function RowSymptom(symptom) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", symptom.id);

    const numTd = document.createElement("td");
    numTd.innerHTML = symptom.id;
    tr.append(numTd);

    const nameTd = document.createElement("td");
    nameTd.innerHTML = symptom.name;
    tr.append(nameTd);

    const checkboxTd = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("data-id", symptom.id);

    checkboxTd.append(checkbox);
    tr.append(checkboxTd);

    return tr;
}
function PackVar(name) {
    let box = document.getElementById(name);
    let cup = box.options[box.selectedIndex];
    if (cup.text == "") { return null; }
    else { return cup.text; }
}
function CreatOption(text) {
    const option = document.createElement("option");
    option.innerHTML = text;
    return option;
}
function DeleteAllChild(node) {
    while (node.firstChild) {
        node.removeChild(node.firstChild);
    }
}
//------------------------------------------------------------------------
async function Load() {
    let natureImpactGroupName = document.getElementById("natureImpactGroupName");
    let natureImpactGroupDescription = document.getElementById("natureImpactGroupDescription");
    let natureImpactGroupNameSG = document.getElementById("natureImpactGroupNameSG");
    let sc = await GetListNatureImpact();
    sc.forEach(el => {
        classification.natureImpactGroupName.add(el.groupName);
        classification.natureImpactGroupDescription.add(el.groupDescription);
        classification.natureImpactGroupNameSG.add(el.groupNameSG);
    });
    classification.natureImpactGroupName.forEach(el => natureImpactGroupName.append(CreatOption(el)));
    classification.natureImpactGroupDescription.forEach(el => natureImpactGroupDescription.append(CreatOption(el)));
    classification.natureImpactGroupNameSG.forEach(el => natureImpactGroupNameSG.append(CreatOption(el)));

    let origionGroup = document.getElementById("origionGroup");
    let origionSubGroup = document.getElementById("origionSubGroup");
    sc = await GetListOrigion();
    sc.forEach(el => {
        classification.origionGroup.add(el.group);
        classification.origionSubGroup.add(el.subGroup);
    });
    classification.origionGroup.forEach(el => origionGroup.append(CreatOption(el)));
    classification.origionSubGroup.forEach(el => origionSubGroup.append(CreatOption(el)));

    let symptoms = await GetListSymptom();
    rows = document.getElementById("symptomTable");
    symptoms.forEach(symptom => {
        rows.append(RowSymptom(symptom));
    });
}
async function SearchButton() {
    let groupName = PackVar("natureImpactGroupName");
    let groupDescription = PackVar("natureImpactGroupDescription");
    let groupNameSG = PackVar("natureImpactGroupNameSG");
    let group = PackVar("origionGroup");
    let subGroup = PackVar("origionSubGroup");
    pOSTClassifierSymptoms.natureImpactAndOrigion = [groupName, groupDescription, groupNameSG, group, subGroup];

    let symptomTable = document.getElementById("symptomTable").rows;
    for (let i = 0; i < symptomTable.length; i++) {
        if (symptomTable[i].lastChild.firstChild.checked) {
            pOSTClassifierSymptoms.symptoms.push(symptomTable[i].firstChild.innerHTML);
        }
    }

    let substance = null;

    if (PackVar("mode") == "Все условия") {
        substance = await GetClassifierSymptomsExact(pOSTClassifierSymptoms);
    }
    if (PackVar("mode") == "Хотя бы одно условие") {
        substance = await GetClassifierSymptomsLax(pOSTClassifierSymptoms);
    }

    if (substance.length == 0)
    {
        alert("Данных нет. Поменяйте условия поиска.");
        let rows = document.getElementById("subtable");
        DeleteAllChild(rows);
        substance.forEach(sub => rows.append(RowSub(sub)));
    }
    else {
        let rows = document.getElementById("subtable");
        DeleteAllChild(rows);
        substance.forEach(sub => rows.append(RowSub(sub)));
    }

}