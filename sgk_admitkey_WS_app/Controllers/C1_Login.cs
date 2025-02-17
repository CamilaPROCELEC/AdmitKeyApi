using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgk_admitkey_WS_app.model.proc;
using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;

namespace sgk_admitkey_WS_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C1_Login : ControllerBase
    {
        [HttpPost]
        [Route("m1_valida_ingreso")]
        public Response m1_valida_ingreso([FromBody] P1_login_usua login_usuario)
        {
            Response res = P1_Login.validaIngreso(login_usuario);
            return res;
        }

        [HttpPost]
        [Route("m2_cambio_contrasenia")]
        public Response c2_cambio_contrasenia([FromBody] P1_recu_contr recupera_contrasenia)
        {
            Response res = P1_Login.recuperaContrasenia(recupera_contrasenia);
            return res;
        }
    }
}
