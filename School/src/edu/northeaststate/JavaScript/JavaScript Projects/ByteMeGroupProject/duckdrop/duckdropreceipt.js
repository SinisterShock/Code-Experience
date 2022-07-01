var purchases = JSON.parse(localStorage.getItem("purchases"))
generateList()
function generateList() {
    var receiptlist = document.getElementById("receiptlist")
    var total = 0
    purchases.forEach((purchase) => {
        receiptlist.innerHTML += `<div class='store_item'>
                                    <div><img src='${purchase.img}' alt='duck' /></div>
                                    <div class='store_item_details'>
                                        <div>${purchase.name}</div>
                                        <div>${purchase.quote}</div>
                                        <div>$${purchase.price}</div>
                                    </div>
                                </div>`
    total += purchase.price
    })
    receiptlist.innerHTML += `<div class="total">Your total is: $${total}</div>`
}