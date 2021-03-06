﻿/// <reference path="sweetalert.js" />
function mostrarModal(titulo = "Desea guardar los cambios?",
	texto = "Deseas registrar los cambios en la base de datos") {
	return Swal.fire({
		title: titulo,
		text: texto,
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: '#d33',
		confirmButtonText: 'Si!'
	})
}

function Imprimir() {
	//<table><thead></thead><tbody></tbody></table>
	var tcheck = document.getElementById("tcheck").outerHTML;
	var table = "<h1>Reporte a Imprimir</h1>"
	table += document.getElementById("table").outerHTML;
	table = table.replace(tcheck, "");
	var pagina = window.document.body;
	var ventana = window.open();
	ventana.document.write(table);
	ventana.print();
	ventana.close();
	window.document.body = pagina;
}

window.onload = function () {
	$(document).ready(function () {
		$('#table').DataTable();
	});
}


function ExportarExcel() {
	document.getElementById("tipoReporte").value = "Excel";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();

}



function ExportarWord() {
	document.getElementById("tipoReporte").value = "Word";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();
}

function ExportarPDF(nombreController) {
	/*
	document.getElementById("tipoReporte").value = "PDF";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();
	*/
	var frm = new FormData();
	var checks = document.getElementsByName("nombrePropiedades");
	var nchecks = checks.length;
	for (var i = 0; i < nchecks; i++) {
		if (checks[i].checked == true) {
			frm.append("nombrePropiedades[]", checks[i].value);
		}
	}

	$.ajax({
		type: "POST",
		url: nombreController + "/exportarDatosPDF",
		data: frm,
		contentType: false,
		processData: false,
		success: function (data) {
			//base64 (Descargas ese base 64)
			var a = document.createElement("a");
			a.href = data;
			a.download = "reporte.pdf";
			a.click();
		}
	})


}


function pintar(url="", campos, propiedadId, nombreController,
	popup = false, opciones = true, id = "tbDatos", idTabla = "table", propiedadMostrar = "", verDetalle = true) {
	var contenido = "";
	if (id == null || id == undefined || id == "") {
		var tbody = document.getElementById("tbDatos");
	} else {
		var tbody = document.getElementById(id);
	}

	var nombreCampo;
	var objetoActual;
	$.get(url, function (data) {
		for (var i = 0; i < data.length; i++) {
			contenido += "<tr>";
			for (var j = 0; j < campos.length; j++) {
				nombreCampo = campos[j];
				objetoActual = data[i];
				contenido += "<td>" + objetoActual[nombreCampo] + "</td>"
			}
			//contenido += "<td>" + data[i].iidespecialidad + "</td>";
			// data[i][iidespecialidad]
			//contenido += "<td>" + data[i].nombre + "</td>";
			//contenido += "<td>" + data[i].descripcion + "</td>";
			if (opciones == true) {

				contenido += `
					<td>`
				if (verDetalle == true) {
					contenido += `
	                    <a
						   href="/${nombreController}/Detalle/${objetoActual[propiedadId]}"
                          >
	                    <i class="fa fa-eye btn btn-outline-info" aria-hidden="true">
						   
								</i>
						</a>
						`;
				}
				//
				contenido += `
						<i class="fa fa-trash btn btn-outline-danger" aria-hidden="true"
						   onclick="Eliminar(${objetoActual[propiedadId]})">
						</i>`;
				if (popup == false) {
					contenido += `
						<a  
						   href="${nombreController}/Editar/${objetoActual[propiedadId]}"
						  >
								<i class="fa fa-edit btn btn-outline-primary"
										aria-hidden="true"
                                  ></i>	
						</a>
                 `
				} else {
					contenido += `
	                    <i class="fa fa-edit btn btn-outline-primary" aria-hidden="true"
						   data-toggle="modal"  data-target="#exampleModal"
						   onclick="Abrir(${objetoActual[propiedadId]})">
						</i>
                        `;
				}
				contenido += `</td>`;
				// khe?
			} else {
				contenido += `
					<td>
						<i class="fa fa-check btn btn-success" aria-hidden="true"
						   onclick="AsignarNombre(${objetoActual[propiedadId]},
                              '${objetoActual[propiedadMostrar]}')">
						</i>
					</td>`;
			}
			contenido += "</tr>";
		}

		tbody.innerHTML = contenido;
		if (idTabla == null || idTabla == undefined || idTabla == "") {
			$('#table').DataTable();
		} else {
			$('#' + idTabla).DataTable();
		}

	})
}

function pintarMultiplePopup(divTabla, url = "" , cabeceras = ["Id", "Nombre Completo"],
	campos, propiedadId, propiedadMostrar = "") {
	
	var contenido = "";
	var id = [];   

	$.get(url, function (data) {
		//Esto
		contenido += "<table id='tablaPopup' class = 'table' >";
		contenido += "<thead class='thead-dark'>";
		contenido += "<tr>";
		for (var i = 0; i < cabeceras.length; i++) {
			contenido += "<th>" + cabeceras[i] + "</th>"
		}
		contenido += "<th>Seleccionar</th>";
		contenido += "</tr>";
		contenido += "</thead>";
		contenido += "<tbody>";
		var objetoActual;
		for (var i = 0; i < data.length; i++) {
			contenido += "<tr>";
			for (var j = 0; j < campos.length; j++) {
				nombreCampo = campos[j];
				objetoActual = data[i];
				contenido += "<td>" + objetoActual[nombreCampo] + "</td>"
			}
			suma = data.length;
			if (idcbs.length <= 0 || i != 0) { // no contiene datos o no es el primero
				idcbs.push(objetoActual[propiedadId]);
			} else
			{
				idcbs = [];
				idcbs.push(objetoActual[propiedadId]);
			}
			contenido += `
					<td>
				       	<input type="checkbox"  name="nombrerecursos"
						   value="${objetoActual[propiedadMostrar]}" id="${'cb' + objetoActual[propiedadId]}" />
					</td>`;

			contenido += "</tr>";
		}
		contenido += "</tbody>";
		contenido += "</table>";
		document.getElementById(divTabla).innerHTML = contenido;
		$('#tablaPopup').DataTable();
	});


}


function pintarGrillaModal(divTabla = "", data = [], cabeceras = ["Id", "Nombre Completo"],
	campos, propiedadId, tablaId = "") {

	var contenido = "";
	var id = [];


	//Esto
	contenido += `<table id='${tablaId}' class = "table" >`;
	contenido += '<thead class="thead-dark">';
	contenido += "<tr>";
	for (var i = 0; i < cabeceras.length; i++) {
		contenido += "<th>" + cabeceras[i] + "</th>"
	}
	contenido += "<th>Acción</th>";
	contenido += "</tr>";
	contenido += "</thead>";
	contenido += "<tbody>";
	var objetoActual;
	for (var i = 0; i < data.length; i++) {
		contenido += "<tr>";
		if (tablaId == "tablaSuministros") {
		for (var j = 0; j < campos.length; j++) {
			nombreCampo = campos[j];
			objetoActual = data[i];
			contenido += "<td class='tdSuministros'>" + objetoActual[j] + "</td>"
		}
		}
		if (tablaId == "tablaTecnicos") {
			for (var j = 0; j < campos.length; j++) {
				nombreCampo = campos[j];
				objetoActual = data[i];
				contenido += "<td class='tdTecnicos'>" + objetoActual[j] + "</td>"
			}
		}

			contenido += `
                        <td>
                            <i class="fa fa-remove btn btn-outline-danger" aria-hidden="true"
                               onclick="Eliminar(${objetoActual[propiedadId]})">
                            </i>
                        </td>`;
		


		contenido += "</tr>";
	}
	contenido += "</tbody>";
	contenido += "</table>";
	document.getElementById(divTabla).innerHTML = contenido;
	$('#' + tablaId).DataTable();

	// document.getElementById("tablaRecursos_length").style.display = 'none';



}


function correcto(title = "Se elimino correctamente") {

	Swal.fire({
		position: 'top-end',
		icon: 'success',
		title: title,
		showConfirmButton: false,
		timer: 1500
	})


}

function error(title = "Ocurrio un error") {

	Swal.fire({
		icon: 'error',
		title: 'Oops...',
		text: title

	})
}


function LimpiarDatos() {
	var controles = document.getElementsByClassName("form-control");
	var ncontroles = controles.length;
	for (var i = 0; i < ncontroles; i++) {
		controles[i].value = "";
	}
}

function obj(id, valor) {
	document.getElementById(id).value = valor;
}

function enviar(frm, recursos = false) {

	if (recursos == false) {

		var controles = document.getElementsByClassName("enviar");
		var ncontroles = controles.length;
		for (var i = 0; i < ncontroles; i++) {
			frm.append(controles[i].name, controles[i].value);
		}
	}
	else {
		var controles = document.getElementsByClassName("enviar");
		var tdsSuministros = document.getElementsByClassName("tdSuministros");
		var tdsTecnicos = document.getElementsByClassName("tdTecnicos");
		
		var ncontroles = controles.length;
		var nSuministros = tdsSuministros.length;
		var nTecnicos = tdsTecnicos.length;
		for (var i = 0; i < ncontroles; i++) {
			frm.append(controles[i].name, controles[i].value);
		}
		for (var i = 0; i < nSuministros; i++) {
			if (tdsSuministros[i].classList.contains("sorting_1")) {
				frm.append("suministros", tdsSuministros[i].textContent);
			}
		}
		for (var i = 0; i < nTecnicos; i++) {
			if (tdsTecnicos[i].classList.contains("sorting_1")) {
				frm.append("tecnicos", tdsTecnicos[i].textContent);
			}
		}
	
    }
}