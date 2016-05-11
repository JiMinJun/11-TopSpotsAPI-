using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TopSpotsAPI.Models;

namespace TopSpotsAPI.Controllers
{
    [EnableCors("http://127.0.0.1:8080", "*", "*")]

    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            //string AllText = File.ReadAllText("C:/dev/11-TopSpotsAPI-/TopSpotsAPI/TopSpotsAPI/topSpots.json");
            var jsonArray = JsonConvert.DeserializeObject<IEnumerable<TopSpot>>(File.ReadAllText("C:/dev/11-TopSpotsAPI-/TopSpotsAPI/TopSpotsAPI/topSpots.json"));

            return jsonArray;
        }

        //public object Get()
        //{
        //    string allText = File.ReadAllText("C:/dev/11-TopSpotsAPI-/TopSpotsAPI/TopSpotsAPI/topSpots.json");

        //    object jsonObject = JsonConvert.DeserializeObject(allText);
        //    return jsonObject;
        //}

        // GET: api/TopSpots/5
        public object Get(int id)
        {
            return "value";
        }

        // POST: api/TopSpots
        public void Post([FromBody]TopSpot value)
        {
            var topSpot = new TopSpot
            {
                Name = value.Name, 
                Description = value.Description,
                Location = value.Location   
            };

            var jsonArray = Get().Concat(new TopSpot[] {topSpot});            
            var updatedJsonArray = JsonConvert.SerializeObject(jsonArray, Formatting.Indented);

            File.WriteAllText("C:/dev/11-TopSpotsAPI-/TopSpotsAPI/TopSpotsAPI/topSpots.json", updatedJsonArray);
        
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
