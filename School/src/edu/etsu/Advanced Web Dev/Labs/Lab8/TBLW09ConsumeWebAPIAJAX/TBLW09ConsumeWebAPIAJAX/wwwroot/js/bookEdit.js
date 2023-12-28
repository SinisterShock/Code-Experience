'use strict';

import { read, update } from "./bookRepository.js";
const bookHeading = document.querySelector("#bookHeading");
removeChildren(bookHeading);
bookHeading.appendChild(document.createTextNode("Loading..."));
const urlSections = window.location.href.split("/");
const bookId = urlSections[5];
await populateBookData();
const formBookEdit = document.querySelector("#formBookEdit");
formBookEdit.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(formBookEdit);
    try {
        await update(formData);
        window.location.replace("/home/index/");
    }
    catch (error) {
        console.log(error);
    }
});
async function populateBookData() {
    try {
        const book = await read(bookId);
        console.log(book);
        setText("#Id", book.id);
        setText("#Title", book.title);
        setText("#Edition", book.edition);
        setText("#PublicationYear", book.publicationYear);
        removeChildren(bookHeading);
        bookHeading.appendChild(document.createTextNode("Book"));
    }
    catch (error) {
        console.log(error);
        window.location.replace("/home/index");
    }
}
function removeChildren(element) {
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}

function setText(elementId, text) {
    const element = document.querySelector(elementId);
    element.value = text;
}