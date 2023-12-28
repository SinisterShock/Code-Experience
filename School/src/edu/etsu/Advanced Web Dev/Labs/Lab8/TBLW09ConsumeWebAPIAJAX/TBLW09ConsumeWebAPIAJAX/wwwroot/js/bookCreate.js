"use strict";

import { create } from "./bookRepository.js";

const bookCreateForm = document.querySelector("#formCreateBook");
bookCreateForm.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(bookCreateForm);
    const result = await create(formData);
    console.log(result);
    window.location.replace("/home/index");
});

