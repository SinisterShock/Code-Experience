'use strict';

import { readAll } from "./bookRepository.js";

let books = await readAll();
const bookTableBody = document.querySelector("#bookTableBody");
console.log(bookTableBody);
books.forEach((book) => {
    console.log(bookTableBody);
    bookTableBody.appendChild(createTRForBook(book));
});

function createTRForBook(book) {
    const tr = document.createElement("tr");
    tr.appendChild(createTD(book.id));
    tr.appendChild(createTD(book.title));
    tr.appendChild(createTD(book.edition));
    tr.appendChild(createTD(book.publicationYear));
    tr.appendChild(createTDWithLinks(book.id));
    return tr;
}

function createTD(text) {
    const td = document.createElement("td");
    td.appendChild(document.createTextNode(text));
    return td;
}
function createTDWithLinks(id) {
    const td = document.createElement("td");
    td.appendChild(createLink(`/book/edit/${id}`, "Edit"));
    td.appendChild(document.createTextNode(" | "));
    td.appendChild(createLink(`/book/details/${id}`, "Details"));
    td.appendChild(document.createTextNode(" | "));
    td.appendChild(createLink(`/book/delete/${id}`, "Delete"));
    return td;
}
function createLink(url, text) {
    const a = document.createElement("a");
    a.setAttribute("href", url);
    a.appendChild(document.createTextNode(text));
    return a;
}