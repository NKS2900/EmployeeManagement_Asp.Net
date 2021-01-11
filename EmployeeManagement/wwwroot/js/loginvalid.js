var email = document.forms['loginform']['email'];
var pass = document.forms['loginform']['pass'];

var PasswordPattern = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[~!@#$%^&*.-])[a-zA-Z0-9].{8,}$/;

function validated() {
    if (PasswordPattern.test(email)) {
        console.log("reeeeeee");
        email.style.border = "1px solid red";
        email.focus();
        return false;
    }
}