//Object that contains all the attributes related to the waterbottles at Pauls Reuseables
const waterbottle  = new Object;
        waterbottle[0] = {name: "bubba-black", brand: "bubba", color: "black", price: 16.99};
        waterbottle[1] =  {name: "bubba-blue", brand: "bubba",  color: "blue", price: 16.99};
        waterbottle[2] =  {name: "bubba-purple", brand: "bubba", color: "purple", price: 16.99};
        waterbottle[3] =  {name: "bubba-red", brand: "bubba", color: "red", price: 16.99};
        waterbottle[4] =  {name: "bubba-silver", brand: "bubba", color: "silver", price: 16.99};
        waterbottle[5] =  {name: "camelbak-black", brand: "camelbak", color: "black", price: 11};
        waterbottle[6] =  {name: "camelbak-blue", brand: "camelbak", color: "blue", price: 11};
        waterbottle[7] =  {name: "camelbak-orange", brand: "camelbak", color: "orange", price: 11};
        waterbottle[8] =  {name: "camelbak-purple", brand: "camelbak", color: "purple", price: 11};
        waterbottle[9] =  {name: "camelbak-red", brand: "camelbak", color: "red", price: 11};
        waterbottle[10] =  {name: "drinco-black", brand: "drinco", color: "black", price: 19.95};
        waterbottle[11] =  {name: "drinco-blue", brand: "drinco", color: "blue", price: 19.95};
        waterbottle[12] =  {name: "drinco-orange", brand: "drinco", color: "orange", price: 19.95};
        waterbottle[13] =  {name: "drinco-purple", brand: "drinco", color: "purple", price: 19.95};
        waterbottle[14] =  {name: "drinco-red", brand: "drinco", color: "red", price: 19.95};
        waterbottle[15] =  {name: "nalgene-black", brand: "nalgene", color: "black", price: 9.99};
        waterbottle[16] =  {name: "nalgene-blue", brand: "nalgene", color: "blue", price: 9.99};
        waterbottle[17] =  {name: "nalgene-orange", brand: "nalgene", color: "orange", price: 9.99};
        waterbottle[18] =  {name: "nalgene-purple", brand: "nalgene", color: "purple", price: 9.99};
        waterbottle[19] =  {name: "nalgene-red", brand: "nalgene", color: "red", price: 9.99};
        waterbottle[20] =  {name: "nomader-black", brand: "nomader", color: "black", price: 22.95};
        waterbottle[21] =  {name: "nomader-blue", brand: "nomader", color: "blue", price: 22.95};
        waterbottle[22] =  {name: "nomader-orange", brand: "nomader", color: "orange", price: 22.95};
        waterbottle[23] =  {name: "nomader-purple", brand: "nomader", color: "purple", price: 22.95};
        waterbottle[24] =  {name: "nomader-red", brand: "nomader", color: "red", price: 22.95};
        //Array that stores information that is populated in the cart page
        var cartTally = new Array();

//This function populates the product page upon the page loading  with images of the merchandise and details about the waterbottles
function defaultProduct(){
document.getElementById("content-right").innerHTML = Object.keys(waterbottle).length;
var result = "";
    for(i = 0; i < Object.keys(waterbottle).length; i++){
        result += "<div id=\"content-right-image\"><img class=\"content-image\" src=\"img/waterbottles/"+waterbottle[i].name+".jpg\" />"+
        "<div id=\"content-right-text\"><span><b>Brand: </b>"+waterbottle[i].brand+"</span></br>"+
        "<span><b>Color: </b>"+waterbottle[i].color+"</span></br>"+
        "<span><b>Price: </b>$"+waterbottle[i].price+"</span></br>"+
        "<span><button type=\"button\" onclick=\"addToCart('"+waterbottle[i].brand+"','"+ waterbottle[i].color+"','"+ waterbottle[i].price+"')\">Add</button></span></div></div></div>";

            document.getElementById("content-right").innerHTML = result;
    }

document.getElementById("content-right").innerHTML = result;
}

//This function re populates the product page if you have switch to another page and returned
function addProduct(){
    document.getElementById("content").innerHTML = "";
    document.getElementById("content").innerHTML = "<div id=\"content-left\"></div><div id=\"content-right\"></div>";
    defaultProduct();
}

function addAbout(){
    document.getElementById("content").innerHTML = "";
    document.getElementById("content").innerHTML = "<div id=\"about\">Aliquip eu enim et id adipisicing. Laborum voluptate et esse in minim consequat. Eiusmod exercitation officia do incididunt ad ut nisi dolore veniam aliqua labore cupidatat"+

"Magna aute ullamco nulla pariatur duis velit esse incididunt quis et incididunt ex occaecat nulla. Nulla laborum id quis ullamco id. Labore consequat officia consequat velit. Dolor tempor commodo consectetur dolore culpa sit sunt eiusmod nostrud tempor. Nulla nisi consequat duis mollit voluptate."+

"Irure consequat ipsum et anim anim exercitation enim. Anim exercitation cillum amet tempor sit et sunt eu officia. Sit et consequat velit exercitation do aute.</div>";
}

//This function ads the contents of the contact page by removing the innerHTML of content and adding another div named contact and the elements in the page
function addContact(){
    document.getElementById("content").innerHTML = "";
    document.getElementById("content").innerHTML = "<div id=\"contact\"></div>";
    document.getElementById("contact").innerHTML = "<h2>Need Help?</h2>"+
    "<label for=\"email\">Email:  </label><input type=\"text\" name=\"email\" id=\"email\"></br></br>"+
    "<label for=\"question\">Question: </label><textarea name=\"question\" id=\"question\"></textarea></br>"+
    "<button onclick=\"response()\" type=\"button\">Submit</button>";
}

//This function ads the contents of the cart page by removing the innerHTML of content and adding another div named cart and the elements in the page as well as populating 
//any items that have been selected by the customer
function addCart(){
    document.getElementById("content").innerHTML = "";
    document.getElementById("content").innerHTML = "<div id=\"cart\"></div>";
    cartTally = JSON.parse(localStorage.getItem(0) || "[]");
    var result = "";
    var total = 0;
    var subtotal = 0;
    if(Object.keys(cartTally).length == 0){
        document.getElementById("cart").innerHTML ="<h1>Your Cart is EMPTY!!!</h1>";
    }else{
        let color = "";
        let brand = "";
        let name = "";
        for(i = 0; i < Object.keys(cartTally).length; i++){
            brand = cartTally[i].brand;
            color = cartTally[i].color;
            name =  brand.concat("-",color);
            result += "<div class=\"cart-item\"><img src=\"img/waterbottles/"+name+".jpg\">"+
            "<div><b>Brand: </b>"+String(cartTally[i].brand)+"  <b>Color: </b>"+String(cartTally[i].color)+"  <b>Price: </b>$"+cartTally[i].price+"</div></div></br>";
            subtotal += Number(cartTally[i].price);
        }
        const TAX = 0.095;
        total = Number((subtotal * TAX)+subtotal);
        document.getElementById("cart").innerHTML = result+"<h2>Subtotal: $"+subtotal.toFixed(2)+"</h2><h2>Total: $"+total.toFixed(2)+"</h2>";
    }

}


//This function stores the selected items in localstorage
function addToCart(brand, color, price){
        cartTally = JSON.parse(localStorage.getItem(0) || "[]");
        cartTally.push({"brand": brand, "color": color, "price": price});
        localStorage.setItem(0, JSON.stringify(cartTally));
        //localStorage.clear();
    }

    function response(){
        let email = document.getElementById("email").value;
        
        document.getElementById("contact").innerHTML = "<h2>Need Help?</h2>"+
        "<label for=\"email\">Email:  </label><input type=\"text\" name=\"email\" id=\"email\"></br></br>"+
        "<label for=\"question\">Question: </label><textarea name=\"question\" id=\"question\"></textarea></br>"+
        "<button onclick=\"response()\" type=\"button\">Submit</button><h3>Thank you for contacting us <b>"+email+"</b> someone will be in back with you as soon as possible about your questions.</h3>";
    }