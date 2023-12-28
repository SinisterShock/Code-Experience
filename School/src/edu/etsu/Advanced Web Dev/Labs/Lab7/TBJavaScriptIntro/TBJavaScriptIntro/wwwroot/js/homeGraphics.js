'use strict';

let widthInput = document.getElementById("widthInput");
let widthDisplay = document.getElementById("widthDisplay");
widthDisplay.value = widthInput.value;
widthInput.addEventListener("input", (e) => {
    widthDisplay.value = widthInput.value;
    ctx.fillStyle = "#FFFFFF";
    ctx.fillRect(0, 0, 800, 400);
    ctx.fillStyle = 'orange';
    drawRectangle(400, 200, widthInput.value, heightInput.value);
});


let heightInput = document.getElementById("heightInput");
let heightDisplay = document.getElementById("heightDisplay");
heightDisplay.value = heightInput.value;

heightInput.addEventListener("input", (e) => {
    heightDisplay.value = heightInput.value;
    ctx.fillStyle = "#FFFFFF";
    ctx.fillRect(0, 0, 800, 400);
    ctx.fillStyle = 'orange';
    drawRectangle(400, 200, widthInput.value, heightInput.value);
});

let c = document.getElementById("drawingArea");
let ctx = c.getContext("2d");

ctx.fillStyle = 'orange';
drawRectangle(400, 200, widthInput.value, heightInput.value);

function drawRectangle(midX, midY, width, height) {
    let sx = midX - width / 2;
    let sy = midY - height / 2;
    ctx.fillRect(sx, sy, width, height);
}