export function getEnabledGames(callBack,callBackError) {
    let xhttp = new XMLHttpRequest();
    xhttp.timeout = 9000;
    xhttp.open("GET", "/Chess?handler=gameList", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    xhttp.onload = function () {
        if (xhttp.status === 200) {
            callBack(JSON.parse(xhttp.response));
        }
    };
    xhttp.onerror = (event) => callBackError(event);
    xhttp.send();
}
export function getNewGame(callBack, callBackError) {
    let xhttp = new XMLHttpRequest();
    xhttp.timeout = 9000;
    xhttp.open("GET", "/Chess?handler=newGame", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    xhttp.onload = function () {
        if (xhttp.status === 200) {
            callBack(JSON.parse(xhttp.response));
        }
    };
    xhttp.onerror = (event) => callBackError(event);
    xhttp.send();
}

var ChessAPIGetDesk = function () {
    let xhttp = new XMLHttpRequest();

    xhttp.timeout = 9000;
    xhttp.open("GET", "/Chess?handler=desk", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    xhttp.onload = function () {
        if (xhttp.status === 200) {
            var result = JSON.parse(xhttp.response);
            setChessDesk(new ChessDesk(result));
            chessDesk.refreshDesk();

        }
    };
    xhttp.onreadystatechange = function () {
        // In local files, status is 0 upon success in Mozilla Firefox
        if (xhttp.readyState === XMLHttpRequest.DONE) {
            var status = xhttp.status;
            if (status === 0 || (status >= 200 && status < 400)) {
                // The request has been completed successfully
                //var result = JSON.parse(xhttp.response);

                //result.__prototype__ = ChessDesk;
                //chessDesk = result;
                //chessDesk.refreshDesk();

                //console.log(xhttp.response);
            } else {
                // Oh no! There has been an error with the request!
            }
        }
    };
    xhttp.send();
}
