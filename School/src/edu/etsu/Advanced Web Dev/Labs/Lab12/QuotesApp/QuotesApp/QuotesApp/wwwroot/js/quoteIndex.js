"use strict";

import { readAllQuotes } from "./quoteRepository.js";
import { readQuote } from "./quoteRepository.js";
import { createQuote } from "./quoteRepository.js";

let quotes = await readAllQuotes();
const quoteTableBody = document.querySelector("#quoteTableBody");

quotes.forEach((quote) => {
    console.log(quote);
    quoteTableBody.appendChild(createTRForQuote(quote));
});

function createTRForQuote(quote) {
    const tr = document.createElement("tr");
    tr.appendChild(createTD(quote.id));
    tr.appendChild(createTD(quote.theQuote));
    tr.appendChild((createTD(quote.whoSaidIt)));
    tr.appendChild(createTDWithLinks(quote.id));
    return tr;
}

function createTD(text) {
    const td = document.createElement("td");
    td.appendChild(document.createTextNode(text));
    return td;
}

function createTDWithLinks(id) {
    const td = document.createElement("td");

    let editLink = createLink(`/api/quote/update/${id}`, "Edit");
    editLink.classList.add("btn");
    editLink.classList.add("btn-warning");

    td.appendChild(editLink);

    let deleteLink = createLink(`/api/quote/delete/${id}`, "Delete");
    deleteLink.classList.add("btn");
    deleteLink.classList.add("btn-danger");
    
    td.appendChild(document.createTextNode("   "));
    td.appendChild(deleteLink);
    
    
    return td;
}
function createLink(url, text) {
    const a = document.createElement("a");
    a.setAttribute("href", url);
    a.appendChild(document.createTextNode(text));
    return a;
}

//Submitting the modal form section

(function _quoteModalSubmit() {
    // If there are any error messages, clear them
    _clearErrorMessages();
    const createQuoteModalDOM = document.querySelector("#createQuoteModal");
    const createQuoteModal = new bootstrap.Modal(createQuoteModalDOM);
    const createQuoteButton = document.querySelector("#btnCreateQuote");
    
    const createQuoteForm = document.querySelector("#createQuoteForm");
    createQuoteForm.addEventListener("submit", async (event) => {
        event.preventDefault();
        _clearErrorMessages();
        await _submitWithAjax(createQuoteForm);
    });
    async function _submitWithAjax(createQuoteForm) {
        const formData = new FormData(createQuoteForm);
        let result = createQuote(formData);

        console.log(result);
        quoteTableBody.appendChild(createTRForQuote(result));

        createQuoteModal.hide();
    }
    function _clearErrorMessages() {
        let spans = document.querySelectorAll('span[data-valmsg-for]');
        spans.forEach(s => {
            s.textContent = "";
        });
    }
})()