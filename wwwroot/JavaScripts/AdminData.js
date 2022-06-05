const classification = {
    classub: new Set(),
    chaptersub: new Set(),
    groupsub: new Set(),
    subgroupsub: new Set(),
    natureImpactGroupName: new Set(),
    natureImpactGroupDescription: new Set(),
    natureImpactGroupNameSG: new Set(),
    degreeImpactClass: new Set(),
    degreeImpactComment: new Set(),
    origionGroup: new Set(),
    origionSubGroup: new Set(),
    aggregateState: new Set()
};
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
//-------------------------------------------------------------------------------------
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
function RowPath(path) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", path.id);

    const numTd = document.createElement("td");
    numTd.innerHTML = path.id;
    tr.append(numTd);

    const nameTd = document.createElement("td");
    nameTd.innerHTML = path.name;
    tr.append(nameTd);

    const organsTd = document.createElement("td");
    organsTd.innerHTML = path.organs;
    tr.append(organsTd);

    const outputTd = document.createElement("td");
    outputTd.innerHTML = path.output;
    tr.append(outputTd);

    const checkboxTd = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("data-id", path.id);

    checkboxTd.append(checkbox);
    tr.append(checkboxTd);

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

//------------------------------------------------------------------------------------
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
async function GetSubstance(id) {
    const response = await fetch("/api/UserPage/GetSubstance/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const substance = await response.json();
        return await substance;
    }
}
async function GetIndustrialVenom(id) {
    const response = await fetch("/api/UserPage/GetIndustrialVenom/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const industrialvenom = await response.json();
        return await industrialvenom;
    }
}
async function GetMedicalVenom(id) {
    const response = await fetch("/api/UserPage/GetMedicalVenom/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const medicalvenom = await response.json();
        return await medicalvenom;
    }
}

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
async function GetListSubstanceClassForClass(mainclass) {
    const response = await fetch("/api/UserPage/GetSubstanceClassForClass/" + mainclass, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetListSubstanceClassForChapter(data) {
    const response = await fetch("/api/UserPage/GetSubstanceClassForChapter", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
async function GetListSubstanceClassForGroup(data) {
    const response = await fetch("/api/UserPage/GetSubstanceClassForGroup", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
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
async function GetListNatureImpactForName(name) {
    const response = await fetch("/api/UserPage/GetNIForName/" + name, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const ni = await response.json();
        return ni;
    }
}
async function GetListNatureImpactForDescription(data) {
    const response = await fetch("/api/UserPage/GetNatureImpactForDescription", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
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
async function GetListDegreeForClass(myclass) {
    const response = await fetch("/api/UserPage/GetDegreeImpactForClass/" + myclass, {
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
async function GetListOrigionForGroup(group) {
    const response = await fetch("/api/UserPage/GetOrigionForGroup/" + group, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const or = await response.json();
        return or;
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

async function SaveSubstance(data) {
    const response = await fetch("/api/UserPage/SaveSubstance", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}

async function ChangeSubstance(data) {
    const response = await fetch("/api/UserPage/ChangeSubstance", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return sc;
    }
}
//-------------------------------------------------------------------------------------
async function UploadGeneralData(sub, ivenom, mvenom) {
    let sc = await GetListSubstanceClass();
    let scfc = await GetListSubstanceClassForClass(sub.mainClass);
    let data = [sub.mainClass, sub.chapter];
    let scfch = await GetListSubstanceClassForChapter(data);
    data = [sub.mainClass, sub.chapter, sub.group];
    let scfg = await GetListSubstanceClassForGroup(data);

    sc.forEach(el => classification.classub.add(el.mainClass));
    scfc.forEach(el => classification.chaptersub.add(el.chapter));
    scfch.forEach(el => classification.groupsub.add(el.group));
    scfg.forEach(el => classification.subgroupsub.add(el.subGroup));

    let ni = await GetListNatureImpact();
    let nifm = await GetListNatureImpactForName(ivenom.natureImpactGroupName);
    data = [ivenom.natureImpactGroupName, ivenom.natureImpactGroupDescription];
    let nifd = await GetListNatureImpactForDescription(data);

    ni.forEach(el => classification.natureImpactGroupName.add(el.groupName));
    nifm.forEach(el => classification.natureImpactGroupDescription.add(el.groupDescription));
    nifd.forEach(el => classification.natureImpactGroupNameSG.add(el.groupNameSG));

    let di = await GetListDegreeImpact();
    let difc = await GetListDegreeForClass(ivenom.degreeImpactClass);

    di.forEach(el => classification.degreeImpactClass.add(el.class));
    difc.forEach(el => classification.degreeImpactComment.add(el.comment));

    let or = await GetListOrigion();
    let orfg = await GetListOrigionForGroup(mvenom.origionGroup);

    or.forEach(el => classification.origionGroup.add(el.group));
    orfg.forEach(el => classification.origionSubGroup.add(el.subGroup));

    let ast = await GetListAggregateState();
    ast.forEach(el => classification.aggregateState.add(el));
}

async function Load() {
    var loc = location.href;
    saveData.id = decodeURI(loc.substr(loc.indexOf('?') + 1, loc.length - loc.indexOf('?')));

    if (saveData.id == -1)
    {
        let sub = await GetSubstances();
        let ivenom = await GetIndustrialVenom(sub[0].iVenomId);
        let mvenom = await GetMedicalVenom(sub[0].mVenomId);
        await UploadGeneralData(sub[0], ivenom, mvenom);
        let paths = await GetListPath();
        let rows = document.getElementById("pathTable");
        paths.forEach(path => rows.append(RowPath(path)));

        let symptoms = await GetListSymptom();
        rows = document.getElementById("symptomTable");
        symptoms.forEach(symptom => rows.append(RowSymptom(symptom)));

        ClassificationInfo(classification, sub, ivenom, mvenom, false);
    }
    else {
       
        let sub = await GetSubstance(saveData.id);
        let ivenom = await GetIndustrialVenom(sub.iVenomId);
        let mvenom = await GetMedicalVenom(sub.mVenomId);
        await UploadGeneralData(sub, ivenom, mvenom);
        let paths = await GetListPath();
        let symptoms = await GetListSymptom();

        let rows = document.getElementById("pathTable");
        for (let i = 0; i < paths.length; i++) {
            let row = RowPath(paths[i]);
            for (let j = 0; j < ivenom.paths.length; j++) {
                if (paths[i].id == ivenom.paths[j]) {
                    row.lastChild.firstChild.checked = true;
                }
            }
            rows.append(row);
        }

        rows = document.getElementById("symptomTable");
        for (let i = 0; i < symptoms.length; i++) {
            let row = RowSymptom(symptoms[i]);
            for (let j = 0; j < ivenom.symptoms.length; j++) {
                if (symptoms[i].id == ivenom.symptoms[j]) {
                    row.lastChild.firstChild.checked = true;
                }
            }
            rows.append(row);
        }

        ClassificationInfo(classification, sub, ivenom, mvenom, true);

    }

    
}

function ClassificationInfo(classification, sub, ivenom, mvenom, flag) {
    // класс вещества
    let namesub = document.getElementById("namesub");
    let classub = document.getElementById("classub");
    let chaptersub = document.getElementById("chaptersub");
    let groupsub = document.getElementById("groupsub");
    let subgroupsub = document.getElementById("subgroupsub");

    classub.addEventListener("change", async e => {
        let selectedOptionClassub = classub.options[classub.selectedIndex];
        let sc = await GetListSubstanceClassForClass(selectedOptionClassub.text);

        classification.chaptersub.clear();
        classification.groupsub.clear();
        classification.subgroupsub.clear();
        DeleteAllChild(chaptersub);
        DeleteAllChild(groupsub);
        DeleteAllChild(subgroupsub);

        sc.forEach(el => classification.chaptersub.add(el.chapter));
        sc.forEach(el => classification.groupsub.add(el.group));
        sc.forEach(el => classification.subgroupsub.add(el.subGroup));

        classification.chaptersub.forEach(el => chaptersub.append(CreatOption(el)));
        classification.groupsub.forEach(el => groupsub.append(CreatOption(el)));
        classification.subgroupsub.forEach(el => subgroupsub.append(CreatOption(el)));
    });
    chaptersub.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOptionClassub = classub.options[classub.selectedIndex];
        let selectedOptionChaptersub = chaptersub.options[chaptersub.selectedIndex];

        let data = [selectedOptionClassub.text, selectedOptionChaptersub.text];

        let sc = await GetListSubstanceClassForChapter(data);

        classification.groupsub.clear();
        classification.subgroupsub.clear();
        DeleteAllChild(groupsub);
        DeleteAllChild(subgroupsub);

        sc.forEach(el => classification.groupsub.add(el.group));
        sc.forEach(el => classification.subgroupsub.add(el.subGroup));

        classification.groupsub.forEach(el => groupsub.append(CreatOption(el)));
        classification.subgroupsub.forEach(el => subgroupsub.append(CreatOption(el)));
    });
    groupsub.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOptionClassub = classub.options[classub.selectedIndex];
        let selectedOptionChaptersub = chaptersub.options[chaptersub.selectedIndex];
        let selectedOptionGroupsub = groupsub.options[groupsub.selectedIndex];

        let data = [selectedOptionClassub.text, selectedOptionChaptersub.text, selectedOptionGroupsub.text];

        let sc = await GetListSubstanceClassForGroup(data);

        classification.subgroupsub.clear();
        DeleteAllChild(subgroupsub);

        sc.forEach(el => classification.subgroupsub.add(el.subGroup));

        classification.subgroupsub.forEach(el => subgroupsub.append(CreatOption(el)));
    });

    // характер влияния
    let natureImpactGroupName = document.getElementById("natureImpactGroupName");
    let natureImpactGroupDescription = document.getElementById("natureImpactGroupDescription");
    let natureImpactGroupNameSG = document.getElementById("natureImpactGroupNameSG");

    natureImpactGroupName.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOption = natureImpactGroupName.options[natureImpactGroupName.selectedIndex];
        let ni = await GetListNatureImpactForName(selectedOption.text);

        classification.natureImpactGroupDescription.clear();
        classification.natureImpactGroupNameSG.clear();
        DeleteAllChild(natureImpactGroupDescription);
        DeleteAllChild(natureImpactGroupNameSG);

        ni.forEach(el => classification.natureImpactGroupDescription.add(el.groupDescription));
        ni.forEach(el => classification.natureImpactGroupNameSG.add(el.groupNameSG));

        classification.natureImpactGroupDescription.forEach(el => natureImpactGroupDescription.append(CreatOption(el)));
        classification.natureImpactGroupNameSG.forEach(el => natureImpactGroupNameSG.append(CreatOption(el)));
    });
    natureImpactGroupDescription.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOptionGroupName = classub.options[natureImpactGroupName.selectedIndex];
        let selectedOptionDescription = chaptersub.options[natureImpactGroupDescription.selectedIndex];

        let data = [selectedOptionGroupName.text, selectedOptionDescription.text];
        let ni = await GetListNatureImpactForDescription(data);

        classification.natureImpactGroupNameSG.clear();
        DeleteAllChild(natureImpactGroupNameSG);

        ni.forEach(el => classification.natureImpactGroupNameSG.add(el.groupNameSG));

        classification.natureImpactGroupNameSG.forEach(el => natureImpactGroupNameSG.append(CreatOption(el)));
    });

    // степень воздействия
    let degreeImpactClass = document.getElementById("degreeImpactClass");
    let degreeImpactComment = document.getElementById("degreeImpactComment");

    degreeImpactClass.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOption = degreeImpactClass.options[degreeImpactClass.selectedIndex];
        let di = await GetListDegreeForClass(selectedOption.text);

        classification.degreeImpactComment.clear();
        DeleteAllChild(degreeImpactComment);

        di.forEach(el => classification.degreeImpactComment.add(el.comment));

        classification.degreeImpactComment.forEach(el => degreeImpactComment.append(CreatOption(el)));
    });

    // происхождение
    let origionGroup = document.getElementById("origionGroup");
    let origionSubGroup = document.getElementById("origionSubGroup");

    origionGroup.addEventListener("change", async e => {
        e.preventDefault();
        let selectedOption = origionGroup.options[origionGroup.selectedIndex];
        let or = await GetListOrigionForGroup(selectedOption.text);

        classification.origionSubGroup.clear();
        DeleteAllChild(origionSubGroup);

        or.forEach(el => classification.origionSubGroup.add(el.subGroup));

        classification.origionSubGroup.forEach(el => origionSubGroup.append(CreatOption(el)));
    });
    // агрегатное сосояние
    let aggregateState = document.getElementById("aggregateState");

    //---------------------------------------------------------------------------------------------------------------
    classification.classub.forEach(el => classub.append(CreatOption(el)));
    classification.chaptersub.forEach(el => chaptersub.append(CreatOption(el)));
    classification.groupsub.forEach(el => groupsub.append(CreatOption(el)));
    classification.subgroupsub.forEach(el => subgroupsub.append(CreatOption(el)));

    classification.natureImpactGroupName.forEach(el => natureImpactGroupName.append(CreatOption(el)));
    classification.natureImpactGroupDescription.forEach(el => natureImpactGroupDescription.append(CreatOption(el)));
    classification.natureImpactGroupNameSG.forEach(el => natureImpactGroupNameSG.append(CreatOption(el)));

    classification.degreeImpactClass.forEach(el => degreeImpactClass.append(CreatOption(el)));
    classification.degreeImpactComment.forEach(el => degreeImpactComment.append(CreatOption(el)));

    classification.origionGroup.forEach(el => origionGroup.append(CreatOption(el)));
    classification.origionSubGroup.forEach(el => origionSubGroup.append(CreatOption(el)));

    classification.aggregateState.forEach(el => aggregateState.append(CreatOption(el)));

    if (flag) {
        let dToxicityClass1 = document.getElementById("class1");
        let dToxicityClass2 = document.getElementById("class2");
        let dToxicityClass3 = document.getElementById("class3");
        let dToxicityClass4 = document.getElementById("class4");

        namesub.value = sub.name;
        let id = 0;
        for (let item of classification.classub) {
            if (item == sub.mainClass) { classub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.chaptersub) {
            if (item == sub.chapter) { chaptersub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.groupsub) {
            if (item == sub.group) { groupsub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.subgroupsub) {
            if (item == sub.subGroup) { subgroupsub.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.natureImpactGroupName) {
            if (item == ivenom.natureImpactGroupName) { natureImpactGroupName.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.natureImpactGroupDescription) {
            if (item == ivenom.natureImpactGroupDescription) { natureImpactGroupDescription.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.natureImpactGroupNameSG) {
            if (item == ivenom.natureImpactGroupNameSG) { natureImpactGroupNameSG.selectedIndex = id; } id++;
        }

        dToxicityClass1.value = ivenom.dToxicityClass1;
        dToxicityClass2.value = ivenom.dToxicityClass2;
        dToxicityClass3.value = ivenom.dToxicityClass3;
        dToxicityClass4.value = ivenom.dToxicityClass4;

        id = 0;
        for (let item of classification.degreeImpactClass) {
            if (item == ivenom.degreeImpactClass) { degreeImpactClass.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.degreeImpactComment) {
            if (item == ivenom.degreeImpactComment) { degreeImpactComment.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.origionGroup) {
            if (item == mvenom.origionGroup) { origionGroup.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.origionSubGroup) {
            if (item == mvenom.origionSubGroup) { origionSubGroup.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.aggregateState) {
            if (item == mvenom.aggregateState) { aggregateState.selectedIndex = id; } id++;
        }
    }
    else {
        let id = 0;
        for (let item of classification.classub) {
            if (item == sub.mainClass) { classub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.chaptersub) {
            if (item == sub.chapter) { chaptersub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.groupsub) {
            if (item == sub.group) { groupsub.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.subgroupsub) {
            if (item == sub.subGroup) { subgroupsub.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.natureImpactGroupName) {
            if (item == ivenom.natureImpactGroupName) { natureImpactGroupName.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.natureImpactGroupDescription) {
            if (item == ivenom.natureImpactGroupDescription) { natureImpactGroupDescription.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.natureImpactGroupNameSG) {
            if (item == ivenom.natureImpactGroupNameSG) { natureImpactGroupNameSG.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.degreeImpactClass) {
            if (item == ivenom.degreeImpactClass) { degreeImpactClass.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.degreeImpactComment) {
            if (item == ivenom.degreeImpactComment) { degreeImpactComment.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.origionGroup) {
            if (item == mvenom.origionGroup) { origionGroup.selectedIndex = id; } id++;
        }
        id = 0;
        for (let item of classification.origionSubGroup) {
            if (item == mvenom.origionSubGroup) { origionSubGroup.selectedIndex = id; } id++;
        }

        id = 0;
        for (let item of classification.aggregateState) {
            if (item == mvenom.aggregateState) { aggregateState.selectedIndex = id; } id++;
        }
    }
}

function PackArray(name, array) {
    let box = document.getElementById(name);
    let cup = box.options[box.selectedIndex];
    if (cup.text == "") { array.push(null); }
    else { array.push(cup.text);}
}
function PackVar(name) {
    let box = document.getElementById(name);
    let cup = box.options[box.selectedIndex];
    if (cup.text == "") { return null; }
    else { return cup.text; }
}

async function SaveData() {
    saveData.classub.push(document.getElementById("namesub").value);
    PackArray("classub", saveData.classub);
    PackArray("chaptersub", saveData.classub);
    PackArray("groupsub", saveData.classub);
    PackArray("subgroupsub", saveData.classub);

    PackArray("natureImpactGroupName", saveData.natureImpact);
    PackArray("natureImpactGroupDescription", saveData.natureImpact);
    PackArray("natureImpactGroupNameSG", saveData.natureImpact);

    PackArray("degreeImpactClass", saveData.degreeImpact);
    PackArray("degreeImpactComment", saveData.degreeImpact);

    PackArray("origionGroup", saveData.origion);
    PackArray("origionSubGroup", saveData.origion);

    saveData.aggregateState = PackVar("aggregateState");

    saveData.degreeToxity.push(document.getElementById("class1").value);
    saveData.degreeToxity.push(document.getElementById("class2").value);
    saveData.degreeToxity.push(document.getElementById("class3").value);
    saveData.degreeToxity.push(document.getElementById("class4").value);

    let rows = document.getElementById("symptomTable").rows;
    for (let i = 1; i < rows.length; i++)
    {
        if (rows[i].lastChild.firstChild.checked) {
            saveData.symptoms.push(rows[i].firstChild.innerHTML);
        }
    }
    rows = document.getElementById("pathTable").rows;
    for (let i = 1; i < rows.length; i++) {
        if (rows[i].lastChild.firstChild.checked) {
            saveData.paths.push(rows[i].firstChild.innerHTML);
        }
    }
    if (saveData.id == -1)
    {
        let flag = await SaveSubstance(saveData);
        while (!flag) {}
        document.location.href = 'AdminWindow.html';
    }
    else { ChangeSubstance(saveData);}
}