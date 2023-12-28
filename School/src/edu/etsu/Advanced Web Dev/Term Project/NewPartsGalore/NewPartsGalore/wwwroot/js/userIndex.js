'use strict';

import { readAll } from "./userRepository.js";

// reads all records from the data and logs them in the console and grabs the element for the usertable
let users = await readAll();
const userTableBody = document.querySelector("#userTableBody");
console.log(userTableBody);
users.forEach((user) => {
    console.log(userTableBody);
    userTableBody.appendChild(createTRForUser(user));
});
// creates rows for all the user columns
function createTRForUser(user) {
    const tr = document.createElement("tr");
    tr.appendChild(createTD(user.id));
    tr.appendChild(createTD(user.title));
    tr.appendChild(createTD(user.firstName));
    tr.appendChild(createTD(user.lastName));
    tr.appendChild(createTD(user.email));
    tr.appendChild(createTDWithLinks(user.id));
    return tr;
}

// appends the text into a td element
function createTD(text) {
    const td = document.createElement("td");
    td.appendChild(document.createTextNode(text));
    return td;
}

// creates links to the edit, delete, and details pages to be appended to each record in the table
function createTDWithLinks(id) {
    const td = document.createElement("td");
    let edit = createLink(`/user/edit/${id}`, "Edit");
    edit.classList.add("btn");
    edit.classList.add("bg-warning");
    edit.style.textDecoration = "none";
    edit.style.color = "white";
    td.appendChild(edit);

    td.appendChild(document.createTextNode("   "));
    let details = createLink(`/user/details/${id}`, "Details")
    details.classList.add("btn");
    details.classList.add("bg-success");
    details.style.textDecoration = "none";
    details.style.color = "white";
    td.appendChild(details);

    td.appendChild(document.createTextNode("   "));
    let deleteBtn = createLink(`/user/delete/${id}`, "Delete")
    deleteBtn.classList.add("btn");
    deleteBtn.classList.add("bg-danger");
    deleteBtn.style.textDecoration = "none";
    deleteBtn.style.color = "white";
    td.appendChild(deleteBtn);
    return td;
}
// creates the <a> tag given the value text and url
function createLink(url, text) {
    const a = document.createElement("a");
    a.setAttribute("href", url);
    a.appendChild(document.createTextNode(text));
    return a;
}