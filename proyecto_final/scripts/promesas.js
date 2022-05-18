function consultar() {
  if(document.getElementById("cedula").value == ""){
    ced = "ninguno"
  }else{
    ced = document.getElementById("cedula").value;
  }
  var request = new Request("https://localhost:44360/api/Values/"+ced + "/", {
    method: "Get",
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })
    .then(function (data) {
      alert(data)
      json1=JSON.parse(data);
      section=document.getElementById("listar");
       texto = document.createTextNode("Cedula");
       divi=document.createElement("div");
       divi.setAttribute("class", "listar");
       divi.appendChild(texto);
       section.appendChild(divi);
       section=document.getElementById("listar");
       texto = document.createTextNode("Nombre");
       divi=document.createElement("div");
       divi.setAttribute("class", "listar");
       divi.appendChild(texto);
       section.appendChild(divi);
       section=document.getElementById("listar");
       texto = document.createTextNode("Edad");
       divi=document.createElement("div");
       divi.setAttribute("class", "listar");
       divi.appendChild(texto);
       section.appendChild(divi);

       for (var estudiante in json1) {
        section=document.getElementById("listar");
        texto = document.createTextNode(json1[estudiante].cedula);
        divi=document.createElement("div");
        divi.setAttribute("class", "listar2");
        divi.appendChild(texto);
        section.appendChild(divi);
        texto = document.createTextNode(json1[estudiante].nombre);
        divi=document.createElement("div");
        divi.setAttribute("class", "listar2");
        divi.appendChild(texto);
        section.appendChild(divi) 
        texto = document.createTextNode(json1[estudiante].edad);
        divi=document.createElement("div");
        divi.setAttribute("class", "listar2");
        divi.appendChild(texto);
        section.appendChild(divi) 
      }
    })
    .catch(function (err) {
      console.error(err);
    });
}


function ingresar() {
  var cedula = "1002591347";
  var nombre = "Rafael";
  var edad = 17;

  var request = new Request("https://localhost:44360/api/Values", {
    method: "Post",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      ced: cedula,
      nom: nombre,
      edad: parseInt(edad),
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

function eliminar() {
  let cedula = "1123456789";
  var request = new Request("https://localhost:44360/api/Values/" + cedula, {
    method: "Delete",
    headers: {
      "Content-type": "application/json",
    },
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })
    .then(function (data) {
      console.log("data = ", data);
      alert(data);
      document.write(data);
    })
    .catch(function (err) {
      console.error(err);
    });
}

function modificar() {
  var cedula = document.getElementById("cedula2").value;
  var nombre = document.getElementById("nombre").value;
  var edad = document.getElementById("edad").value;

  var request = new Request("https://localhost:44360/api/Values/" + cedula, {
    method: "put",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      ced:cedula,
      nom: nombre,
      edad: parseInt(edad),
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
