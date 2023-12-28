"use strict";

import { read } from "./bookRepository.js";
const urlSections = window.location.href.split("/");
const bookId = urlSections[5];
try {
    const book = await read(bookId);
    console.log(book);

    setText("#bookId", book.id);
    setText("#bookTitle", book.title);
    setText("#bookEdition", book.edition);
    setText("#bookPublicationYear", book.publicationYear);
}
catch (error) {
    console.log(error);
    window.location.replace("/home/index");
}

function setText(elementId, text) {
    const element = document.querySelector(elementId);
    element.appendChild(document.createTextNode(text));
}