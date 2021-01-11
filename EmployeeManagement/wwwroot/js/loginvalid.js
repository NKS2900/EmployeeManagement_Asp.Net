
function validate() {

    var passreg = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[~!@#$%^&*.-])[a-zA-Z0-9].{8,}$/;
    var emailreg = /^[a-zA-Z0-9.]{1,}@[a-z]{1,5}[.a-z]{1,5}[.]{1}[a-z]{1,4}$/;

    var testemail = document.getElementById('email').value;
    var testpass = document.getElementById('pass').value;

    if (testemail.match(emailreg)) {

        if (testpass.match(passreg)) {
            return true;
        }
        else {
            alert("Invalid Password.");
            return false;
        }
    }
    else {
        alert("Invalid email.");
        return false;
    }
    
}                                                                                                                                                          