let canvas = document.getElementById('pong');


function showPong(x, y) {
    let canvas = document.getElementById('pong');
    let ctx = canvas.getContext("2d");
    ctx.beginPath();
    ctx.strokeStyle = '#000000';
    ctx.fillStyle = '#ffffff';
    ctx.arc(x, y, 15, 0, 2 * Math.PI, true);
    ctx.moveTo(x - 4, y - 5);
    ctx.arc(x - 7, y - 5, 3, 0, 2 * Math.PI, true);
    ctx.moveTo(x+10,y-5)
    ctx.arc(x + 7, y - 5, 3, 0, 2 * Math.PI, true);
    ctx.moveTo(x + 10, y);
    ctx.arc(x, y, 10, 0, Math.PI, false);
    ctx.moveTo(x, y - 2);
    ctx.lineTo(x + 1, y + 2);
    ctx.lineTo(x - 1, y + 2);
    ctx.lineTo(x, y - 2);
    ctx.moveTo(x, y - 30);
    ctx.lineTo(x + 30, y + 15);
    ctx.lineTo(x - 30, y + 15);
    ctx.lineTo(x, y - 30);
    ctx.moveTo(x, y+30);
    ctx.lineTo(x - 30, y - 15);
    ctx.lineTo(x + 30, y - 15);
    ctx.lineTo(x, y + 30);
    ctx.stroke();
}
function hidePong(x, y) {
    let canvas = document.getElementById('pong');
    let ctx = canvas.getContext("2d");
    ctx.beginPath();
    ctx.fillStyle = '#ffffff';
    ctx.strokeStyle = '#ffffff';
    ctx.arc(x, y, 35, 0, 2 * Math.PI);
    ctx.fill();
}



//let ctx = canvas.getContext("2d");
//ctx.beginPath();
//ctx.arc(75, 75, 50, 0, Math.PI * 2, true);
//ctx.moveTo(110, 75);
//ctx.arc(75, 75, 35, 0, Math.PI, false);
//ctx.moveTo(65, 65);
//ctx.arc(60, 65, 5, 0, Math.PI * 2, true);
//ctx.moveTo(95, 65);
//ctx.arc(90, 65, 5, 0, Math.PI * 2, true);
//ctx.stroke();



//ctx.arc(15, 15, 15, 0, 2 * Math.PI);
//ctx.stroke();
let pongX = 15;
let pongY = 50;

let endPointX = 500;
let endPointY = 450;

let deltaX = endPointX - pongX;
let deltaY = endPointY - pongY;

let maxEndPoint = 0;
let pointValue = 0;
if (Math.abs(deltaX) >= Math.abs(deltaY)) {
    maxEndPoint = endPointX;
    deltaY = deltaY / deltaX;
    deltaX = 1;
    pointValue = pongX;
} else {
    maxEndPoint = endPointY;
    deltaX = deltaX / deltaY;
    deltaY = 1;
    pointValue = pongY;
}


window.setInterval(movePong, 50);

function movePong() {
    hidePong(pongX, pongY);
    pongX += deltaX;
    pongY += deltaY;
    pointValue++;
    showPong(pongX, pongY);


    //let canvas = document.getElementById('pong');
    //if (pointValue < maxEndPoint) {
    //    pongX += deltaX;
    //    pongY += deltaY;
    //    pointValue ++;
    //    canvas.style.marginTop = (15 + pongY) + 'px';
    //    canvas.style.marginLeft = (15 + pongX) + 'px'
    //}

}



