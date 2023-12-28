'use strict';

const baseAddress = "https://localhost:7129/api";

export async function readAll() {
    const address = `${baseAddress}/book/all`;
    const response = await fetch(address);
    if (!response.ok) {
        throw new Error("There was an HTTP error");
    }
    return await response.json();
}

export async function read(id) {
    const address = `${baseAddress}/book/one/${id}`;
    const response = await fetch(address);
    if (!response.ok) {
        throw new Error("There was an HTTP error getting the book data.");
    }
    return await response.json();
}

export async function create(formData) {
    const address = `${baseAddress}/book/create`;
    const response = await fetch(address, {
        method: "post",
        body: formData
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error creating the pet data.");
    }
    return await response.json();
}

export async function update(formData) {
    const address = `${baseAddress}/book/update`;
    const response = await fetch(address, {
        method: "put",
        body: formData
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error updating the book data.");
    }
    return await response.text();
}

export async function deleteBook(id) {
    const address = `${baseAddress}/book/delete/${id}`;
    const response = await fetch(address, {
        method: "delete"
    });
    if (!response.ok) {
        throw new Error("There was an HTTP error deleting the book data.");
    }
    return await response.text();
}