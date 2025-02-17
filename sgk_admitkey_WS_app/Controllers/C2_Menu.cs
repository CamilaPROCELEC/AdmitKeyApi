using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgk_admitkey_WS_app.model.proc;
using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;

namespace sgk_admitkey_WS_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C2_Menu : ControllerBase
    {

        [HttpPost]
        [Route("m1_qr")]
        public Response m1_qr([FromBody] P2_menu_qr busca_qr)
        {
            Response res = P2_Menu.buscaQr(busca_qr);
            return res;
        }

        [HttpPost]
        [Route("m2_recuperaContrasenia")]
        public Response recuperaContrasenia([FromBody] P2_recu_contr recupera_contrasenia)
        {
            Response res = P2_Menu.recuperaContrasenia(recupera_contrasenia);
            return res;
        }

    }
}
