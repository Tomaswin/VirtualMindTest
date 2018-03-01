//Generacion de class y de funciones
class Empleados {

  constructor(name, lastname, salary) {
    this.name = name;
    this.lastname = lastname;
    this.salary = salary;
  }

}

function removecolor(){
  var sel = document.getElementById("colorSelect");
  sel.remove(sel.selectedIndex);
}

function insert_Row(){
  var table = document.getElementById("sampleTable");
  var row = table.insertRow(0);
  var fila = table.insertRow();
  var cell1 = row.insertCell(0);
  var cell2 = row.insertCell(1);
}

function AumentoSal() {
  var Name = prompt('Ingrese nombre de empleado:','');
  var Last = prompt('Ingrese apellido de empleado:','');
  var Salary = prompt('Ingrese salario de empleado:','');


  let Emple = new Empleados(Name, Last, Salary);

  Salario = Salary * 1000;
  alert("El salario por 1000 es: " + Salario);
}

function EmployeesDetails() {
  var Name = prompt('Ingrese nombre de empleado:','');
  var Last = prompt('Ingrese apellido de empleado:','');
  var Salary = prompt('Ingrese salario de empleado:','');


  let Emple = new Empleados(Name, Last, Salary);

  alert("Los detalles del empleado son:" + Name + " " + Last + " " + Salary);
}

function MultiplyBy() {
alert(2*3*4); // output : 24
alert(4*3*4); // output : 48
}

function FunctionLongestCountry()
{
  var ciudades = new Array("Australia", "Germany", "United States of America");
  var maslargo = 0;
  var pais = "";
  for(var i = 0; i <= ciudades.length; i++)
  {
    if(i == 0)
    {
      maslargo = ciudades[i].length;
      pais = ciudades[i];
    }else{
      if(ciudades[i] && maslargo < ciudades[i].length)
      {
        maslargo = ciudades[i].length;
        pais = ciudades[i];
      }
    }
  }
  alert("El pais con mas caracteres es: " + pais + " con " + maslargo);
  //alert(Pais[0].length); // output : United States
}
