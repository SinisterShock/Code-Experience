let purchases = []
let ducks = [
    {
        name : "Barack Obama",
        quote : "Money is not the only answer, but it makes a difference.",
        img : "images/barack_obama.jpg",
        price : 10
    },
    {
        name : "Donald Trump",
        quote : "Everything in life is luck.",
        img : "images/donald_trump.jpg",
        price : 10
    },
    {
        name : "Bruce Springsteen",
        quote : "Walk tall, or baby don't walk at all.",
        img : "images/bruce_springsteen.jpg",
        price : 15
    },
    {
        name : "Dorothy",
        quote : "There's no place like home.",
        img : "images/dorothy_wizard_of_oz.jpg",
        price : 8
    },
    {
        name : "Cowardly Lion",
        quote : "Look at the circles under my eyes. I haven't slept in weeks!",
        img : "images/cowardly_lion_wizard_of_oz.jpg",
        price : 8
    },
    {
        name : "Scarecrow",
        quote : "Some people without brains do an awful lot of talking.",
        img : "images/scarecrow_wizard_of_oz.jpg",
        price : 6
    },
    {
        name : "Tin Man",
        quote : "No one can love who has not a heart",
        img : "images/tin_man_wizard_of_oz.jpg",
        price : 7
    },
    {
        name : "Wicked Witch",
        quote : "I'll get you, my pretty, and your little dog too!",
        img : "images/wicked_witch_wizard_of_oz.jpg",
        price : 5
    },
    {
        name : "Elwood Blues",
        quote : "We're on a mission from God.",
        img : "images/elwood_blues.jpg",
        price : 11
    },
    {
        name : "Jake Blues",
        quote : "This don't look like no expressway to me!",
        img : "images/jake_blues.jpg",
        price : 12
    },
    {
        name : "Gene Simmons",
        quote : "I'm in a weird band",
        img : "images/gene_simmons.jpg",
        price : 13
    },
    {
        name : "Willie Nelson",
        quote : "I don't like to think too far ahead.",
        img : "images/willie_nelson.jpg",
        price : 14
    },
    {
        name : "Harry Potter",
        quote : "Mischief Managed!",
        img : "images/harry_potter.jpg",
        price : 20
    },
    {
        name : "Mr.T",
        quote : "It takes a smart man to play dumb.",
        img : "images/mr_t.jpg",
        price : 18
    },
    {
        name : "Yoda",
        quote : "Fear is the path to the dark side",
        img : "images/yoda.jpg",
        price : 25
    }
]
function getImage() {
    ducks.forEach((duck,num) => {
        document.getElementById("duck" + num).src = duck.img
    })
}
function getName(){
    for (var num = 0; num < ducks.length; num++) {
        document.getElementById("name" + num).innerHTML = ducks[num].name
    }
}
function getQuote(){
    for (var num = 0; num < ducks.length; num++) {
        document.getElementById("quote" + num).innerHTML = ducks[num].quote
    }
}
function getPrice(){
    for (var num = 0; num < ducks.length; num++) {
        document.getElementById("price" + num).innerHTML = "$" + ducks[num].price + " " + '<button id="'+num+'" onclick="purchaseItem(this)">Purchase</button>'
    }
}
function purchaseItem(e){
    purchases.push(ducks[e.id])
    console.log(purchases)
    localStorage.setItem("purchases", JSON.stringify(purchases))
}

getImage()
getName()
getQuote()
getPrice()