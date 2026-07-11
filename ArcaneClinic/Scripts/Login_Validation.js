function Login_Validation() {
    var userid = UserId.value;
    var pass = Password.value;
    if (userid != null && userid != "" && pass != null && pass != "") {
        return true;
    }
    else {
        spid.innerText = "Please Enter Userid carefully";
        sppass.innerText = "Please Enter Password carefully";
        spid.style.color = "red";
        sppass.style.color = "red";
        return false;
    }
}

