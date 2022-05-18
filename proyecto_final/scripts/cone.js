class Cone{
    constructor(){
        this.r = 30
        this.x = random(950,width)
        this.y = random(50,250)
    }

    move(){
        this.x -= 3
    }


    show(){
        image(coneImg, this.x, this.y, this.r, this.r);
        //fill(255, 50);
        //rect(CORNER);
        //rect(this.x, this.y, this.r, this.r);
    }
}