"use strict";
import { read, deleteUser } from "./userRepository.js";
//selects the header and removes the text inside the tag
const userHeading = document.querySelector("#userHeading");
removeChildren(userHeading);
// while the data is loading display this text 
userHeading.appendChild(document.createTextNode("Loading..."));
// selects the id from the url
const urlSections = window.location.href.split("/");
const userId = urlSections[5];
//populates the form with the user data
await populateUserData();
// creates the event for the delete submission and deletes the user using the delete function
const formUserDelete = document.querySelector("#formUserDelete");
formUserDelete.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(formUserDelete);
    try {
        await deleteUser(formData.get("Id"));
        window.location.replace("/user/index/");
    }
    catch (error) {
        console.log(error);
    }
});
// sets the corresponding id fields with the user info
async function populateUserData() {
    try {
        const user = await read(userId);
        console.log(user);
        setText("#Id", user.id);
        setText("#Title", user.title);
        setText("#FirstName", user.firstName);
        setText("#LastName", user.lastName);
        setText("#Email", user.email);
        setValue("#id", user.id);
        removeChildren(userHeading);
        userHeading.appendChild(document.createTextNode("Are you sure you want to delete the current user?"));
    }
    catch (error) {
        console.log(error);
        window.location.replace("/user/index");
    }
}

// the removes all internal children from a given element 
function removeChildren(element) {
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}
// appends text for a given field id
function setText(elementId, text) {
    const element = document.querySelector(elementId);
    element.appendChild(document.createTextNode(text));
}
// sets the value for an element given the id and text
function setValue(elementId, text) {
    const element = document.querySelector(elementId);
    element.value = text;
}