using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdvanta.Models;

namespace WebAdvanta.Controllers
{
    public class HomeController : Controller
    {
        private static List<EquipamentoModel> _listaEquipamentos = new List<EquipamentoModel>()
        {
            new EquipamentoModel() { Codigo=001, Nome="Chave L", IdUsuario= "Pedro" },
            new EquipamentoModel() { Codigo=002, Nome="Chave Philips", IdUsuario="Pedro" },
            new EquipamentoModel() { Codigo=003, Nome="Martelo", IdUsuario="Pedro" },
            new EquipamentoModel() { Codigo=004, Nome="Marreta", IdUsuario="Pedro" },
            new EquipamentoModel() { Codigo=005, Nome="Cave Estrela", IdUsuario="Pedro" },
            new EquipamentoModel() { Codigo=006, Nome="Chave Fenda", IdUsuario="João" },
            new EquipamentoModel() { Codigo=007, Nome="Alicate", IdUsuario="João" },
            new EquipamentoModel() { Codigo=008, Nome="Fita Isolante", IdUsuario="João" },
            new EquipamentoModel() { Codigo=009, Nome="Fita Veda rosca", IdUsuario="Bruno" }
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(_listaEquipamentos);
        }
        [HttpPost]
        public ActionResult RecuperarEquipamento(int codigo)
        {
           return Json(_listaEquipamentos.Find(x => x.Codigo == codigo));
        }

        [HttpPost]
        public ActionResult ExcluirEquipamento(int codigo)
        {
            var ret = false;

            var registroDB = _listaEquipamentos.Find(x => x.Codigo == codigo);
            if (registroDB != null)
            {
                _listaEquipamentos.Remove(registroDB);
                ret = true;
            }
            return Json(ret);
        }
        [HttpPost]
        public ActionResult SalvarEquipamento(EquipamentoModel model)
        {
            var registroDB = _listaEquipamentos.Find(x => x.Codigo == model.Codigo);
            if (registroDB == null)
            {
                registroDB = model;
                registroDB.Codigo = _listaEquipamentos.Max(x => x.Codigo) + 1;
                _listaEquipamentos.Add(registroDB);
            }
            else
            {
                registroDB.Codigo = model.Codigo;
                registroDB.Nome = model.Nome;
                registroDB.IdUsuario = model.IdUsuario;
            }

            return Json(registroDB);

        }
    }
}