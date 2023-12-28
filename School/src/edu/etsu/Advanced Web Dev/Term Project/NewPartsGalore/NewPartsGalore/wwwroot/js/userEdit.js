'use strict';

import { read, update } from "./userRepository.js";
// removes children from the heading
const userHeading = document.querySelector("#userHeading");
removeChildren(userHeading);
// while the page is loading display loading in the heading
userHeading.appendChild(document.createTextNode("Loading..."));
// pull userId from the url
const urlSections = window.location.href.split("/");
const userId = urlSections[5];
//populate the form with the user data
await populateUserData();
// uses the formdata from the submission to to call the edit function and alter the record
const formUserEdit = document.querySelector("#formUserEdit");
formUserEdit.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(formUserEdit);
    try {
        await update(formData);
        window.location.replace("/user/index/");
    }
    catch (error) {
        console.log(error);
    }
});
// populates the user data and sets the fields using the user info to the given elements
async function populateUserData() {
    try {
        const user = await read(userId);
        console.log(user);
        setText("#Id", user.id);
        setText("#Title", user.title);
        setText("#FirstName", user.firstName);
        setText("#LastName", user.lastName);
        setText("#Email", user.email);
        removeChildren(userHeading);
        userHeading.appendChild(document.createTextNode("Editting the Current User"));
    }
    catch (error) {
        console.log(error);
        window.location.replace("/user/index");
    }
}
// removes children from the given element
function removeChildren(element) {
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}

// sets the value of an element given the ID and text 
function setText(elementId, text) {
    const element = document.querySelector(elementId);
    element.value = text;
}