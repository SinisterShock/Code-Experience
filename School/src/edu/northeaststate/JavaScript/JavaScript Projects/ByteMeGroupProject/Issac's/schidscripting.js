
const reciptlist = [];
function createItem(item) {
    h = document.getElementById("itemlist");
    h.insertAdjacentHTML("beforeend", "" +
        "<div id='item' class='" + item.itemName + "'>\n" +
            "<img src='" + item.imgLink + "' alt='" + item.itemName + "'>\n" +
            "<h3>" + item.itemName + "</h3>\n" +
            "<p>" + item.itemDesc + "</p>\n" +
            "<div id='priceAndCart'>\n" +
                "$" + item.itemPrice + "\n" +
                "<button onclick='buy(" + item.id + ")' style='margin-left:5%;'>Buy</button>\n" +
            "</div>\n" +
        "</div>\n");
}

function addToRecipt(id) {
    var item = itemsList[id];
    h = document.getElementById("recipt");
    h.insertAdjacentHTML("beforeend", "" +
        "<tr>\n" +
            "<th>" + item.itemName + "</th>\n" +
            "<th>" + item.itemPrice + "</th>\n"+
        "</tr>");
    var pretotal = parseFloat(calcTotal()).toFixed(2);
    var taxedtotal = parseFloat(1.1*calcTotal()).toFixed(2);
    var tax = parseFloat(taxedtotal - pretotal).toFixed(2);
    document.getElementById("pretax").innerHTML =  "Pre-Tax Total: " + pretotal;
    document.getElementById("tax").innerHTML =  "Tax (10%): " + tax;
    document.getElementById("total").innerHTML =  "Final Total: " + taxedtotal;
}

class Crystal {
    constructor(id, name, price, link, desc) {
        this.id = id;
        this.itemName = name;
        this.itemPrice = price;
        this.imgLink = link;
        this.itemDesc = desc;
    }
}

const clearQuartz = new Crystal(
    0,
    "ClearQuartz",
    5.99,
    "images\\crystals\\Clear Quartz.png",
    "Revitalises the physical, mental, emotional and spiritual planes."
);

const amethyst = new Crystal(
    1,
    "Amethyst",
    10.99,
    "images\\crystals\\Amethyst.jpg",
    "Brings forth humility, sincerity, and spiritual wisdom."
);

const obsidian = new Crystal(
    2,
    "Obsidian",
    13.99,
    "images\\crystals\\Obsidian.jpg",
    "Forms a shield against negativity and absorbs negative energies from the environment."
);

const roseQuartz = new Crystal(
    3,
    "RoseQuartz",
    9.99,
    "images\\crystals\\Rose Quartz.jpg",
    "Promotes love, self-love, friendship, deep inner healing and feelings of peace."
);

const smokeyQuartz = new Crystal(
    4,
    "SmokeyQuartz",
    11.99,
    "images\\crystals\\Smokey Quartz.jpg",
    "Dispel negative energy, detoxifies the body and energy field from lower vibrations."
);



function makeItemList(){
    createItem(clearQuartz);
    createItem(amethyst);
    createItem(obsidian);
    createItem(roseQuartz);
    createItem(smokeyQuartz);
}

// recipt stuff V V
function buy(id){
    reciptlist.push(id);
    localStorage.setItem("recipt", (reciptlist));
    console.log("adding " + id + itemsList[id].itemName);
}

function calcTotal(){
    total = 0.0;
    var temp = (localStorage.getItem("recipt"));
    for (let i = 0; i < temp.length; i++) {
        if(temp[i] != ','){
            total += itemsList[temp[i]].itemPrice;
        }
    }
    return total;
}

function createlist(){
    console.log("test0");
    var temp = (localStorage.getItem("recipt"));

    console.log(temp);
    for (let i = 0; i < temp.length; i++) {
        if(temp[i] != ','){
            addToRecipt(temp[i]);
        }
    }
}

const itemsList = [clearQuartz, amethyst, obsidian, roseQuartz, smokeyQuartz];