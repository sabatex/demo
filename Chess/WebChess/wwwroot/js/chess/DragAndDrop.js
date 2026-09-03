import { chessDesk, ChessDesk } from "./ChessDesk.js";
import { ChessCell } from "./ChessCell";


function dropCell(ev) {
    ev.preventDefault();
    let data = ev.dataTransfer.getData("cellCords");
    let Targetcell = globalThis.playerDesk.chessDesk.getCellById(ev.target.id);
    globalThis.playerDesk.chessDesk.moveFigure(ev.target);

}

function allowDropCell(ev) {
    ev.preventDefault();
}

function dragCell(ev) {
    let cell = globalThis.playerDesk.chessDesk.getCellById(ev.target.id);
    ev.dataTransfer.setData("cellCords", { row: cell.row, column: cell.column });
    globalThis.playerDesk.chessDesk.selectFigure(ev.target);
}

for (let i = 0; i < 64; i++) {
    let cell = chessDesk.desk[i];
    cell.cellElement.ondragstart = dragCell;
    cell.cellElement.ondragover = allowDropCell;
    cell.cellElement.ondrop = dropCell;

}