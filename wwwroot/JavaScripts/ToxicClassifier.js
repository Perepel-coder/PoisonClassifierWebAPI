const classification = {
    degreeImpactClass: new Set(),
    degreeImpactComment: new Set(),
    aggregateState: new Set()
};
//------------------------------------------------------------------------
async function GetListDegreeImpact() {
    const response = await fetch("/api/UserPage/GetDegreeImpact", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const di = await response.json();
        return di;
    }
}
async function GetListAggregateState() {
    const response = await fetch("/api/UserPage/GetAggregateState", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ast = await response.json();
        return ast;
    }
}
async function GetToxicClassifierExact(data) {
    const response = await fetch("/api/UserPage/GetToxicClassifierExact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetToxicClassifierLax(data) {
    const response = await fetch("/api/UserPage/GetToxicClassifierLax", {
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
    let degreeImpactClass = document.getElementById("degreeImpactClass");
    let degreeImpactComment = document.getElementById("degreeImpactComment");
    let aggregateState = document.getElementById("aggregateState");
    let sc = await GetListDegreeImpact();
    let ast = await GetListAggregateState();
    ast.forEach(el => classification.aggregateState.add(el));
    sc.forEach(el => {
        classification.degreeImpactClass.add(el.class);
        classification.degreeImpactComment.add(el.comment);
    });
    classification.degreeImpactClass.forEach(el => degreeImpactClass.append(CreatOption(el)));
    classification.degreeImpactComment.forEach(el => degreeImpactComment.append(CreatOption(el)));
    classification.aggregateState.forEach(el => aggregateState.append(CreatOption(el)));
   
}
async function SearchButton() {
    let dclass = PackVar("degreeImpactClass");
    let dcomment = PackVar("degreeImpactComment");
    let state = PackVar("aggregateState");
    let class1 = document.getElementById("class1").value;
    let class2 = document.getElementById("class2").value;
    let class3 = document.getElementById("class3").value;
    let class4 = document.getElementById("class4").value;


    data = [dclass, dcomment, state, class1, class2, class3, class4];

    let substance = null;

    if (PackVar("mode") == "Все условия") {
        substance = await GetToxicClassifierExact(data);
    }
    if (PackVar("mode") == "Хотя бы одно условие") {
        substance = await GetToxicClassifierLax(data);
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