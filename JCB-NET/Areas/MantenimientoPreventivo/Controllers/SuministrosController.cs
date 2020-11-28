using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCB_NET.Areas.MantenimientoPreventivo.Models;
using JCB_NET.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JCB_NET.Areas.MantenimientoPreventivo.Controllers
{
    [Area("MantenimientoPreventivo")]
    [Authorize]
    public class SuministrosController : Controller
    {
        private readonly ApplicationDbContext db;

        public SuministrosController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public List<SuministroMO> listarSuministro(string nombreSuministro)
        {
            List<SuministroMO> listaSuministro = new List<SuministroMO>();

            if (nombreSuministro == "" || nombreSuministro == null)
            {
                listaSuministro = (from suministro in db.Suministro
                                   join bodega in db.Bodega
                    on suministro.Id_Bodega equals
                    bodega.Id_Bodega
                                   where suministro.Id_Bodega == 1
                                   select new SuministroMO
                                   {
                                       Id_Suministro = suministro.Id_Suministro,
                                       Codigo = suministro.Codigo,
                                       Nombre = suministro.Nombre
                                   }).ToList();
                ViewBag.nombreSuministro = "";
            }
            else
            {
                listaSuministro = (from suministro in db.Suministro
                                   where suministro.Id_Bodega == 1
                                   && suministro.Nombre.Contains(nombreSuministro)
                                   select new SuministroMO
                                   {
                                       Id_Suministro = suministro.Id_Suministro,
                                       Codigo = suministro.Codigo,
                                       Nombre = suministro.Nombre
                                   }).ToList();

            }

            return listaSuministro;
        }

        
        public List<TecnicoMO> listarTecnico()
        {
            List<TecnicoMO> listaTecnico = new List<TecnicoMO>();

           
                listaTecnico = (from tecnico in db.Tecnico
                                  /* join bodega in db.Bodega
                                   on suministro.Id_Bodega equals
                                   bodega.Id_Bodega 
                                   where suministro.Id_Bodega == 1
                                    */
                                   select new TecnicoMO
                                   {
                                       Id_Tecnico = tecnico.Id_Tecnico,
                                       Nombre = tecnico.ApePaterno + ", " + tecnico.Nombre
                                   }).ToList();
                ViewBag.nombreSuministro = "";
            
   

            return listaTecnico;
        }
    }
}