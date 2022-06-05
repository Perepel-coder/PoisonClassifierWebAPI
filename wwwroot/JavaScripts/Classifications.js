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
async function GetListPath(pathIdarray) {
    const response = await fetch("/api/UserPage/GetPath", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(pathIdarray)
    });
    if (response.ok == true) {
        const sc = await response.json();
        return await sc;
    }
}
async function GetListSymptom(symptomIdarray) {
    const response = await fetch("/api/UserPage/GetSymptom", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json"  },
        body: JSON.stringify(symptomIdarray)
    });
    if (response.ok == true) {
        const symtoms = await response.json();
        return await symtoms;
    }
}
//------------------------------------------------------------------------------------------
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

    return tr;
}
//------------------------------------------------------------------------------------------
// при загрузке формы
async function Load() {
    var loc = location.href;
    let subId = decodeURI(loc.substr(loc.indexOf('?') + 1, loc.length - loc.indexOf('?')));

    let substance = await GetSubstance(subId);
    SubstanceInfo(substance);

    let ivenom = await GetIndustrialVenom(substance.iVenomId);
    IndustrialInfo(ivenom);

    let mvenom = await GetMedicalVenom(substance.mVenomId);
    MedicalInfo(mvenom);

    let paths = await GetListPath(ivenom.paths);
    let rows = document.getElementById("pathTable");
    paths.forEach(path => rows.append(RowPath(path)));

    let symptoms = await GetListSymptom(ivenom.symptoms);
    rows = document.getElementsByName("symptomTable");
    symptoms.forEach(symptom =>
    {
        rows[0].append(RowSymptom(symptom));
        rows[1].append(RowSymptom(symptom));
    });
}

// вывод информации о веществе
function SubstanceInfo(sub) {
    let subname = document.getElementsByName("namesub");
    subname.forEach(el => el.value = sub.name);

    let classub = document.getElementsByName("classub");
    classub.forEach(el => el.value = sub.mainClass);

    let chaptersub = document.getElementsByName("chaptersub");
    chaptersub.forEach(el => el.value = sub.chapter);

    let groupsub = document.getElementsByName("groupsub");
    groupsub.forEach(el => el.value = sub.group);

    let subgroupsub = document.getElementsByName("subgroupsub");
    subgroupsub.forEach(el => el.value = sub.subGroup);
}

// вывод информации о промышленной классификации
function IndustrialInfo(ivenom) {
    let natureImpactGroupName = document.getElementsByName("natureImpactGroupName");
    natureImpactGroupName.forEach(el => el.value = ivenom.natureImpactGroupName);

    let natureImpactGroupDescription = document.getElementsByName("natureImpactGroupDescription");
    natureImpactGroupDescription.forEach(el => el.value = ivenom.natureImpactGroupDescription);

    let natureImpactGroupNameSG = document.getElementsByName("natureImpactGroupNameSG");
    natureImpactGroupNameSG.forEach(el => el.value = ivenom.natureImpactGroupNameSG);

    let degreeImpactClass = document.getElementsByName("degreeImpactClass");
    degreeImpactClass.forEach(el => el.value = ivenom.degreeImpactClass);

    let degreeImpactComment = document.getElementsByName("degreeImpactComment");
    degreeImpactComment.forEach(el => el.value = ivenom.degreeImpactComment);

    let class1 = document.getElementsByName("class1");
    class1.forEach(el => el.value = ivenom.dToxicityClass1);

    let class2 = document.getElementsByName("class2");
    class2.forEach(el => el.value = ivenom.dToxicityClass2);

    let class3 = document.getElementsByName("class3");
    class3.forEach(el => el.value = ivenom.dToxicityClass3);

    let class4 = document.getElementsByName("class4");
    class4.forEach(el => el.value = ivenom.dToxicityClass4);
}

// вывод информации о медицинской классификации
function MedicalInfo(ivenom) {

    let origionGroup = document.getElementsByName("origionGroup");
    origionGroup.forEach(el => el.value = ivenom.origionGroup);

    let origionSubGroup = document.getElementsByName("origionSubGroup");
    origionSubGroup.forEach(el => el.value = ivenom.origionSubGroup);

    let aggregateState = document.getElementsByName("aggregateState");
    aggregateState.forEach(el => el.value = ivenom.aggregateState);
}