// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Tasks
//Collect data from form
const regFirstName = document.getElementById('FirstName')
const regLastName = document.getElementById('LastName')
//const regCountry = document.getElementById('Country')
const regEmailAddress = document.getElementById('EmailAddress')
const regPassword = document.getElementById('Password')
const regConfirmPassword = document.getElementById('ConfirmPassword')
const regbtn = document.getElementById('regbtn')


regbtn.addEventListener('click', () => {
    if (regFirstName.value !== "" && regLastName.value !== ""
        && regEmailAddress.value !== "" && regPassword !== "") {
        let data = {
            "FirstName": regFirstName.value,
            "LastName": regLastName.value,
            "EmailAddress": regEmailAddress.value,
            "Password": regPassword.value,
            "ConfirmPassword": regConfirmPassword.value
        }
        fetch("https://localhost:7183/api/Accounts/Identity/Register/AboutYourSelf",
            {
                method: "POST",
                body: JSON.stringify(data),
                headers: {
                    "Content-Type": "application/json"
                }
            }).then(resp => {
                console.log(resp.status)
                if (resp.status === 200) {
                    alert("successful")
                    /*window.location.href = */
                }
            })
            .catch(console.log('Something went wrong'))
    }
})

