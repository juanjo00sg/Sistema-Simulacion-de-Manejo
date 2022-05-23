var logueado=false;
var registrado=false;
function login(){

let email= document.getElementById("email-login").value;
let password= document.getElementById("pass-login").value;
console.log(email, password);
var request = new Request("https://localhost:44347/api/Values", {
    method: "Post",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      option: "login",
      email: email,
      pass: password,
      ced: null,
      nom: null,
      tiempo: -1,
      edad: -1,
    }),
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })

    .then(function (data) {
      alert(data)
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
    var request = new Request("https://localhost:44347/api/Values", {
        method: "Post",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          option: "registrar",
          email: email,
          pass: password,
          nom:nombre,
          ced: cedula,
          edad: parseInt(edad),           
        }),
      });
    
      fetch(request)
        .then(function (response) {          
            document.location.href = 'inicio.html'
          return response.text();
        })
    
        .then(function (data) {
          alert(data)          
          this.registrado=true;
        })
        .catch(function (err) {
          console.error(err);
        });

}