"use strict";

const baseAddress = "https://localhost:7020/api";

// reads all users from the database
export async function readAll() {
    const address = `${baseAddress}/user/all`;
    const response = await fetch(address);
    if (!response.ok) {
        throw new Error("There was an HTTP error in Read All");
    }
    return await response.json();
}
// reads a single user from the database and returns it
export async function read(id) {
    const address = `${baseAddress}/user/one/${id}`;
    const response = await fetch(address);
    if (!response.ok) {
        throw new Error("There was an HTTP error getting the user data(Read).");
    }
    return await response.json();
}

// creates a user and adds it to the database
export async function create(formData) {
    const address = `${baseAddress}/user/create`;
    const response = await fetch(address, {
        method: "post",
        body: formData
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error creating the user data(Create).");
    }
    return await response.json();
}

// updates an existing user
export async function update(formData) {
    const address = `${baseAddress}/user/update`;
    const response = await fetch(address, {
        method: "put",
        body: formData
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error updating the user data(Update).");
    }
    return await response.text();
}
// deletes a user from the database
export async function deleteUser(id) {
    const address = `${baseAddress}/user/delete/${id}`;
    const response = await fetch(address, {
        method: "delete"
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error deleting the user data(Delete).");
    }
    return await response.text();
}