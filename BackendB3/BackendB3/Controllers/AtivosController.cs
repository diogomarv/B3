using B3.Model.Calculo;
using BackendB3.Models.Request;
using System;
using System.Web.Http.Cors;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BackendB3.Controllers
{
    public class AtivosController : ApiController
    {
        private readonly CalculoCdb _calculoCdb;

        public AtivosController()
        {
            _calculoCdb = new CalculoCdb();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/ativos/calcular-cdb")]
        [HttpPost]
        public IHttpActionResult Calcular([FromBody] CalcularCdbRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.First().Errors.Last().ErrorMessage);
            }

            return Ok(_calculoCdb.CalcularCdb(request.Valor, request.QtdMeses));
        }
    }
}