﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;
using Dominio;


namespace PortLog.Controllers
{
    public class UsuarioController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["cedula"] != null)
            {
                return Redirect("/usuario/bienvenido");
            }
            else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(string cedula, string password)
        {
            if (/*cedula != null && password != null &&*/ cedula.Length!=0 && password.Length!=0)
            {
                Usuario usuarioIngresado = FachadaDistribuidora.BuscarUsuarioPorCi(cedula);
                if (usuarioIngresado != null)
                {
                    if (usuarioIngresado.Contrasenia == password)
                    {
                        Session["cedula"] = usuarioIngresado.Cedula;
                        Session["rol"] = usuarioIngresado.Rol;
                        return Redirect("/usuario/bienvenido");
                    }
                    else
                    {
                        ViewBag.mensaje = "Las password no es correcta.";
                    }
                }
                else
                {
                    ViewBag.mensaje = "El Usuario no existe.";
                }
            }
            else {
                ViewBag.mensaje = "Los campos cedula y password no pueden ser nulos.";
            }

            return View();
        }

        public ActionResult Salir()
        {
            Session["rol"] = null;
            Session["cedula"] = null;
            return RedirectToAction("index");
        }

        public ActionResult Bienvenido() {
            if (Session["cedula"] == null)
            {
                return Redirect("/usuario/Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Alta()
        {
            if (Session["rol"].ToString() == "admin")
            {
                Usuario nuevoUsuario = new Usuario();
                return View(nuevoUsuario);
            }
            else
            {
                return Redirect("/usuario/bienvenido");
            }
        }


        [HttpPost]
        public ActionResult Alta(Usuario nuevo)
        { 

            if (Session["rol"].ToString() == "admin")
            {
                if (nuevo != null)
                {


                    bool rolValido = Dominio.Usuario.ValidarRol(nuevo.Rol);
                    bool passValida = Dominio.Usuario.ValidatePassword(nuevo.Contrasenia);
                    bool ciValida = Dominio.Usuario.ValidateCedula(Convert.ToString(nuevo.Cedula));
                    if (passValida && ciValida && rolValido)
                    {
                        RepoUsuario repoUser = new RepoUsuario();
                        Usuario nuevoUser = repoUser.BuscarPorId(nuevo.Cedula);
                        if (nuevoUser == null)
                        {
                            bool exito = FachadaDistribuidora.AltaUsuario(nuevo.Cedula, nuevo.Contrasenia, nuevo.Rol);
                            if (exito)
                            {
                                ViewBag.mensaje = "El usuario ha sido creado con exito.";
                            }
                            else
                            {
                                ViewBag.mensaje = "Error.";
                            }
                        }
                        else
                        {
                            ViewBag.mensaje = "El usuario ya existe.";
                        }

                    }
                    else
                    {
                        if (!ciValida)
                        {
                            ViewBag.mensaje = "Verifique que la cedula tenga 7 u 8 caracteres. ";
                        }
                        if (!passValida)
                        {
                            ViewBag.mensaje += "Verifique que su contrasenia sea de 6 caracteres, una letra en mayuscula, una letra en minuscula,y al menos un digito. ";
                        }
                        if (!rolValido)
                        {
                            ViewBag.mensaje += "Elija un rol para el usuario.";
                        }
                    }
                }
                return View(nuevo);
            }
            else
            {
                return Redirect("/usuario/bienvenido");
            }

        }
    }
}
