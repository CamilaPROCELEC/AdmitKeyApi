using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sgk_admitkey_WS_app.model.proc;
using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;

namespace sgk_admitkey_WS_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C4_Historial_Invitaciones : ControllerBase
    {
        [HttpPost]
        [Route("m1_historial")]
        public Response m1_historial([FromBody] P4_histo_invi invitaciones)
        {
            Response res = P4_Histo_Invi.historial(invitaciones);
            return res;
        }
    }
}
