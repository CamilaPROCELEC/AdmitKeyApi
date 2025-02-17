using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgk_admitkey_WS_app.model.proc;
using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;

namespace sgk_admitkey_WS_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C3_Invitaciones : ControllerBase
    {

        [HttpPost]
        [Route("m1_invitaciones")]
        public Response m1_invitaciones([FromBody] P3_invitaciones invitaciones)
        {
            Response res = P3_Invitaciones.invitacion(invitaciones);
            return res;
        }
    }
}
