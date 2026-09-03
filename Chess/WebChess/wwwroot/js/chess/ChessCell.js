import { MoveState } from "./MoveState.js";

export class ChessCell {
    constructor(row, column, figure, parrent, chessDeskCellClick) {
        this._canBeat = false;
        this.parrent = parent;
        this.row = row;
        this.column = column;
        //this.figure = figure;
        let div = document.createElement("div");
        div.classList.add("chessCell");
        if ((row + column) % 2) div.classList.add("blackCell");
        div.id = this.getID();
        //


        div.onclick = chessDeskCellClick;
        parrent.appendChild(div);
        this.figure = figure;
        this.canMoves = [];
    }
    // chess figure
    get figure() { return this._figure }
    set figure(value) {
        let cellElement = this.cellElement;
        cellElement.innerHTML = "";
        this._figure = value;
        if (value != undefined)
            this._figure.showFigure(cellElement);
    }

    get canBeat() { return this._canBeat }
    set canBeat(value) {
        this._canBeat = value;
        let draw = document.getElementById(this.figure.figureId);
        if (value)
            draw.classList.add(MoveState.figureMustFight);
        else
            draw.classList.remove(MoveState.figureMustFight);

    }

    getID() {
        return "cell" + this.row + this.column;
    }

    getCellElement() {
        return document.getElementById(this.getID());
    }

    // HTML tag elrment
    get cellElement() {
        return document.getElementById(this.getID());
    }


    setFigure(figure) {
        this.figure = figure;
        let cellElement = this.getCellElement();
        if (figure == undefined) {
            cellElement.innerHTML = "";
        } else {
            figure.showFigure(cellElement);
        }
    }


}
