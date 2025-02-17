using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgk_admitkey_WS_app.model.proc
{
    public static class P2_Menu
    {
        public static Response buscaQr(P2_menu_qr busca_qr)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = busca_qr._trankey._app_fuente;
                vector_1[1] = busca_qr._trankey._app_version;
                vector_1[2] = busca_qr.res_codigo;
                vector_1[3] = busca_qr.res_correo;
                vector_1[4] = busca_qr.res_password;
                vector_1[5] = "";
                vector_1[6] = "";
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(busca_qr._trankey, vector_1);

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

                    string[] vector = new string[3];
                    cb.sp = "usp_Web_S_app_p_2_menu_c1_1_B_QR";//poner el nombre correcto
                    vector[0] = "@res_codigo,v," + busca_qr.res_codigo;
                    vector[1] = "@res_correo,v," + busca_qr.res_correo;
                    vector[2] = "@res_password,v," + busca_qr.res_password;


                    dt = cb.consultar(vector, 3, strCon);


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

        public static Response recuperaContrasenia(P2_recu_contr recupera_contrasenia)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = recupera_contrasenia._trankey._app_fuente;
                vector_1[1] = recupera_contrasenia._trankey._app_version;
                vector_1[2] = recupera_contrasenia.res_codigo;
                vector_1[3] = recupera_contrasenia.res_correo;
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

                    string[] vector = new string[2];
                    cb.sp = "usp_Web_S_app_p_2_menu_c1_2_G_recupera_contrasenia";//poner el nombre correcto
                    vector[0] = "@res_codigo,v," + recupera_contrasenia.res_codigo;
                    vector[1] = "@res_correo,v," + recupera_contrasenia.res_correo;


                    dt = cb.consultar(vector, 2, strCon);


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
