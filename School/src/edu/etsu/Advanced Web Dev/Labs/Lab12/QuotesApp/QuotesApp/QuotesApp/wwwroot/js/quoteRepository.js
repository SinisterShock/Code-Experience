"use strict";

const address = "https://localhost:7170";

export async function readAllQuotes() {
    const readAllAddress = `${address}/api/quote/all`;
    const response = await fetch(readAllAddress);
    if (!response.ok) {
        throw new Error("There was a ReadAll HTTP error");
    }
    return await response.json();
}

export async function readQuote(id) {
    const readAddress = `${address}/api/quote/one/${id}`;
    const response = await fetch(readAddress);
    if (!response.ok) {
        throw new Error("There was a Read HTTP Error.")
    }
    return await response.json();
}

export async function createQuote(formData) {
    const createAddress = `${address}/api/quote/create`;
    const response = await fetch(createAddress, {
        method: "post",
        body: formData
    });
    if (!response.ok) {
        throw new Error("HTTP Create error")
    }
    return await response.json();
}