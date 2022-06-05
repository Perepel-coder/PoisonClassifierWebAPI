const saveData = {
    id: -1,
    classub: new Array(),
    natureImpact: new Array(),
    degreeImpact: new Array(),
    degreeToxity: new Array(),
    origion: new Array(),
    aggregateState: null,
    symptoms: new Array(),
    paths: new Array()
}
const savePath = {
    id: -1,
    name: null,
    organs: new Array(),
    output: null
}
//-------------------------------------------------------------------------------------------
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
async function GetAggregateStates() {
    const response = await fetch("/api/UserPage/GetAggregateStates", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ast = await response.json();
        return ast;
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
async function GetOrganOfPath(id) {
    const response = await fetch("/api/UserPage/GetOrganOfPath/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const organs = await response.json();
        return organs;
    }
}
//------------------------------------------------------------------------------------------
async function DeleteSubstanceClass(id) {
    const response = await fetch("/api/UserPage/DeleteSubstanceClass/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveSubstanceClass(data) {
    const response = await fetch("/api/UserPage/SaveSubstanceClass", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteNatureImpact(id) {
    const response = await fetch("/api/UserPage/DeleteNatureImpact/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveNatureImpact(data) {
    const response = await fetch("/api/UserPage/SaveNatureImpact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteDegreeImpact(id) {
    const response = await fetch("/api/UserPage/DeleteDegreeImpact/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveDegreeImpact(data) {
    const response = await fetch("/api/UserPage/SaveDegreeImpact", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteOrigion(id) {
    const response = await fetch("/api/UserPage/DeleteOrigion/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveOrigion(data) {
    const response = await fetch("/api/UserPage/SaveOrigion", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteAggregateState(id) {
    const response = await fetch("/api/UserPage/DeleteAggregateState/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveAggregateState(data) {
    const response = await fetch("/api/UserPage/SaveAggregateState", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteSymptom(id) {
    const response = await fetch("/api/UserPage/DeleteSymptom/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveSymptom(data) {
    const response = await fetch("/api/UserPage/SaveSymptom", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeleteOrgan(id) {
    const response = await fetch("/api/UserPage/DeleteOrgan/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SaveOrgan(data) {
    const response = await fetch("/api/UserPage/SaveOrgan", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function DeletePath(id) {
    const response = await fetch("/api/UserPage/DeletePath/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ds = await response.json();
        return await ds;
    }
}
async function SavePath(savePath) {
    const response = await fetch("/api/UserPage/SavePath", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(savePath)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
//------------------------------------------------------------------------------------------
function CreatElement(type, id, myclass) {
    const element = document.createElement(type);
    element.setAttribute("id", id);
    element.setAttribute("type", "text");
    element.setAttribute("class", myclass);
    return element;
}
function CreatTD(text, type) {
    const el = document.createElement(type);
    el.innerHTML = text;
    return el;
}
function Clear() { localStorage.removeItem('objectToPass'); }
function RowOrgan(organ) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", organ.id);

    const idTd = CreatTD(organ.id, "td");
    tr.append(idTd);

    const nameTd = CreatTD(organ.name, "td");
    tr.append(nameTd);

    const checkboxTd = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("data-id", organ.id);

    checkboxTd.append(checkbox);
    tr.append(checkboxTd);

    return tr;
}
//------------------------------------------------------------------------------------------
function CreatSubstanceClassTable(substanceClass, bodyTable) {
    substanceClass.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.mainClass, "td"));
        tr.append(CreatTD(el.chapter, "td"));
        tr.append(CreatTD(el.group, "td"));
        tr.append(CreatTD(el.subGroup, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let mainClass = document.getElementById("idMainClass");
            let chapter = document.getElementById("idChapter");
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            mainClass.value = el.mainClass;
            chapter.value = el.chapter;
            group.value = el.group;
            subGroup.value = el.subGroup;

            saveData.classub[0] = new String(el.id);
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteSubstanceClass(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatNatureImpactTable(natureImpact, bodyTable) {
    natureImpact.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.groupName, "td"));
        tr.append(CreatTD(el.groupDescription, "td"));
        tr.append(CreatTD(el.groupNameSG, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let groupName = document.getElementById("idGroupName");
            let groupDescription = document.getElementById("idGroupDescription");
            let groupNameSG = document.getElementById("idGroupNameSG");

            groupName.value = el.groupName;
            groupDescription.value = el.groupDescription;
            groupNameSG.value = el.groupNameSG;

            saveData.natureImpact[0] = new String(el.id);
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteNatureImpact(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatDegreeImpactTable(degreeImpact, bodyTable) {
    degreeImpact.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.class, "td"));
        tr.append(CreatTD(el.comment, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let dclass = document.getElementById("idClass");
            let comment = document.getElementById("idComment");

            dclass.value = el.class;
            comment.value = el.comment;

            saveData.degreeImpact[0] = new String(el.id);
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteDegreeImpact(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatOrigionTable(origion, bodyTable) {
    origion.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.group, "td"));
        tr.append(CreatTD(el.subGroup, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            group.value = el.group;
            subGroup.value = el.subGroup;

            saveData.origion[0] = new String(el.id);
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteOrigion(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatAggregateStateTable(aggregateState, bodyTable) {
    aggregateState.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.state, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let state = document.getElementById("idState");
            state.value = el.state;
            saveData.id = el.id;
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteAggregateState(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatSymptomTable(symptoms, bodyTable) {
    symptoms.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.name, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let name = document.getElementById("idName");
            name.value = el.name;
            saveData.id = el.id;
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteSymptom(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatOrganTable(organs, bodyTable) {
    organs.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.name, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", e => {
            e.preventDefault();
            let name = document.getElementById("idName");
            name.value = el.name;
            saveData.id = el.id;
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeleteOrgan(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
function CreatPathTable(paths, bodyTable) {
    paths.forEach(el => {
        const tr = document.createElement("tr");
        tr.append(CreatTD(el.id, "td"));
        tr.append(CreatTD(el.name, "td"));
        tr.append(CreatTD(el.organs, "td"));
        tr.append(CreatTD(el.output, "td"));

        const buttonChange = document.createElement("td");
        const linkChange = document.createElement("button");
        linkChange.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkChange.append("Изменить");
        linkChange.addEventListener("click", async e => {
            e.preventDefault();
            let name = document.getElementById("idName");
            let output = document.getElementById("idOutput");
            name.value = el.name;
            output.value = el.output;
            let organs = await GetOrganOfPath(el.id);
            let rows = document.getElementById("idTableOrgan").rows;
            for (let id = 0; id < organs.length; id++) {
                for (let i = 1; i < rows.length; i++) {
                    if (rows[i].firstChild.innerHTML == organs[id]) {
                        rows[i].lastChild.firstChild.checked = true;
                    }
                }
            }
            savePath.id = el.id;
        });
        buttonChange.append(linkChange);
        tr.append(buttonChange);

        const buttonDel = document.createElement("td");
        const linkDel = document.createElement("button");
        linkDel.setAttribute("style", "padding:1%;font-size:100%;width:100%;");
        linkDel.append("Удалить");
        linkDel.addEventListener("click", async e => {
            e.preventDefault();
            let flag = await DeletePath(el.id);
            while (!flag) { }
            location.reload();
        });
        buttonDel.append(linkDel);
        tr.append(buttonDel);

        bodyTable.append(tr);
    });
}
//------------------------------------------------------------------------------------------
async function Load() {
    var table = localStorage['objectToPass'];
    if (table == "SubstanceClasses")
    {
        saveData.classub[0] = "-1";
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idMainClass", "inputsub"));
        creatData.appendChild(CreatElement("input", "idChapter", "inputsub"));
        creatData.appendChild(CreatElement("input", "idGroup", "inputsub"));
        creatData.appendChild(CreatElement("input", "idSubGroup", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.classub[0] = "-1";
            let mainClass = document.getElementById("idMainClass");
            let chapter = document.getElementById("idChapter");
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            if (mainClass.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(mainClass.value); }
            if (chapter.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(chapter.value); }
            if (group.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(group.value); }
            if (subGroup.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(subGroup.value); }
           
            let flag = await SaveSubstanceClass(saveData);

            while (!flag) { }
            location.reload();
            saveData.classub[0] = "-1";
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.classub[0] == "-1") { alert("Необходимо добавить значение в БД."); return; }
            let mainClass = document.getElementById("idMainClass");
            let chapter = document.getElementById("idChapter");
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            if (mainClass.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(mainClass.value); }
            if (chapter.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(chapter.value); }
            if (group.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(group.value); }
            if (subGroup.value == "") { saveData.classub.push(null); }
            else { saveData.classub.push(subGroup.value); }

            let flag = await SaveSubstanceClass(saveData);

            while (!flag) { }
            location.reload();
            saveData.classub[0] = "-1";
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Класс", "th"));
        tr.append(CreatTD("Раздел", "th"));
        tr.append(CreatTD("Группа", "th"));
        tr.append(CreatTD("Подгруппа", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let substanceClass = await GetListSubstanceClass();
        CreatSubstanceClassTable(substanceClass, bodyTable);
        return;
    }
    if (table == "NatureImpacts") {
        saveData.natureImpact[0] = "-1";
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idGroupName", "inputsub"));
        creatData.appendChild(CreatElement("input", "idGroupDescription", "inputsub"));
        creatData.appendChild(CreatElement("input", "idGroupNameSG", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.natureImpact[0] = "-1";
            let groupName = document.getElementById("idGroupName");
            let groupDescription = document.getElementById("idGroupDescription");
            let groupNameSG = document.getElementById("idGroupNameSG");

            if (groupName.value == "") { saveData.natureImpact.push(null);}
            else { saveData.natureImpact.push(groupName.value); }
            if (groupDescription.value == "") { saveData.natureImpact.push(null); }
            else { saveData.natureImpact.push(groupDescription.value); }
            if (groupNameSG.value == "") { saveData.natureImpact.push(null); }
            else { saveData.natureImpact.push(groupNameSG.value); }

            let flag = await SaveNatureImpact(saveData);
            while (!flag) { }
            location.reload();
            saveData.natureImpact[0] = "-1";
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.natureImpact[0] == "-1") { alert("Необходимо добавить значение в БД."); return; }
            let groupName = document.getElementById("idGroupName");
            let groupDescription = document.getElementById("idGroupDescription");
            let groupNameSG = document.getElementById("idGroupNameSG");

            if (groupName.value == "") { saveData.natureImpact.push(null); }
            else { saveData.natureImpact.push(groupName.value); }
            if (groupDescription.value == "") { saveData.natureImpact.push(null); }
            else { saveData.natureImpact.push(groupDescription.value); }
            if (groupNameSG.value == "") { saveData.natureImpact.push(null); }
            else { saveData.natureImpact.push(groupNameSG.value); }

            let flag = await SaveNatureImpact(saveData);
            while (!flag) { }
            location.reload();
            saveData.natureImpact[0] = "-1";
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Группа ", "th"));
        tr.append(CreatTD("Описание", "th"));
        tr.append(CreatTD("Подгруппа", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let natureImpact = await GetListNatureImpact();
        CreatNatureImpactTable(natureImpact, bodyTable);
        return;
    }
    if (table == "DegreeImpacts") {
        saveData.degreeImpact[0] = "-1";
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idClass", "inputsub"));
        creatData.appendChild(CreatElement("input", "idComment", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.degreeImpact[0] = "-1";
            let dclass = document.getElementById("idClass");
            let comment = document.getElementById("idComment");

            if (dclass.value == "") { saveData.degreeImpact.push(null); }
            else { saveData.degreeImpact.push(dclass.value);}
            if (comment.value == "") { saveData.degreeImpact.push(null);}
            else { saveData.degreeImpact.push(comment.value); }   
            
            let flag = await SaveDegreeImpact(saveData);
            while (!flag) { }
            location.reload();
            saveData.degreeImpact[0] = "-1";
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.degreeImpact[0] == "-1") { alert("Необходимо добавить значение в БД."); return; }
            let dclass = document.getElementById("idClass");
            let comment = document.getElementById("idComment");

            if (dclass.value == "") { saveData.degreeImpact.push(null); }
            else { saveData.degreeImpact.push(dclass.value); }
            if (comment.value == "") { saveData.degreeImpact.push(null); }
            else { saveData.degreeImpact.push(comment.value); }

            let flag = await SaveDegreeImpact(saveData);
            while (!flag) { }
            location.reload();
            saveData.degreeImpact[0] = "-1";
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Класс ", "th"));
        tr.append(CreatTD("Описание", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let degreeImpact = await GetListDegreeImpact();
        CreatDegreeImpactTable(degreeImpact, bodyTable);
        return;
    }
    if (table == "Origions") {
        saveData.origion[0] = "-1";
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idGroup", "inputsub"));
        creatData.appendChild(CreatElement("input", "idSubGroup", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.origion[0] = "-1";
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            if (group.value == "") { saveData.origion.push(null); }
            else { saveData.origion.push(group.value); }
            if (subGroup.value == "") { saveData.origion.push(null); }
            else { saveData.origion.push(subGroup.value); }
            
            let flag = await SaveOrigion(saveData);
            while (!flag) { }
            location.reload();
            saveData.origion[0] = "-1";
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.origion[0] == "-1") { alert("Необходимо добавить значение в БД."); return; }
            let group = document.getElementById("idGroup");
            let subGroup = document.getElementById("idSubGroup");

            if (group.value == "") { saveData.origion.push(null); }
            else { saveData.origion.push(group.value); }
            if (subGroup.value == "") { saveData.origion.push(null); }
            else { saveData.origion.push(subGroup.value); }

            let flag = await SaveOrigion(saveData);
            while (!flag) { }
            location.reload();
            saveData.origion[0] = "-1";
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Группа ", "th"));
        tr.append(CreatTD("Подгруппа", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let origion = await GetListOrigion();
        CreatOrigionTable(origion, bodyTable);
        return;
    }
    if (table == "AggregateStates") {
        saveData.id = -1;
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idState", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.id = -1;
            let state = document.getElementById("idState");

            if (state.value == "") { saveData.aggregateState = null; }
            else { saveData.aggregateState = state.value;}

            let flag = await SaveAggregateState(saveData);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.id == -1) { alert("Необходимо добавить значение в БД."); return; }
            let state = document.getElementById("idState");

            if (state.value == "") { saveData.aggregateState = null; }
            else { saveData.aggregateState = state.value; }

            let flag = await SaveAggregateState(saveData);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Состояние ", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let aggregateState = await GetAggregateStates();
        CreatAggregateStateTable(aggregateState, bodyTable);
        return;
    }
    if (table == "Symptoms") {
        saveData.id = -1;
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idName", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.id = -1;
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null;}
            data = [new String(saveData.id), name.value];
            let flag = await SaveSymptom(data);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.id == -1) { alert("Необходимо добавить значение в БД."); return; }
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null; }
            data = [new String(saveData.id), name.value];
            let flag = await SaveSymptom(data);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Симптом", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let symptoms = await GetListSymptom();
        CreatSymptomTable(symptoms, bodyTable);
        return;
    }
    if (table == "Paths")
    {
        savePath.id = -1;
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idName", "inputsub"));
        creatData.appendChild(CreatElement("input", "idOutput", "inputsub"));
        creatData.appendChild(CreatElement("div", "idDivTableOrgan", "border"));
        let DivTableOrgan = document.getElementById("idDivTableOrgan");
        DivTableOrgan.setAttribute("style", "height: 250px; overflow-x: scroll; overflow-y: scroll;");
        DivTableOrgan.appendChild(CreatElement("table", "idTableOrgan"));
        let TableOrgan = document.getElementById("idTableOrgan");
        TableOrgan.appendChild(CreatElement("tbody", "bodyTableOrgan"));
        let bodyTableOrgan = document.getElementById("bodyTableOrgan");
        const theadO = document.createElement("thead");
        const trO = document.createElement("tr");
        trO.append(CreatTD("№", "th"));
        trO.append(CreatTD("Название", "th"));
        trO.append(CreatTD("⚐", "th"));
        theadO.appendChild(trO);
        TableOrgan.appendChild(theadO);
        let organs = await GetListOrgan();
        organs.forEach(organ => {
            bodyTableOrgan.append(RowOrgan(organ));
        });

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            savePath.id = -1;
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null; }
            let output = document.getElementById("idOutput");
            if (output.value == "") { output.value = null; }
            savePath.name = name.value;
            savePath.output = output.value;

            let rows = document.getElementById("idTableOrgan").rows;
            for (let i = 1; i < rows.length; i++) {
                if (rows[i].lastChild.firstChild.checked) {
                    savePath.organs.push(rows[i].firstChild.innerHTML);
                }
            }
            
            let flag = await SavePath(savePath);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (savePath.id == -1) { alert("Необходимо добавить значение в БД."); return; }
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null; }
            let output = document.getElementById("idOutput");
            if (output.value == "") { output.value = null; }
            savePath.name = name.value;
            savePath.output = output.value;

            let rows = document.getElementById("idTableOrgan").rows;
            savePath.organs = new Array();
            for (let i = 1; i < rows.length; i++) {
                if (rows[i].lastChild.firstChild.checked) {
                    savePath.organs.push(rows[i].firstChild.innerHTML);
                }
            }

            let flag = await SavePath(savePath);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Название", "th"));
        tr.append(CreatTD("Органы", "th"));
        tr.append(CreatTD("Выход", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let paths = await GetListPath();
        CreatPathTable(paths, bodyTable);
        return;
    }
    if (table == "Organs") {
        saveData.id = -1;
        let creatData = document.getElementById("creatData");
        creatData.appendChild(CreatElement("input", "idName", "inputsub"));

        let buttonAdd = CreatElement("button", "idSaveAdd", "buttonview");
        buttonAdd.append("Добавить новое значение");
        buttonAdd.addEventListener("click", async e => {
            e.preventDefault();
            saveData.id = -1;
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null; }
            data = [new String(saveData.id), name.value];
            let flag = await SaveOrgan(data);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonAdd);

        let buttonChange = CreatElement("button", "idSaveChange", "buttonview");
        buttonChange.append("Сохранить изменения");
        buttonChange.addEventListener("click", async e => {
            e.preventDefault();
            if (saveData.id == -1) { alert("Необходимо добавить значение в БД."); return; }
            let name = document.getElementById("idName");
            if (name.value == "") { name.value = null; }
            data = [new String(saveData.id), name.value];
            let flag = await SaveOrgan(data);
            while (!flag) { }
            location.reload();
        });
        creatData.appendChild(buttonChange);

        const tableOutput = document.getElementById("tableOutput");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");
        tr.append(CreatTD("№", "th"));
        tr.append(CreatTD("Орган", "th"));
        tr.append(CreatTD("Изменить", "th"));
        tr.append(CreatTD("Удалить", "th"));
        thead.appendChild(tr);
        tableOutput.appendChild(thead);

        const bodyTable = document.getElementById("bodyTable");
        let organs = await GetListOrgan();
        CreatOrganTable(organs, bodyTable);
        return;
    }
}