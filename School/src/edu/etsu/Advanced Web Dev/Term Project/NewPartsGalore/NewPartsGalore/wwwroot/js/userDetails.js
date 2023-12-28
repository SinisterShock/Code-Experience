"use strict";

import { read } from "./userRepository.js";
// pulls the userid from the url
const urlSections = window.location.href.split("/");
const userId = urlSections[5];
// trys to read the user record from the database and set the fields on the page to the user info 
try {
    const user = await read(userId);
    console.log(user);

    setText("#userId", user.id);
    setText("#userTitle", user.title);
    setText("#userFirstName", user.firstName);
    setText("#userLastName", user.lastName);
    setText("#userEmail", user.email);

    setText("#title", `${user.firstName} ${user.lastName} Details`);
}
catch (error) {
    console.log(error);
    window.location.replace("/user/index");
}
// appends the text to the given element
function setText(elementId, text) {
    const element = document.querySelector(elementId);
    element.appendChild(document.createTextNode(text));
}