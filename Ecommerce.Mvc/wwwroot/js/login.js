// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Tasks
//Collect data from form
const loginEmailAddress = document.getElementById('EmailAddress')
const loginPassWord = document.getElementById('PassWord')
const loginbtn = document.getElementById('loginbtn')

//console.log(loginEmailAddress.value)

//function validateLoginDetails() {
//    alert("Testing")
    //if (loginEmailAddress && loginPassWord) {
    //    let passed = true;
    //    if (loginEmailAddress === "") {
    //        loginEmailAddress.classList.add('text-danger');
    //        loginEmailAddress.innerHTML = "Email or username is required.";
    //        passed = false;
    //    }
    //    if (loginPassWord === "") {
    //        loginPassWord.classList.add('text-danger');
    //        loginPassWord.innerHTML = "Password is required";
    //        passed = false;
    //    }
    //    if (passed === false) {
    //        return false;
    //    }
        //window.location.href = "https://www.securedrecords.com";
    //}
//}

// Confirm email and password when loginbtn (login button is clicked)
loginbtn.addEventListener("click", function () {
    if ((loginEmailAddress && loginPassWord) === true) {
        return alert("true")
    }
    //let passed = true;
    //if (loginEmailAddress.value === "") {
    //    loginEmailAddress.classList.add('text-danger');
    //    loginEmailAddress.innerHTML = "Email or username is required.";
    //    passed = false;
    //    return alert("email")
    //}
    //if (loginPassWord.value === "") {
    //    loginPassWord.classList.add('text-danger');
    //    loginPassWord.innerHTML = "Email or username is required.";
    //    passed = false;
    //    return alert("password")
    //}

});
