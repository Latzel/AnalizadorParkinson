using MV_P1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MV_P1.Controllers
{
    public class HomeController : Controller
    {
        PDcontext db = new PDcontext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult listaPacientes()
        {
            var lst = db.tbl_Pacientes.ToList();
            return View(lst);
        }

        public ActionResult formularioPaciente()
        {
            var idPaciente = Request.Params["idPaciente"];
            if (idPaciente != null)
            {
                int id = int.Parse(idPaciente);
                var paciente = db.tbl_Pacientes.Where(x => x.idPaciente == id).FirstOrDefault();

                //Sirve oara asignar valores u objetos desde el controlador para la vista
                ViewBag.Paciente = paciente;


            }
            return View();
        }

        public JsonResult guardarPaciente(int? idPaciente, string NombrePaciente, string ApellidoPaterno, string ApellidoMaterno, string Genero, string Edad)
        {
            DateTime fechaN = new DateTime();

            if (Genero == "----" || NombrePaciente == "" || ApellidoPaterno == "" || ApellidoMaterno == "" || Edad == "")
            {
                return Json(null);
            }
            else
            {


                fechaN = DateTime.Parse(Edad);

                if (idPaciente != null)
                {

                    var Paciente = db.tbl_Pacientes.Where(x => x.idPaciente == idPaciente).FirstOrDefault();

                    Paciente.NombrePaciente = NombrePaciente;
                    Paciente.ApellidoPaterno = ApellidoPaterno;
                    Paciente.ApellidoMaterno = ApellidoMaterno;
                    Paciente.Genero = Genero;
                    Paciente.Edad = fechaN;
                    Paciente.idTipoParkinson = 1;
                    Paciente.Activo = 1;


                    db.SaveChanges();
                }
                else
                {
                    tbl_Pacientes a = new tbl_Pacientes();

                    a.NombrePaciente = NombrePaciente;
                    a.ApellidoPaterno = ApellidoPaterno;
                    a.ApellidoMaterno = ApellidoMaterno;
                    a.Genero = Genero;
                    a.Edad = fechaN;
                    a.idTipoParkinson = 1;
                    a.Activo = 1;

                    db.tbl_Pacientes.Add(a);

                    db.SaveChanges();
                }

                return Json("");
            }


            //tbl_Pacientes a = new tbl_Pacientes();

            //a.NombrePaciente = NombrePaciente;
            //a.ApellidoPaterno = ApellidoPaterno;
            //a.ApellidoMaterno = ApellidoMaterno;
            //a.Edad = Edad;
            //a.idTipoParkinson = 1;

            //db.tbl_Pacientes.Add(a);
            //db.SaveChanges();


        }

        public ActionResult Eliminar(int? idPaciente)
        {
            var Paciente = db.tbl_Pacientes.Where(x => x.idPaciente == idPaciente).FirstOrDefault();
            //db.tbl_Pacientes.Remove(Paciente);
            Paciente.Activo = 0;

            db.SaveChanges();


            return RedirectToAction("listaPacientes", "home");
        }

        public ActionResult CargarIMG()
        {
            return View();
        }

        public ActionResult PRUEBAimg()
        {
            var idPaciente = Request.Params["idPaciente"];
            var paciente = Request.Params["paciente"];

            ViewBag.idPaciente = idPaciente;

            ViewBag.nombre = paciente;

            return View();
        }

        public ActionResult AnalisisIMG()
        {

            return View();
        }

        // public JsonResult Upload()
        //{
        //     for (int i = 0; i < Request.Files.Count; i++)
        //     {
        //         HttpPostedFileBase file = Request.Files[i]; //Uploaded file
        //                                                     //Use the following properties to get file's name, size and MIMEType
        //         string[] array;
        //         array = Request.Files.AllKeys[i].Split('-');

        //         if (System.IO.Directory.Exists(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim() + "-" + array[1].Trim() + "-" + array[2].Trim() + "-" + array[3].Trim())))
        //         {
        //             //DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/ImagenesPacientes/" + array[0]));

        //             //foreach (FileInfo fi in dir.GetFiles())
        //             //{
        //             //    fi.Delete();
        //             //}
        //         }
        //         else
        //         {
        //             System.IO.Directory.CreateDirectory(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim() + "-" + array[1].Trim() + "-" + array[2].Trim() + "-" + array[3].Trim()));


        //         }

        //         int fileSize = file.ContentLength;
        //         string fileName = file.FileName;
        //         string mimeType = file.ContentType;
        //         System.IO.Stream fileContent = file.InputStream;


        //         //To save file, use SaveAs method


        //         file.SaveAs(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim() + "-" + array[1].Trim() + "-" + array[2].Trim() + "-" + array[3].Trim() + "/") + Path.GetFileName(fileName)); //File will be saved in application root
        //     }
        //     return Json("");
        // }

        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                string[] array;
                array = Request.Files.AllKeys[i].Split('-');

                if (System.IO.Directory.Exists(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim())))
                {
                    //DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/ImagenesPacientes/" + array[0]));

                    //foreach (FileInfo fi in dir.GetFiles())
                    //{
                    //    fi.Delete();
                    //}
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim()));


                }

                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;


                //To save file, use SaveAs method


                file.SaveAs(Server.MapPath("~/ImagenesPacientes/" + array[0].Trim() + "/") + Path.GetFileName(fileName)); //File will be saved in application root
            }
            return Json("");
        }



        public JsonResult guardarFechaAnalisis(int? idPaciente, int ResultadoAnalisis, List<Files> lstFiles)
        {
            DateTime Ufecha = DateTime.Now;

            int Resultado = ResultadoAnalisis;


            var Paciente = db.tbl_Pacientes.Where(x => x.idPaciente == idPaciente).FirstOrDefault();

            Paciente.UltimoAnalisis = Ufecha;
            Paciente.idTipoParkinson = Resultado;



            db.SaveChanges();

            if (lstFiles != null)
            {
                foreach (var item in lstFiles)
                {
                    tbl_ImagenesPacientes imagen = new tbl_ImagenesPacientes();

                    imagen.fechaCargada = DateTime.Now;

                    imagen.fileName = item.FileName;

                    imagen.idPaciente = idPaciente;

                    db.tbl_ImagenesPacientes.Add(imagen);

                    db.SaveChanges();
                }
            }


            return Json(idPaciente);

        }

        public ActionResult ObtenerImagenes(int idPaciente)
        {
            var listaImagenes = db.sp_ObtenerImagenes_V3(idPaciente).ToList();

            ViewBag.idPaciente = idPaciente;

            return PartialView("PV_tabla", listaImagenes);
        }

        public ActionResult EliminarIMG(int idPaciente, string FileName, int idImagenPaciente)
        {

            // Ruta de la carpeta donde están almacenadas las imágenes
            string archivo = Server.MapPath("~/ImagenesPacientes/" + idPaciente + "/" + FileName);


            System.IO.File.Delete(archivo);

            var imagen = db.tbl_ImagenesPacientes.Where(x => x.idImagenPaciente == idImagenPaciente).FirstOrDefault();

            db.tbl_ImagenesPacientes.Remove(imagen);

            db.SaveChanges();

            return RedirectToAction("PRUEBAimg", "home");

        }

    }


}