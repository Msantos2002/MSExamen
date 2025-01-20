using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using MSExamen.Models;

using System.Net.Http;

using System.Threading.Tasks;

using System.Collections.Generic;

namespace MSExamen.Services
{

    public class GoogleMapsServiceMS

    {

        private readonly HttpClient _httpClient;

        public GoogleMapsServiceMS()

        {

            _httpClient = new HttpClient();

        }

        public async Task<List<LugarMS>> ObtenerLugares(string apiKey)

        {

            string url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-0.180653,-78.467834&radius=1500&type=restaurant&key={apiKey}";

            var respuesta = await _httpClient.GetStringAsync(url);

            var datos = JsonConvert.DeserializeObject<GoogleMapsRespuesta>(respuesta);

            // Transformar datos al modelo LugarMS

            List<LugarMS> lugares = new List<LugarMS>();

            foreach (var resultado in datos.Results)

            {

                lugares.Add(new LugarMS

                {

                    Nombre = resultado.Name,

                    Descripcion = resultado.Vicinity,

                    Latitud = resultado.Geometry.Location.Lat,

                    Longitud = resultado.Geometry.Location.Lng

                });

            }

            return lugares;

        }

    }

    public class GoogleMapsRespuesta

    {

        public List<Result> Results { get; set; }

    }

    public class Result

    {

        public string Name { get; set; }

        public string Vicinity { get; set; }

        public Geometry Geometry { get; set; }

    }

    public class Geometry

    {

        public Location Location { get; set; }

    }

    public class Location

    {

        public double Lat { get; set; }

        public double Lng { get; set; }

    }

} 