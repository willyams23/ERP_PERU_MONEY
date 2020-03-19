using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebERP.PeruMoney.Models;
using Dapper;

namespace WebERP.PeruMoney.Controllers
{
    public class AgenciaController : Controller
    {
        [HttpGet]
        public ActionResult Inicio()
        {
            return View(DapperORM.ReturnList<AgenciaModel>("SP_AGENCIA_LISTAR_ALL", null));
        }

        [HttpGet]
        public ActionResult AgregarEdit(int id = 0)
        {
            AgenciaModel agencia = new AgenciaModel();

            if (id == 0)
            {
                //Por Default => Asignar Lima/Lima
                agencia.IdDepartamento = "15";
                agencia.IdProvincia = "1501";

                //Carga Departamento
                agencia.DepartamentoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DEPARTAMENTOS", null).ToList();
                agencia.DepartamentoList.Insert(0, new UbigeoModel() { IdDepartamento = "0", Departamento = "--SELECCIONE--" });

                //Carga Provincia
                DynamicParameters param = new DynamicParameters();
                param.Add("@IdDepartamento", agencia.IdDepartamento);
                agencia.ProvinciaList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_PROVINCIAS", param).ToList();
                agencia.ProvinciaList.Insert(0, new UbigeoModel() { IdProvincia = "0", Provincia = "--SELECCIONE--" });

                //Carga Ubigeo
                param.Add("@IdProvincia", agencia.IdProvincia);
                agencia.DistritoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DISTRITO", param).ToList();
                agencia.DistritoList.Insert(0, new UbigeoModel() { IdUbigeo = 0, Distrito = "--SELECCIONE--" });

                ViewBag.Title = "Agregar Agencias";
                ViewBag.SubTitle = "Ingresar Información";
            }
            else
            {
                DynamicParameters paramedit = new DynamicParameters();
                paramedit.Add("@IdAgencia", id);
                agencia = DapperORM.ReturnList<AgenciaModel>("SP_AGENCIA_LISTAR_ID", paramedit).FirstOrDefault<AgenciaModel>();

                //Carga Departamento
                agencia.DepartamentoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DEPARTAMENTOS", null).ToList();
                agencia.DepartamentoList.Insert(0, new UbigeoModel() { IdDepartamento = "0", Departamento = "--SELECCIONE--" });

                //Carga Provincia
                DynamicParameters param2 = new DynamicParameters();
                param2.Add("@IdDepartamento", agencia.IdDepartamento);
                agencia.ProvinciaList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_PROVINCIAS", param2).ToList();
                agencia.ProvinciaList.Insert(0, new UbigeoModel() { IdProvincia = "0", Provincia = "--SELECCIONE--" });

                //Carga Ubigeo
                param2.Add("@IdProvincia", agencia.IdProvincia);
                agencia.DistritoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DISTRITO", param2).ToList();
                agencia.DistritoList.Insert(0, new UbigeoModel() { IdUbigeo = 0, Distrito = "--SELECCIONE--" });

                ViewBag.Title = "Modificar Agencias";
                ViewBag.SubTitle = "Actualizar Información";
            }
            return View(agencia);
        }

        [HttpPost]
        public ActionResult AgregarEdit(AgenciaModel agenciaModel)
        {
            try
            {
                if (agenciaModel.IdAgencia == 0)
                {
                    ViewBag.Title = "Agregar Agencias";
                    ViewBag.SubTitle = "Ingresar Información";
                }
                else
                {
                    ViewBag.Title = "Modificar Agencias";
                    ViewBag.SubTitle = "Actualizar Información";
                }

                if ((!string.IsNullOrEmpty(agenciaModel.Agencia)) && agenciaModel.IdUbigeo > 0)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdAgencia", agenciaModel.IdAgencia);
                    param.Add("@Agencia", agenciaModel.Agencia);
                    param.Add("@IdUbigeo", agenciaModel.IdUbigeo);
                    param.Add("@Direccion", agenciaModel.Direccion);
                    param.Add("@Telefono", agenciaModel.Telefono);
                    param.Add("@Latitud", agenciaModel.Latitud);
                    param.Add("@Longitud", agenciaModel.Longitud);
                    param.Add("@UserReg", agenciaModel.UserReg);
                    DapperORM.ExecuteWithoutReturn("SP_AGENCIA_AGREGAR", param);
                    return RedirectToAction("Inicio");
                }
                else
                {
                    //Carga Departamento
                    agenciaModel.DepartamentoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DEPARTAMENTOS", null).ToList();
                    agenciaModel.DepartamentoList.Insert(0, new UbigeoModel() { IdDepartamento = "0", Departamento = "--SELECCIONE--" });
                    //Carga Provincia
                    DynamicParameters param2 = new DynamicParameters();
                    param2.Add("@IdDepartamento", agenciaModel.IdDepartamento);
                    agenciaModel.ProvinciaList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_PROVINCIAS", param2).ToList();
                    agenciaModel.ProvinciaList.Insert(0, new UbigeoModel() { IdProvincia = "0", Provincia = "--SELECCIONE--" });
                    //Carga Ubigeo
                    param2.Add("@IdProvincia", agenciaModel.IdProvincia);
                    agenciaModel.DistritoList = DapperORM.ReturnList<UbigeoModel>("SP_UBIGEO_LISTAR_DISTRITO", param2).ToList();
                    agenciaModel.DistritoList.Insert(0, new UbigeoModel() { IdUbigeo = 0, Distrito = "--SELECCIONE--" });
                    return View(agenciaModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdAgencia", id);
            param.Add("@UserReg", "Admin");
            DapperORM.ExecuteWithoutReturn("SP_AGENCIA_ELIMINAR_ID", param);
            return RedirectToAction("Inicio");
        }


        /*public ActionResult LoadData()
        {
            //Get Parameters

            //get Start (paging start index) and length (page size for paging)
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            //Get Sort columns value
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            int pagesize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            var v = DapperORM.ReturnList<AgenciaModel>("SP_AGENCIA_LISTAR_ALL", null).ToList();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir))) {

                v = v.OrderBy(sortColumn + " " + sortColumnDir);
            }

            totalRecords = v.Count();
            var data = v.Skip(skip).Take(pagesize).ToList();
        }
        */

    }
}