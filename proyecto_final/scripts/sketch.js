var STREET_PATH = "images/street-resize.jpg";
var CAR_PATH = "images/car.png";
var CONE_PATH = "images/traffic-cone.png";
//Variables donde se almacenan las imagenes
let bImg;
let carImg;
let coneImg;
//valor para saber que tecla se presiona
let keyValue;
//objetos principales
let car; //objeto del jugador
let cones = []; //arreglo donde van a ir los conos
//fuente
let font;
//variables de las fechas
let counter = 0
let intervalID


//Carga las imagenes y la fuente de primeros
function preload() {
  bImg = loadImage(STREET_PATH);
  carImg = loadImage(CAR_PATH);
  coneImg = loadImage(CONE_PATH);
  font = loadFont("assets/SourceSansPro-Regular.otf");
}

function keyTyped() {
  if (key === "a") {
    //retroceder
    keyValue = 1;
  } else if (key === "d") {
    //moverse hacia adelante
    keyValue = 2;
  } else if (key === "w") {
    //moverse hacia arriba
    keyValue = 3;
  } else if (key === "s") {
    //moverse hacia abajo
    keyValue = 4;
  }
}

function setup() {
  consultar()
  var button = document.getElementById('jugar')
  button.addEventListener('click',() => {
    console.log('hola')
    function timeIt(){
      counter ++;
      timer.html(counter);
    }
    
    intervalID = setInterval(timeIt, 1000);
    loop()
  })
  var cnv = createCanvas(1000, 400);
  cnv.parent('sketch-holder');

  
  car = new Car();
  
  var timer = select('#timer');
  timer.html('0'); //insert text
  

  noLoop()
}

function draw() {
  if (random(1) < 0.02) {
    cones.push(new Cone());
  }

  background(bImg);
  cones.forEach((cone) => {
    cone.move();
    cone.show();
    if (car.hits(cone)) {
      let sign = "Game Over";
      fill(0);
      text(sign, width / 2, height / 2);
      noLoop();
     clearInterval(intervalID)
     let nombre = document.getElementById('nombre').value
     let cedula = document.getElementById('cedula').value
     ingresar(cedula,nombre,counter)
    }
  });
  car.move(keyValue);
  car.show();
  console.log(document.getElementById('nombre').value)
  console.log(document.getElementById('cedula').value)
}


function consultar() {
    var request = new Request("https://localhost:44347/api/Values", {
    method: "Get",
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })
    .then(function (data) {
      console.log(data)
      json1=JSON.parse(data);
      let tbody = document.getElementById('tbody')

      for(var user in json1){
        let tr = document.createElement("tr")

        let tdn = document.createElement("td")
        let tdc = document.createElement("td")
        let tts = document.createElement("td")

        let n = document.createTextNode(json1[user].cedula)
        let c = document.createTextNode(json1[user].nombre)
        let ts = document.createTextNode(json1[user].tiempo_simulacion)

        tdn.appendChild(n)
        tdc.appendChild(c)
        tts.appendChild(ts)

        tr.appendChild(tdn)
        tr.appendChild(tdc)
        tr.appendChild(tts)
        tbody.appendChild(tr)
      }
    })
    .catch(function (err) {
      console.error(err);
    });
}


function ingresar(cedula,nombre,tiempo) {
  
  var request = new Request("https://localhost:44347/api/Values", {
    method: "Post",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      ced: cedula,
      nom: nombre,
      tiempo: tiempo,
    }),
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })

    .then(function (data) {
      alert(data);
    })
    .catch(function (err) {
      console.error(err);
    });
}