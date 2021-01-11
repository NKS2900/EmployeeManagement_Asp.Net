
function validate() {

    var namereg =/^[A-Z]{1}[a-zA-Z]{2,}$/;
    var passreg = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[~!@#$%^&*.-])[a-zA-Z0-9].{8,}$/;
    var emailreg = /^[a-zA-Z0-9.]{1,}@[a-z]{1,5}[.a-z]{1,5}[.]{1}[a-z]{1,4}$/;
    var contactreg = /^[0-9]{10}$/;
    var cityreg = /^[a-zA-Z]{3,}$/;
    var pincodereg = /^[0-9]{6}$/;
    var testfname = document.getElementById('firstname').value;
    var testlname = document.getElementById('lastname').value;
    var testemail = document.getElementById('email').value;
    var testcontact = document.getElementById('contact').value;
    var testcity = document.getElementById('city').value;
    var teststate = document.getElementById('state').value;
    var testpincode = document.getElementById('pincode').value;
    var testpass = document.getElementById('password').value;
    var testcpass = document.getElementById('cpassword').value;


    if (testfname.match(namereg)) {

        if (testlname.match(namereg)) {
            if (testemail.match(emailreg)) {
                if (testcontact.match(contactreg)) {
                    if (testcity.match(cityreg)) {
                        if (teststate.match(cityreg)) {
                            if (testpincode.match(pincodereg)) {
                                if (testpass.match(passreg)) {
                                    if (testpass==testcpass) {
                                        return true;
                                    }
                                    else {
                                        alert("Password not matched.");
                                        return false;
                                    }
                                }
                                else {
                                    alert("Invalid Password.");
                                    return false;
                                }
                            }
                            else {
                                alert("Invalid PinCode.");
                                return false;
                            }
                        }
                        else {
                            alert("Invalid State Name.");
                            return false;
                        }
                    }
                    else {
                        alert("Invalid City Name.");
                        return false;
                    }
                }
                else {
                    alert("Invalid Contact no.");
                    return false;
                }
            }
            else {
                alert("Invalid E-mail.");
                return false;
            }
        }
        else {
            alert("Invalid Last Name.");
            return false;
        }
    }
    else {
        alert("Invalid First Name.");
        return false;
    }

}  