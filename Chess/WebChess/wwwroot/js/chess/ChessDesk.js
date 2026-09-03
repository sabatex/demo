//import { } from "./CSSCellState.js";
//import { FigureColor } from "./FigureColor.js";
//import { ChessCell } from "./ChessCell.js";
//import { Bishop } from "./Bishop.js";
//import { Horse } from "./Horse.js";
//import { King } from "./King.js";
//import { Pawn } from "./Pawn.js";
//import { Queen } from "./Queen.js";
//import { Rook } from "./Rook.js";

//import { appendDIV } from "./chess/Tools.js";
import { Figure, FigureType } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";
import { CSSCellState } from "./CSSCellState.js";
import { CanMoveDestination } from "./CanMoveDestination.js";
import { MoveState } from "./MoveState.js";
import { CellPoint } from "./CellPoint.js";



export function getCellElementByIndex(row, cell) {
    return document.getElementById("cell" + row + cell);
}

export function setChessDesk(value) {
    chessDesk = value;
}


export class ChessDesk {
    constructor(responseDesk) {
        if (responseDesk == undefined) return;
        this.waitForResponse = true;
        this.desk = [];
        this.currentPlayer = responseDesk.currentPlayer;
        for (let f of responseDesk.desk) {
            if (f === null)
                this.desk.push(undefined);
            else {
                let canMoves = [];
                for (let c of f.canMoves) {
                    canMoves.push(new CanMoveDestination(c.row, c.column, c.state));
                }

                this.desk.push(new Figure(f.color, f.figureType, canMoves));
            }
        }
        this.isEnabled = true;
    }
    getCell(row, column) {
        return this.desk[row * 8 + column];
    }

    getDestinationFromCell(htmlElement) {
        let id = htmlElement.id;
        return new CellPoint(Number(id[4]), Number(id[5])); 
    }

    getCellByElement(htmlElement) {
        let dest = this.getDestinationFromCell(htmlElement);
        return this.getCell(dest.row, dest.column);
    }

    refreshDesk() {
        chessDesk.waitForResponse = false;
        for (let i = 0; i < 8; i++) {
            for (let j = 0; j < 8; j++) {
                let cell = this.getCell(i, j);
                let cellElement = getCellElementByIndex(i, j);
                cellElement.classList.remove(CSSCellState.chessCellCanMove);
                if (cell !== undefined) {
                    if (cell.canMoves.length > 0)
                        cellElement.classList.add(CSSCellState.chessCellCanMove);
                    cell.drawFigure(cellElement);
                }

            }
        }



    }

    clearClassInDesk(className) {
        let elements = document.getElementsByClassName(className);
        while (elements.length) {
            elements[0].classList.remove(className);
        }
    }

    clearSelectedCell() {
        this.clearClassInDesk(CSSCellState.cellSelected);
        this.clearClassInDesk(CSSCellState.chessCellDestinationMark);
        this.clearClassInDesk(CSSCellState.figureMustFight);
    }

    setSelectedCell(cellElement) {
        cellElement.classList.add(CSSCellState.cellSelected);
        let figure = this.getCellByElement(cellElement);
        for (let dest of figure.canMoves) {
            let destElement = getCellElementByIndex(dest.row, dest.column);

            if (dest.moveState == MoveState.fight) {
                destElement.classList.add(CSSCellState.canBeat);
            }
            destElement.classList.add(CSSCellState.chessCellDestinationMark);
        }
    }

    clickToSameCell(cellElement) {
        this.clearSelectedCell();
    }


    clickToCanMoveCell(cellElement) {
        this.clearSelectedCell();
        this.setSelectedCell(cellElement);
    }

    clickToAnOtherCell(cellElement) {
        if (!cellElement.classList.contains(CSSCellState.chessCellDestinationMark))
            this.clearSelectedCell();
        else
            this.moveFigure(cellElement);
    }


    // move selected figure to destination cell
    moveFigure(cellElement) {
        let selectedElement = document.getElementsByClassName(CSSCellState.cellSelected)[0];
        let cell = this.getDestinationFromCell(selectedElement);
        let targetCell = this.getDestinationFromCell(cellElement);
        // Ajax
        let xhttp = new XMLHttpRequest();
        let msg = JSON.stringify({ "row": cell.row, "column": cell.column, "destinationRow": targetCell.row, "destinationColumn": targetCell.column });
        let fdPost = new FormData();
        fdPost.append("row", cell.row);
        fdPost.append('column', cell.column);
        fdPost.append('destinationRow', targetCell.row);
        fdPost.append('destinationColumn', targetCell.column);
        xhttp.open("POST", "/Chess?handler=move", true);
        xhttp.timeout = 9000;
        xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        xhttp.onload = function () {
            if (xhttp.status === 200) {
                var userInfo = JSON.parse(xhttp.responseText);
                }
            };
        xhttp.send(fdPost);
        this.clearSelectedCell();
        this.clearClassInDesk(CSSCellState.chessCellCanMove);
        this.waitForResponse = true;

        $.ajax({
            type: "POST",
            url: "/Chess?handler=move",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: msg,
            contentType : "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                //var dvItems = $("#dvPostItems");
                //dvItems.empty();
                //$.each(response, function (i, item) {
                //    var $tr = $('<li>').append(item).appendTo(dvItems);
                //});
                let a = 10;
            },
            failure: function (response) {
                alert(response);
            }
        })

    }

    //selectFigure(cellElement) {
    //    // if exist selected figure
    //    let cell = this.getCellById(cellElement.id);
    //    if (cell == this.selectedItem) {
    //        // click to the same figure
    //        cellElement.classList.remove(window.Defines.cellSelected);
    //        this.clearCanMovePositions();
    //    } else {
    //        // click to anathe figure or first figure
    //        if (this.selectedItem == undefined) {
    //            // first click
    //            cellElement.classList.add(window.Defines.cellSelected);
    //            for (let targetCell of cell.canMoves) {
    //                targetCell.cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            }


    //            //this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
    //            //for (let cell of this.canMovePositions) {
    //            //    cell.cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            //}
    //        } else {

    //        }

    //        cellElement.classList.remove(Defines.cellSelected);
    //        cellElement.classList.add(Defines.cellSelected);
    //    }



    //    cellElement.classList.add(Defines.cellSelected);
    //    this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
    //    for (let cell of this.canMovePositions) {
    //        cell.cell.cellElement.classList
    //    }

    //}
    //getCell(row, column) {
    //    return this.desk[row * 8 + column];
    //}

    //getMovePositions(cell) {
    //    let result = [];
    //    if (cell.figure == undefined) return result;
    //    for (let i = 0; i < 8; i++) {
    //        for (let j = 0; j < 8; j++) {
    //            let r = cell.figure.checkMove(cell.row, cell.column, i, j);
    //            if (r == MoveState.can || r == MoveState.fight) {
    //                result.push(new CanMoveDestination(this.getCell(i, j), r));
    //            }
    //        }
    //    }
    //    return result;
    //}
    //setHoverForCells() {
    //    for (let cell of this.desk) {
    //        cell.canMoves = this.getMovePositions(cell);
    //        if (cell.canMoves.length > 0) {
    //            cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            cell.cellElement.draggable = true;
    //        }
    //        else {
    //            cell.cellElement.classList.remove(window.Defines.chessCellCanMove);
    //            cell.cellElement.draggable = false;
    //        }
    //    }
    //}

}

export function chessDeskCellClick(event) {
    if (chessDesk == undefined) return;
    if (this.classList.contains(CSSCellState.cellSelected)) // DOM
        chessDesk.clickToSameCell(this);
    else {
        if (this.classList.contains(CSSCellState.chessCellCanMove))
            chessDesk.clickToCanMoveCell(this);
        else
            chessDesk.clickToAnOtherCell(this);
    }
}

export var chessDesk = undefined;


