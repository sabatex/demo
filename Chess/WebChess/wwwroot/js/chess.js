import { ChessDesk, chessDesk, setChessDesk, chessDeskCellClick } from "./chess/ChessDesk.js";
import { ChessConst, GameState } from "./chess/GameState.js";
import { getEnabledGames, getNewGame } from "./chess/ServerApi.js";
function appendLoader() {
    let loader = $(`<div class="bg-white d-flex align-items-center justify-content-center border-left-0 border-right-0 border-top-0 border-bottom rounded-0 w-100 text-center" id ="loader" style="display:none !important;">
       <span class="mr-5">Загрузка...</span>
       <div class="spinner" id="spinner">
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
            <div class="spinner-blade"></div>
        </div>
    </div>`);
    if ($('#loader').length !== 0) {
        return true;
    }
    else {
        let menu = $('#chessMenu');
        loader.appendTo(menu).show("slow");
        return false;
    }
    let menu = $('#chessMenu');
    loader.appendTo(menu).show("slow");


}
function removeLoader() {
    $('#loader').hide("slow", function () {
        $(this).remove();
    });
}
function drawNewGame(mainContainer, newGame,type) {
    if (newGame !== null && newGame !== undefined) {
        if (type === 'list') {
            let content = $(`<div class="alert alert-light shadow d-flex justify-content-around p-3 w-100 font-weight-bold border shadow-sm mt-2 gameList"></div>`);
            $(`<div class="w-25 text-center">${newGame.id}</div>`).appendTo(content);
            $(`<div class="w-100 text-center">${newGame.user1}</div>`).appendTo(content);
            if (newGame.user2 === null) {
                $(`<div class="w-100 text-center">Немає гравця</div>`).appendTo(content);
                return content;
            }
            else {
                $(`<div class="w-100 text-center">${newGame.user2}</div>`).appendTo(content);
                return content;
            }
        }
        else if (type === 'card') {
            let content = $(`<div class="card bg-danger text-white shadow d-flex justify-content-around p-3 text-center w-50 font-weight-bold border mt-2"></div>`);
            let cardBody = $(`<div class="card-body"></div>`).appendTo(content);
            $(`<div class="row"><div class="col-sm-6 col-6"> ID = </div><div class="col-sm-6 col-6">${newGame.id}</div></div>`).appendTo(cardBody);
            $(`<div class="row"><div class="col-sm-6 col-6"> User1 = </div><div class="col-sm-6 col-6">${newGame.user1}</div></div>`).appendTo(cardBody);
            if (newGame.user2 === null) {
                $(`<div class="row"><div class="col-sm-6 col-6"> User2 = </div><div class="col-sm-6 col-6"> NONE </div></div>`).appendTo(cardBody);
                return content;
            }
            else {
                $(`<div class="row"><div class="col-sm-6 col-6"> User2 = </div><div class="col-sm-6 col-6">${newGame.user2}</div></div>`).appendTo(cardBody);
                return content;
            }
        }
        else {
            return null;
        }
    }
    else {
        let alert = $('<div class="alert pt-3 pb-3 pl-5 pr-5 shadow-sm d-inline-flex aling-items-center justify-content-between w-100 alert-info"></div>').appendTo($('<div class="container p-4"></div>').insertBefore(mainContainer));
        $('<h3 style="font-weight:normal!important;">У вас немає створених ігор</h3>').appendTo(alert);
        $('<button class="btn btn-primary font-weight-bold text-uppercase shadow-sm pt-2 pb-2 pl-5 pr-5">Нова гра</button>').appendTo(alert);
        return null;
    }
}
function drawGameList(color, mainContainer, game, newGame, title) {
    if (game !== null && game !== undefined) {
        if (game.length !== 0) {
            mainContainer.css('display', 'none');
            let gameInfo = $('<div class="container-fluid d-flex justify-content-center aling-items-center">').appendTo(mainContainer);
            $(`<h3 class="d-inline-flex text-center pt-2 pb-2 pl-5 pr-5 rounded-pill text-${color} mt-3 mb-3 border border-${color}">${title}</h3>`).appendTo(gameInfo);
            let contentContainer = $('<div class="container-fluid w-100" style="height:70vh;overflow-y:auto;"></div>').appendTo(mainContainer);
            let header = $(`<div class="bg-${color} d-flex justify-content-around p-3 w-100 font-weight-bold text-uppercase"></div >`).appendTo(contentContainer);
            $('<div class="text-white text-center w-25">ID</div><div class="text-white text-center w-100">Player 1</div><div class="text-white text-center w-100">Player 2</div>').appendTo(header);
            let ng = drawNewGame(mainContainer, newGame,'list');
            if (ng !== null) {
                ng.appendTo(contentContainer);
            }
            for (let i = 0; i < game.length; i++) {
                let content = $(`<div class="alert alert-${color} d-flex justify-content-around p-3 w-100 font-weight-bold border shadow-sm mt-2 gameList"></div>`).appendTo(contentContainer);
                $(`<div class="w-25 text-center">${game[i].id}</div>`).appendTo(content);
                $(`<div class="w-100 text-center">${game[i].user1}</div>`).appendTo(content);
                if (game[i].user2 !== null) {
                    $(`<div class="w-100 text-center">${game[i].user2}</div>`).appendTo(content);
                }
                else {
                    $(`<div class="w-100 text-center">Немає гравця</div>`).appendTo(content);
                }
            }
            let count = $('.gameList').toArray().length;
            $(`<h3 class="badge badge-${color} badge-pill d-flex align-items-center justify-content-center font-weight-bold text-white" style="position:relative;right:2%;height:30px!important;width:30px!important;padding:25px;font-size:20px;">${count}</h3>`).appendTo(gameInfo);
            mainContainer.slideDown(1000);
            window.setTimeout(removeLoader, 2000);
        }
        else {
            let ngGame = drawNewGame(mainContainer, newGame, 'card');
            ngGame.appendTo(mainContainer);
            window.setTimeout(removeLoader, 2000);
        }
    }
    else {
        console.log('Game must be not null!!!');
    }
}


function drawChessTableOutside(htmlElement) {
    for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
        $('<DIV>').addClass('gripDeskRow').css('grid-row', '1/1').text(s).appendTo(htmlElement);
        $('<DIV>').addClass('gripDeskRow').css('grid-row', '10/10').text(s).appendTo(htmlElement);
    }
    for (let i = 1; i < 9; i++) {
        $('<DIV>').addClass('gripDeskColumn').css('grid-column', '1/1').text(i).appendTo(htmlElement);
        $('<DIV>').addClass('gripDeskColumn').css('grid-column', '10/10').text(i).appendTo(htmlElement);
    }


    appendDIV(htmlElement, "gripDeskColumn", "1");
    var mainChessTable = appendDIV(htmlElement, "chessCelsTable", "");
    for (let s of ["1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8"]) {
        appendDIV(htmlElement, "gripDeskColumn", s);
    }
    //for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
    //    appendDIV(htmlElement, "gripDeskRow", s);
    //}
    return mainChessTable;
}

function selectGame() {

}

window.chess = new function () {
    this.clickCell = function (event) {
        //let a = 10;
    }

    this.initialDesk = function () {
        this.leftPanel.empty();
        for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
            $('<DIV>').addClass('gripDeskRow').css('grid-row', '1/1').text(s).appendTo(this.leftPanel);
            $('<DIV>').addClass('gripDeskRow').css('grid-row', '10/10').text(s).appendTo(this.leftPanel);
        }
        for (let i = 1; i < 9; i++) {
            $('<DIV>').addClass('gripDeskColumn').css('grid-column', '1/1').text(i).appendTo(this.leftPanel);
            $('<DIV>').addClass('gripDeskColumn').css('grid-column', '10/10').text(i).appendTo(this.leftPanel);
        }
        let chessTable = $('<DIV>').addClass("chessCelsTable").css('grid-area', '2/2/10/10').appendTo(this.leftPanel);
        for (let i = 0; i < 8; i++) {
            for (let j = 0; j < 8; j++) {
                let cellElement = $('<DIV>').addClass("chessCell").attr("id", "cell" + i + j).click(this.clickCell).appendTo(chessTable);
                if ((i + j) % 2) cellElement.addClass("blackCell");
            }
        }
    }
    this.initialSelectGame = function (gamesList) {
        console.log(gamesList);
        $(`#${ChessConst.mainElement}`).hide();
        let mainContainer = $('#container');
        $('.menu-item-1').on('click', function () {
            if (!appendLoader()) {
                mainContainer.empty();
                window.setTimeout(() => {
                    drawGameList('danger', mainContainer, gamesList.myGames, gamesList.myNewGame, 'My Games');
                }, 5000);
            }
        });

        $('.menu-item-2').on('click', function () {
            if (!appendLoader()) {

                mainContainer.empty();
                window.setTimeout(() => {
                    drawGameList('primary', mainContainer, gamesList.myJoinGames, null, 'Joined Games');
                }, 5000);
            }

        });

        $('.menu-item-3').on('click', function () {
            if (!appendLoader()) {
                mainContainer.empty();
                window.setTimeout(() => {
                    drawGameList('warning', mainContainer, gamesList.waitForJoin, null, 'Online Games');
                }, 5000);
            }


        });
    }



    Object.defineProperty(this, "state", {
        get: function () { this._state; },
        set: function (value) {
            switch (value) {
                case GameState.waitForSelectGame: {
                    this._state = value;
                    getEnabledGames(this.initialSelectGame, () => { });
                }
            }
        }
    });


    // initial chess desk
    let mainElement = document.getElementById(ChessConst.mainElement);
    this.leftPanel = $('<DIV>').attr('id', ChessConst.leftPanel)
        .addClass(ChessConst.cssChessTable).appendTo(mainElement);

    this.rigthPanel = $('<DIV>').addClass(ChessConst.rightPanel).appendTo(mainElement);
    this.infoPanel = $('<DIV>').addClass(ChessConst.cssPlayerStatus).appendTo(this.rigthPanel);
    this.playerPanel1 = $('<DIV>').addClass(ChessConst.cssPlayer1).appendTo(this.rigthPanel);
    this.playerPanel2 = $('<DIV>').addClass(ChessConst.cssPlayer1).appendTo(this.rigthPanel);

    this.initialDesk();

    let rg = $('#leftPanel').clone().appendTo('#container');

    //var x = document.createElement("P");                        // Create a <p> element
    //var t = document.createTextNode("This is a paragraph.");    // Create a text node
    //x.appendChild(t);                                           // Append the text to <p>
    //document.body.appendChild(x);
    //let node = document.createN

    //let test = document.createElement('div').innerHTML = document.createTextNode("Привіт Світ");
    //  document.body.appendChild(test);


    let party = $('#Party').get(0).value;
    if (party == '') {
        this.state = GameState.waitForSelectGame;
        return;
    }




}


//// initial chess desk
//var htmlElement = document.getElementById("chessDesk");
//// chessTable 
////var chessTableElement = appendDIV(htmlElement, "chessTable", "");
//var chessTableElement = drawChessTableOutside(appendDIV(htmlElement, "chessTable", ""));
//for (let i = 0; i < 8; i++) {
//    for (let j = 0; j < 8; j++) {
//        let cellElement = appendDIV(chessTableElement, "chessCell", "");
//        if ((i + j) % 2) cellElement.classList.add("blackCell");
//        cellElement.id = "cell" + i + j;
//        cellElement.onclick = chessDeskCellClick;

//    }
//}

//// Player Desk
//var playerDeskElement = appendDIV(htmlElement, "playerDesk", "");
//appendDIV(playerDeskElement, "playerStatus", "Please wait ...");

//appendDIV(playerDeskElement, "userBlackDashBoard userDashBoard", "");
//appendDIV(playerDeskElement, "userWhiteDashBoard userDashBoard", "");

//window.dashBoard = new DashBoard(playerDeskElement);
//window.chessDesk = new ChessDesk();


//let party = $("#Party").get(0);

//if (currentGame == "") {
//    selectGame();
//}
//else {
//    var result = JSON.parse(document.getElementById("InitialDesk").value);
//    setChessDesk(new ChessDesk(result));
//    chessDesk.refreshDesk();

//}


//ajax get desk




