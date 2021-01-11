

var passreg = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[~!@#$%^&*.-])[a-zA-Z0-9].{8,}$/;
var emailreg =/^[a-zA-Z0-9]+[.(a-zA-Z0-9)]*(\\@)[a-zA-Z0-9]+(\\.)[a-z]{2,4}$/;

function validate() {

    var email = document.getElementById(email).value;
    var pass = document.getElementById(pass).value;
    alert(email);
    if (emailreg.test(email) && passreg.test(pass)) {
        alert(email);
        
        return true;
    }
    else {
        alert("invalid input");
        return false;
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   