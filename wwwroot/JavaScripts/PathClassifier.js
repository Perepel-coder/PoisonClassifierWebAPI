const classification = {
    pathName: new Set(),
    pathOutput: new Set()
};
//------------------------------------------------------------------------
async function GetListOrgan() {
    const response = await fetch("/api/UserPage/GetOrgan", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const organs = await response.json();
        return organs;
    }
}
async function GetListPath() {
    const response = await fetch("/api/UserPage/GetPath", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const paths = await response.json();
        return paths;
    }
}
async function GetPathClassifierExact(data) {
    const response = await fetch("/api/UserPage/GetPathClassifierExact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetPathClassifierLax(data) {
    const response = await fetch("/api/UserPage/GetPathClassifierLax", {
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
function RowOrgan(organ) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", organ.id);

    const nameTd = document.createElement("td");
    nameTd.innerHTML = organ.name;
    tr.append(nameTd);

    const checkboxTd = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("data-id", organ.id);

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
    let pathname = document.getElementById("pathname");
    let pathoutput = document.getElementById("pathoutput");
    let paths = await GetListPath();
    paths.forEach(el => {
        classification.pathName.add(el.name);
        classification.pathOutput.add(el.output);
    });
    classification.pathName.forEach(el => pathname.append(CreatOption(el)));
    classification.pathOutput.forEach(el => pathoutput.append(CreatOption(el)));

    let organs = await GetListOrgan();
    rows = document.getElementById("organTable");
    organs.forEach(organ => {
        rows.append(RowOrgan(organ));
    });

}
async function SearchButton() {
    let name = PackVar("pathname");
    let output = PackVar("pathoutput");
    let data = [name, output];
    let organTable = document.getElementById("organTable").rows;
    for (let i = 0; i < organTable.length; i++) {
        if (organTable[i].lastChild.firstChild.checked) {
            data.push(organTable[i].firstChild.innerHTML);
        }
    }

    let substance = null;

    if (PackVar("mode") == "Все условия") {
        substance = await GetPathClassifierExact(data);
    }
    if (PackVar("mode") == "Хотя бы одно условие") {
        substance = await GetPathClassifierLax(data);
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