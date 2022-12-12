// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Tasks
//Collect data from form


const loginEmailAddress = document.getElementById('EmailAddress')
const loginPassWord = document.getElementById('PassWord')
const loginbtn = document.getElementById('loginbtn')
//const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$/
//const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{8,}$/;

loginbtn.addEventListener('click', () => {
    if (loginEmailAddress.value !== "" && loginPassWord.value !== "") {
        let data = {
            "EmailAddress": loginEmailAddress.value,
            "Password": loginPassWord.value
        }
        fetch("https://localhost:7183/api/Accounts/Identity/Login",
            {
                method: "POST",
                body: JSON.stringify(data),
                headers: {
                    "Content-Type":"application/json"
                    }
            })
            .then(resp => {
                console.log(resp.status)
                if (resp.status === 200) {
                    window.location.href = "https://localhost:7183/Products/Product"
                }
            })
            .catch(console.log('Something went wrong'))
    }
})
