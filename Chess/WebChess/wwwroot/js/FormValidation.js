function validateForm() {
    document.getElementById("surNameValid").innerHTML = "";
    let surnameName = document.forms["registerPlayerForm"]["surName"];
    let errorMsg = "";
    let patt = new RegExp("\\D.*","g");

    if (!patt.test(surnameName.value)) {
        document.getElementById("surNameValid").innerHTML = "Поле необхідно заповнити !!!";
        return false;
    }
}