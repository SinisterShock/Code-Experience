'use strict';


let ltg = (LitersUsed) => {
    let gallons = LitersUsed * 0.264179;
    return gallons;
}


function calculateMPG(liters, traveledMiles) {
    let gallon = ltg(liters);
    let calMPG = traveledMiles / gallon;
    return calMPG;
}



function createTD(text) {
    const domTD = document.createElement("td");
    domTD.innerText = text;
    return domTD;
}

function createTR(object) {
    const domTR = document.createElement("tr");
    for (const property in object) {
        domTR.appendChild(createTD(`${object[property]}`));
    }
    return domTR;
}

function appendtoTableBody(idSelector, object) {
    let table = document.getElementById(`${idSelector}`);
    table.appendChild(createTR(object));
}

//console.log(createTD("test"));
//console.log(createTR({ name: "Tyler", age: "100" }));

//let litersUsed = 3.78541;
//let milesTraveled = 100;
//let milesPerGallon = calculateMPG(litersUsed, milesTraveled);
//let object = { litersUsed, milesTraveled, milesPerGallon };
//appendtoTableBody("mpgTableBody", object);

let calculateButton = document.getElementById("calculateBtn");

calculateButton.addEventListener("click", (e) => {
    let litersUsed = document.getElementById("litersUsed").value;
    let milesTraveled = document.getElementById("milesTraveled").value;
    let milesPerGallon = calculateMPG(litersUsed, milesTraveled);
    let object = { litersUsed, milesTraveled, milesPerGallon };
    appendtoTableBody("mpgTableBody", object);
});

