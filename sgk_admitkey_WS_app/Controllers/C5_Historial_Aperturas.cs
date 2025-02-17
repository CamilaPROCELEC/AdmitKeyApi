using Microsoft.AspNetCore.Mvc;
using sgk_admitkey_WS_app.model.proc;
using sgk_admitkey_WS_app.util.Request;
using sgk_admitkey_WS_app.util.Respuesta;

namespace sgk_admitkey_WS_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class C5_Historial_Aperturas : ControllerBase
    {
        [HttpPost]
        [Route("m1_historial")]
        public Response m1_historial([FromBody] P5_histo_apertura invitaciones)
        {
            Response res = P5_Histo_Aper.historial(invitaciones);
            return res;
        }
    }
}
