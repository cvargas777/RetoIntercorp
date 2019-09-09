using Captacion.BE;
using Captacion.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Captacion.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        ClienteBL bl = new ClienteBL();

        [Route("listclientes")]
        [HttpGet]
        public async Task<IEnumerable<Cliente>> listclientes()
        {
            return await bl.Listar();
        }
        
        [Route("kpideclientes")]
        [HttpGet]
        public async Task<KpiCliente> kpideclientes()
        {
            return await bl.Kpi();
        }

        [Route("creacliente")]
        [HttpPost]
        public async Task<bool> Post(Cliente cliente)
        {
            return await bl.Crear(cliente);
        }
    }
}
