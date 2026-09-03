
let wheel = {
    radius:20,
    get diameter(){return this.radius*2;},
    set diameter(value){this.radius = value /2;}
};
wheel.calcLenght = function(){
    return this.radius *2 *Math.PI;
};
wheel.diameter
let lengthWheel = wheel.calcLenght();
wheel["dubove property"] = 50;
let gumWheel = {gumSize:5};
gumWheel.__proto__=wheel;
gumWheel.radius = 25;

function WheeleFN(radius=10){
    this.radius=radius;
    this.calcLenght = function(){
        return this.radius *2 *Math.PI;
    };
    return radius*2;
}

diameter1 = WheeleFN(5);
wheel1 = new WheeleFN(50);
wheel2 = new WheeleFN(30);

wheel3 = new WheeleFN(25);
wheel3[0] = 25;
let sss = 0 in wheel3;
let str = "";
for (pr in wheel3){
    str = str+pr +",";
}

let arr1 = [12,45,23,49,45,67];
arr1.sort((a,b)=>a-b);
arr1[0] = 12;
str = "";
for (pr in arr1){
    str = str+pr +",";
}
str = str +1;







    



