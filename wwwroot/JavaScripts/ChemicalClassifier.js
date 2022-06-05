const classification = {
    classub: new Set(),
    chaptersub: new Set(),
    groupsub: new Set(),
    subgroupsub: new Set()
};
//------------------------------------------------------------------------
async function GetListSubstanceClass() {
    const response = await fetch("/api/UserPage/GetSubstanceClass", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetChemicalClassifierExact(data) {
    const response = await fetch("/api/UserPage/GetChemicalClassifierExact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetChemicalClassifierLax(data) {
    const response = await fetch("/api/UserPage/GetChemicalClassifierLax", {
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
    let classub = document.getElementById("classub");
    let chaptersub = document.getElementById("chaptersub");
    let groupsub = document.getElementById("groupsub");
    let subgroupsub = document.getElementById("subgroupsub");
    let sc = await GetListSubstanceClass();
    sc.forEach(el => {
        classification.classub.add(el.mainClass);
        classification.chaptersub.add(el.chapter);
        classification.groupsub.add(el.group);
        classification.subgroupsub.add(el.subGroup);
    });

    classification.classub.forEach(el => classub.append(CreatOption(el)));
    classification.chaptersub.forEach(el => chaptersub.append(CreatOption(el)));
    classification.groupsub.forEach(el => groupsub.append(CreatOption(el)));
    classification.subgroupsub.forEach(el => subgroupsub.append(CreatOption(el)));
}
async function SearchButton() {
    let mainClass = PackVar("classub");
    let chapter = PackVar("chaptersub");
    let group = PackVar("groupsub");
    let subgroup = PackVar("subgroupsub");
    let data = [mainClass, chapter, group, subgroup];

    let substance = null;

    if (PackVar("mode") == "Все условия") {
        substance = await GetChemicalClassifierExact(data);
    }
    if (PackVar("mode") == "Хотя бы одно условие") {
        substance = await GetChemicalClassifierLax(data);
    }

    if (substance.length == 0) {
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