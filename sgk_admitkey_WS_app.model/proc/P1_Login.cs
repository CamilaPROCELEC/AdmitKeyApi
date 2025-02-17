using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sgk_admitkey_WS_app.model.proc
{
    public static class P1_Login
    {
        public static Response validaIngreso(P1_login_usua login_usuario)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = login_usuario._trankey._app_fuente;
                vector_1[1] = login_usuario._trankey._app_version;
                vector_1[2] = login_usuario.res_correo;
                vector_1[3] = login_usuario.res_password;
                vector_1[4] = "";
                vector_1[5] = "";
                vector_1[6] = "";
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(login_usuario._trankey, vector_1);

                if (!res_identidad.CodigoError.Equals(-1))
                {
                    res.Message = "Que pena me da tu caso";
                    res.CodigoError = res_identidad.CodigoError;
                    res.Message = res_identidad.Message;
                    return res;
                }
                else
                {

                    data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                    System.Data.DataTable dt;
                    string strCon = util.Conexion.Conexion.CadenaConexion();

                    string[] vector = new string[2];
                    cb.sp = "usp_Web_S_app_p_1_login_c1_1_B_valida_ingreso";//poner el nombre correcto
                    vector[0] = "@res_correo,v," + login_usuario.res_correo;
                    vector[1] = "@res_password,v," + login_usuario.res_password;


                    dt = cb.consultar(vector, 2, strCon);


                    res.CodigoError = cb.valo_erro;
                    if (res.CodigoError == -1)
                    {

                        res.Message = "OK";
                        res.Message = cb.valo_resp;
                        //res.Result = dt;

                    }
                    else
                    {
                        res.Message = "Que pena me da tu caso";
                        res.Message = cb.valo_resp;
                    }
                }


            }
            catch (Exception ex)
            {
                res.CodigoError = -100;
                res.Message = "Error inesperado";
                res.Message = ex.Message;
            }
            return res;



        }

        public static Response recuperaContrasenia(P1_recu_contr recupera_contrasenia)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = recupera_contrasenia._trankey._app_fuente;
                vector_1[1] = recupera_contrasenia._trankey._app_version;
                vector_1[2] = recupera_contrasenia.res_correo;
                vector_1[3] = "";
                vector_1[4] = "";
                vector_1[5] = "";
                vector_1[6] = "";
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(recupera_contrasenia._trankey, vector_1);





                if (!res_identidad.CodigoError.Equals(-1))
                {
                    res.Message = "Que pena me da tu caso";
                    res.CodigoError = res_identidad.CodigoError;
                    res.Message = res_identidad.Message;
                    return res;
                }
                else
                {

                    data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                    System.Data.DataTable dt;
                    string strCon = util.Conexion.Conexion.CadenaConexion();

                    string[] vector = new string[1];
                    cb.sp = "usp_Web_S_app_p_1_login_c1_2_G_recupera_contrasenia";//poner el nombre correcto
                    vector[0] = "@res_correo,v," + recupera_contrasenia.res_correo;
                    dt = cb.consultar(vector, 1, strCon);


                    res.CodigoError = cb.valo_erro;
                    if (res.CodigoError == -1)
                    {

                        res.Message = "OK";
                        res.Message = cb.valo_resp;
                       // res.Result = dt;

                    }
                    else
                    {
                        res.Message = "Que pena me da tu caso";
                        res.Message = cb.valo_resp;
                    }



                }


            }
            catch (Exception ex)
            {
                res.CodigoError = -100;
                res.Message = "Error inesperado";
                res.Message = ex.Message;
            }
            return res;



        }




    }
}
