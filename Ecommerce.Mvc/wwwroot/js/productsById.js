alert("api test")
async function redirectToProduct(index) {
    var url = "https://localhost:7183/api/Products/GetProductById/" + index;
    const response = await fetch(url);
    var data = await response.json();
    window.location.href = url;
}
