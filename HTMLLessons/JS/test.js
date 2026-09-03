// class model

class Wheel {
    constructor(radius=0){
        this.radius=radius; 
    }
    radius = 0;

    calcLength(){
        return this.radius*2*Math.PI;
    }
    get diameter(){
        return radius*2;
    }
    set diameter(value){
        this.radius = this.diameter/2;
    }

    // calculated name method
    ['radius'+this.radius](){
        return this.radius;
    }
}
// inherits demo
class GumaWheel extends Wheel {
    gumaSize=10;
    #privateProperty = "Private";
    calcLength()
    {
        let oldLenght = super.calcLength();
        return (this.radius + this.gumaSize) * 2 *Math.PI;
    }
}

let test = [10,40,20];
test.sort();

class WoodWheel extends Wheel{
    _theProtected = 34;
    spokesCount = 10;
    constructor(radius=0,spokesCount = 10){
        super(radius);
        this.spokesCount = spokesCount;
    }    
}

let woodWheel = new WoodWheel(23,2);
woodWheel._theProtected = 24;

let s = clGlob();

var cl = function (){
    return 0;

}

s = cl();

function clGlob(){
    return 10;

}



function FWheel(radius=1){
    this.radius = radius;
    this.calcLength=()=>this.radius*2*Math.PI;  
    Object.defineProperty(this,"diameter",{
        get(){
            return this.radius*2;
        },
        set(value){
            this.radius = value/2;   
        }
    });
}