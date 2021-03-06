﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using JCB_NET.Areas.MantenimientoPreventivo.Models;
using JCB_NET.Data;
using JCB_NET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace JCB_NET.Areas.MantenimientoPreventivo.Controllers
{
    [Area("MantenimientoPreventivo")]
    [Authorize]
    public class MantenimientoPreventivoController : Controller
    {
        private readonly ApplicationDbContext db;
        public static List<PlanMO> lista;
        public static List<TareaMO> _listaTareas;
        public static int _idPlan;



        public MantenimientoPreventivoController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult MantenimientoPreventivo()
        {
            llenarEstado();
            return View();
        }

        public void llenarEstado()
        {
            //List<SelectLisItem>
            List<SelectListItem> listaEstado = new List<SelectListItem>();

            listaEstado = (from estado in db.EstadoPlan
                           select new SelectListItem
                           {
                               Text = estado.NombreEstado,
                               Value = estado.Id_EstadoPlan.ToString()
                           }).ToList();
            listaEstado.Insert(0, new SelectListItem
            {
                Text = "--Seleccione--",
                Value = ""
            });

            ViewBag.listaEstado = listaEstado;
        }

        public void llenarPeriodicidad()
        {
            //List<SelectLisItem>
            List<SelectListItem> listarPeriodicidad = new List<SelectListItem>();

            listarPeriodicidad = (from periodicidad in db.Periodicidad
                                  select new SelectListItem
                                  {
                                      Text = periodicidad.Valor,
                                      Value = periodicidad.Id_Periodicidad.ToString()
                                  }).ToList();
            listarPeriodicidad.Insert(0, new SelectListItem
            {
                Text = "--Seleccione--",
                Value = ""
            });

            ViewBag.listaPeriodicidad = listarPeriodicidad;
        }

        public void llenarMaquina()
        {
            //List<SelectLisItem>
            List<SelectListItem> listaMaquina = new List<SelectListItem>();

            listaMaquina = (from maquina in db.Maquina
                            select new SelectListItem
                            {
                                Text = maquina.Codigo,
                                Value = maquina.Id_Maquina.ToString()
                            }).ToList();
            listaMaquina.Insert(0, new SelectListItem
            {
                Text = "--Seleccione--",
                Value = ""
            });

            ViewBag.listaMaquina = listaMaquina;
        }
        //[Route("MantenimientoPreventivo/listarPlan")]
        public List<PlanMO> listarPlan()
        {
            List<PlanMO> listPlan = new List<PlanMO>();

            //if (nombreCompleto == null ||
            //    nombreCompleto == "")
            //{
            listPlan = (from plan in db.PlanMantenimientoPreventivo
                        join Estado in db.EstadoPlan
                        on plan.Id_EstadoPlan equals
                        Estado.Id_EstadoPlan
                        select new PlanMO
                        {
                            Id_PlanMantenimientoPreventivo = plan.Id_PlanMantenimientoPreventivo,
                            NombrePlan = plan.NombrePlan,
                            nombreEstado = Estado.NombreEstado,
                            FechaCreacion = plan.FechaCreacion,
                        }).ToList();
            //}

            lista = listPlan;
            return listPlan;
        }


        public string guardarDatos(PlanMO oPlanMO)
        { //TODA RESPUESTA DIFERENTE DE OK ES INVALIDO
            string rpta = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    //if (nveces >= 1) oPersonaCLS.mensajeError = "La persona ya existe";
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    rpta += "<ul class='list-group'>";
                    foreach (var item in query)
                    {
                        rpta += "<li class='list-group-item list-group-item-danger'>";
                        rpta += item;
                        rpta += "</li>";
                    }

                    rpta += "</ul>";
                }
                else
                {
                    //if (oPlanMO.iidDoctor == null || oPlanMO.iidDoctor == 0)
                    //{
                    PlanMantenimientoPreventivo oPlan = new PlanMantenimientoPreventivo();
                    oPlan.NombrePlan = oPlanMO.NombrePlan;
                    oPlan.Id_EstadoPlan = (int)oPlanMO.Id_EstadoPlan;
                    oPlan.FechaCreacion = DateTime.Now;
                    oPlan.EnEjecucion = oPlanMO.Id_EstadoPlan == 2 ? true : false;
                    oPlan.isCorrectivo = false; // por ahora
                    oPlan.FechaFin = DateTime.Now.AddYears(1); // por ahora

                    db.PlanMantenimientoPreventivo.Add(oPlan);
                    db.SaveChanges();
                    rpta = "OK";
                    //}
                    //else
                    //{
                    //    Doctor oDoctor = db.Doctor.Where(p => p.Iiddoctor
                    //     == oPlanMO.iidDoctor).First();
                    //    oDoctor.Iidespecialidad = oPlanMO.iidEspecialidad;
                    //    oDoctor.Iidpersona = oPlanMO.iidPersona;
                    //    oDoctor.Iidsede = oPlanMO.iidSede;
                    //    oDoctor.Sueldo = oPlanMO.sueldo;
                    //    oDoctor.Fechacontrato = oPlanMO.fechaContrato;
                    //    db.SaveChanges();
                    //    transaccion.Complete();
                    //    rpta = "OK";
                    //}
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        //-------------------------------------------------------------------------
        //---------------------TAREAS DE UN PLAN DE MANTENIMIENTO --------------------
        //-----------------------------------------------------------------------
        public IActionResult Detalle(int id)
        {
            _idPlan = id;
            llenarMaquina();
            llenarPeriodicidad();
            return View();
        }


        // [Route("listarTarea")]
        public List<TareaMO> listarTarea()
        {
            List<TareaMO> listaTareas = new List<TareaMO>();

            //if (nombreCompleto == null ||
            //    nombreCompleto == "")
            //{
            listaTareas = (from tarea in db.Tarea
                           join plan in db.PlanMantenimientoPreventivo
                           on tarea.Id_PlanMantenimientoPreventivo equals
                           plan.Id_PlanMantenimientoPreventivo
                           join maquina in db.Maquina
                        on tarea.Id_Maquina equals maquina.Id_Maquina
                           join periodicidad in db.Periodicidad
                        on tarea.Id_Periodicidad equals periodicidad.Id_Periodicidad
                           where tarea.Id_PlanMantenimientoPreventivo == _idPlan
                           select new TareaMO
                           {
                               Id_Tarea = tarea.Id_Tarea,
                               Nombre = tarea.Nombre,
                               CodigoMaquina = maquina.Codigo,
                               Periodicidad = periodicidad.Valor,
                               Prioridad = tarea.Prioridad,
                               FechaInicio = tarea.FechaInicio,

                           }).ToList();
            //}

            _listaTareas = listaTareas;
            return listaTareas;
        }


        public string guardarTarea(TareaMO oTareaMO)
        {
            string rpta = "";
            try
            {
                using (var transaction = new TransactionScope())
                {
                    if (!ModelState.IsValid)
                    {
                        //if (nveces >= 1) oPersonaCLS.mensajeError = "La persona ya existe";
                        var query = (from state in ModelState.Values
                                     from error in state.Errors
                                     select error.ErrorMessage).ToList();
                        rpta += "<ul class='list-group'>";
                        foreach (var item in query)
                        {
                            rpta += "<li class='list-group-item list-group-item-danger'>";
                            rpta += item;
                            rpta += "</li>";
                        }

                        rpta += "</ul>";
                    }
                    else
                    {
                        Tarea oTarea = new Tarea();
                        oTarea.Id_PlanMantenimientoPreventivo = _idPlan; 
                        oTarea.Nombre = oTareaMO.Nombre;
                        oTarea.Id_Maquina = (int)oTareaMO.Id_Maquina;
                        oTarea.Id_Periodicidad = (int)oTareaMO.Id_Periodicidad;
                        oTarea.Prioridad = oTareaMO.Prioridad;
                        oTarea.DuracionEstimada = oTareaMO.DuracionEstimada; 
                        oTarea.TiempoPara = oTareaMO.TiempoPara; 
                        oTarea.FechaInicio = oTareaMO.FechaInicio;
                        oTarea.FechaFin = oTareaMO.FechaInicio.AddYears(1);
                        oTarea.Clasificacion = oTareaMO.Clasificacion;
                        oTarea.Descripcion = oTareaMO.Descripcion; 
                        db.Tarea.Add(oTarea);
                        db.SaveChanges();

                        for (int i = 0; i < oTareaMO.Suministros.Count; i++)
                        {
                            SuministroxTarea sxt = new SuministroxTarea();
                            sxt.Id_Tarea = oTarea.Id_Tarea;
                            sxt.Id_Suministro = oTareaMO.Suministros[i];
                            db.SuministroxTarea.Add(sxt);
                        }

                        for (int i = 0; i < oTareaMO.Tecnicos.Count; i++)
                        {
                            TecnicoxTarea txt = new TecnicoxTarea();
                            txt.Id_Tarea = oTarea.Id_Tarea;
                            txt.Id_Tecnico = oTareaMO.Tecnicos[i];
                            db.TecnicoxTarea.Add(txt);
                        }
                        db.SaveChanges();
                        transaction.Complete();
                        rpta = "OK";
        
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}