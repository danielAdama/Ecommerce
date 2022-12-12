
async function getapi(url) {
    const response = await fetch(url);
    var data = await response.json();
    //if (response) {
    //    console.log(data)
    //}
    show(data);
}


function val(price) {
    // Function to grab the current elements
    // and discard the rest
    if (price.length > 0) {
        return price.shift();
    }
}

function replaceHTMLelements(elements, list, sign = false ) {
    for (var j = 0; j < elements.length; j++) {
        obj = val(list)
        if (sign) {
            console.log(elements[j].innerHTML = `$ ${obj}`)
        } else {
            console.log(elements[j].innerHTML = `${obj}`)
        }
        
    }
}

function availProd(elements, list) {
    for (var j = 0; j < elements.length; j++) {
        obj = val(list)
        if (obj) {
            console.log(elements[j].innerHTML = "Available")
        } else {
            console.log(elements[j].innerHTML = "Out of stock")
        }
    }

}

function prodCat(elements, list) {
    for (var j = 0; j < elements.length; j++) {
        obj = val(list)
        if (obj === 1) {
            console.log(elements[j].innerHTML = "Laptop")
        } if (obj === 2) {
            console.log(elements[j].innerHTML = "Phone")
        } if (obj === 3) {
            console.log(elements[j].innerHTML = "Shorts")
        } if (obj === 4) {
            console.log(elements[j].innerHTML = "Jacket")
        } if (obj === 5) {
            console.log(elements[j].innerHTML = "Shirt")
        } if (obj === 6) {
            console.log(elements[j].innerHTML = "Trouser")
        } if (obj === 7) {
            console.log(elements[j].innerHTML = "Sweat Pants")
        } 
        
    }

}


function show(data) {
    nameList = [];
    priceList = [];
    categoryList = [];
    availableList = [];
    const myDiv = document.querySelector('#cont');

    const prices = myDiv.querySelectorAll('h6');
    const names = myDiv.querySelectorAll('h5');
    const categories = myDiv.querySelectorAll('h9');
    const availableProducts = myDiv.querySelectorAll('p');

    for (let i = 0; i < data.length; i++) {
        // Store elements in a list
        nameList.push(data[i].name); 
        priceList.push(data[i].price);
        categoryList.push(data[i].productCategory);
        availableList.push(data[i].isAvailable);
    };
    replaceHTMLelements(names, nameList)
    replaceHTMLelements(prices, priceList, sign = true)
    availProd(availableProducts, availableList)
    prodCat(categories, categoryList)
}

getapi("https://localhost:7183/api/Products/GetAllProducts")