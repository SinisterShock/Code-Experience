"use strict";

import { create } from "./userRepository.js";

//pulls the form data from the form then uses the AJAX create function
const userCreateForm = document.querySelector("#formCreateUser");
userCreateForm.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(userCreateForm);
    const result = await create(formData);
    console.log(result);
    window.location.replace("/user/index");
});

