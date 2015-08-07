using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models.ApiModels;

namespace TMD.Web.Areas.Api.Controllers
{
    public class MunicipalController : ApiController
    {
        private readonly IMunicipalService municipalService;

        public MunicipalController(IMunicipalService municipalService)
        {
            this.municipalService = municipalService;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<MunicipalApiModel> Get(long id)
        {
            var municipals = municipalService.GetMunicipalsByCityId(id).ToList();

            return municipals.Select(x=>x.CreateFromServerToClientApi());
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}