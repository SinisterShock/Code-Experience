'use strict';


let ltg = (LitersUsed) => {
    let gallons = LitersUsed * 0.264179;
    return gallons;
}

console.log(ltg(1));
console.log(ltg(100));

function calculateMPG(liters, traveledMiles) {
    let gallon = ltg(liters);
    let calMPG = traveledMiles / gallon;
    return calMPG;
}

console.log(calculateMPG(3.78541, 100));

let calculateButton = document.getElementById("calculateBtn");
calculateButton.addEventListener("click", (e) => {
    let litersUsed = document.getElementById("LitersUsed").value;
    let milestraveled = document.getElementById("MilesTraveled").value;
    let milesPerGallon = calculateMPG(litersUsed, milestraveled);
    document.getElementById("milesPerGallon").value = milesPerGallon;
});
