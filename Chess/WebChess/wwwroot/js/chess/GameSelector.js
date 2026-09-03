class selectGamePanel{
    constructor(ownerElement) {
        ownerElement.innerHTML = "Зачекайте ...";
        let currentGame = getCookie('party');
        if (currentGame == "")
            selectGame(ownerElement);
        else
            loadCurrentGame(ownerElement);





    }

    loadCurrentGame() {

    }


    selectGame() {
        let xhttp = new XMLHttpRequest();

        xhttp.timeout = 9000;
        xhttp.open("GET", "/Chess?handler=gamesList", true);
        xhttp.setRequestHeader('Content-Type', 'application/json');
        xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        xhttp.onload = function () {
            if (xhttp.status === 200) {
                var result = JSON.parse(xhttp.response);
                //setChessDesk(new ChessDesk(result));
                //chessDesk.refreshDesk();

            }
        };
        xhttp.send();

    }





    }

}



