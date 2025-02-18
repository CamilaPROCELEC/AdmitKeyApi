using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgk_admitkey_WS_app.model.proc
{
    public static class P3_Invitaciones
    {
        public static Response invitacion(P3_invitaciones invitaciones)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = invitaciones._trankey._app_fuente;
                vector_1[1] = invitaciones._trankey._app_version;
                vector_1[2] = invitaciones.res_codigo;
                vector_1[3] = invitaciones.res_correo;
                vector_1[4] = invitaciones.res_password;
                vector_1[5] = invitaciones.in_nombre;
                vector_1[6] = invitaciones.in_numero;
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(invitaciones._trankey, vector_1);

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

                    string[] vector = new string[5];
                    cb.sp = "usp_Web_S_app_p_3_invitaciones_c3_1_G_invitacion";//poner el nombre correcto
                    vector[0] = "@res_codigo,v," + invitaciones.res_codigo;
                    vector[1] = "@res_correo,v," + invitaciones.res_correo;
                    vector[2] = "@res_password,v," + invitaciones.res_password;
                    vector[3] = "@in_nombre,v," + invitaciones.in_nombre;
                    vector[4] = "@in_numero,v," + invitaciones.in_numero;

                    dt = cb.consultar(vector, 5, strCon);


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
    }
}
