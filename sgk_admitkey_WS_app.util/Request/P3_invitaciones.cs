using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgk_admitkey_WS_app.util.Request
{
    public class P3_invitaciones
    {
        public Trankey _trankey { get; set; }
        public string res_codigo { get; set; }
        public string res_correo { get; set; }
        public string res_password { get; set; }
        public string in_nombre { get; set; }
        public string in_numero { get; set; }
    }
}
