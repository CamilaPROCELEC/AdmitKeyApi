using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgk_admitkey_WS_app.model.proc
{
    public class P5_Histo_Aper
    {
        public static Response historial(P5_histo_apertura historial)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = historial._trankey._app_fuente;
                vector_1[1] = historial._trankey._app_version;
                vector_1[2] = historial.res_codigo;
                vector_1[3] = historial.res_correo;
                vector_1[4] = historial.res_password;
                vector_1[5] = "";
                vector_1[6] = "";
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(historial._trankey, vector_1);

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
                    cb.sp = "usp_Web_S_app_p_5_historial_aperturas_c1_1_B_historial";//poner el nombre correcto
                    vector[0] = "@res_codigo,v," + historial.res_codigo;
                    vector[1] = "@res_correo,v," + historial.res_correo;
                    vector[2] = "@res_password,v," + historial.res_password;


                    dt = cb.consultar(vector, 3, strCon);


                    res.CodigoError = cb.valo_erro;
                    if (res.CodigoError == -1)
                    {

                        res.Message = "OK";
                        res.Message = cb.valo_resp;
                        var dataAsList = DataTableToList(dt);
                        res.Result = dataAsList;

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

        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }

            return list;
        }
    }
}
