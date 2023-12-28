'use strict';

let rangeInput = document.getElementById("rangeInput");
let rangeDisplay = document.getElementById("rangeDisplay");
let rangeDisplay2 = document.getElementById("rangeDisplay2");

rangeDisplay.value = rangeInput.value;
rangeDisplay2.value = rangeInput.value / 5;

rangeInput.addEventListener("change", (e) => {
    rangeDisplay.value = rangeInput.value;
    rangeDisplay2.value = rangeInput.value / 5;
});