var logueado=false;
var registrado=false;
function login(){

let email= document.getElementById("email-login").value;
let password= document.getElementById("pass-login").value;
console.log(email, password);
var request = new Request("https://localhost:44360/api/Values", {
    method: "Post",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      email: email,
      pass: password,
     
    }),
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })

    .then(function (data) {
      this.logueado=true;
    })
    .catch(function (err) {
      console.error(err);
    });
}

function registro(){
    let nombre= document.getElementById("nombre").value;
    let email= document.getElementById("email").value;
    let password= document.getElementById("pass").value;
    let cedula= document.getElementById("cedula").value;
    let edad= document.getElementById("edad").value;
    console.log(email, password);
    var request = new Request("https://localhost:44360/api/Values", {
        method: "Post",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email,
          pass: password,
          nom:nombre,
          ced: cedula,
          edad: parseInt(edad)
        }),
      });
    
      fetch(request)
        .then(function (response) {
            document.location.href = 'inicio.html'
          return response.text();
        })
    
        .then(function (data) {
          this.registrado=true;
        })
        .catch(function (err) {
          console.error(err);
        });

}