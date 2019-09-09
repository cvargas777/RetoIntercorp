using Captacion.BE;
using Firebase.Database;
using Newtonsoft.Json;
//using FireSharp;
//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captacion.BL
{
    public class ClienteBL
    {
        FirebaseClient client = new FirebaseClient(
              ConfigurationManager.AppSettings["UrlFirebase"],
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(ConfigurationManager.AppSettings["TokenFirebase"])
              });

        public async Task<IEnumerable<Cliente>> Listar()
        {
            var response = await client.Child("Cliente").OnceAsync<Cliente>();

            var clientes = response.Select(x => x.Object).ToList();
            
            return clientes;
        }

        public async Task<KpiCliente> Kpi()
        {
            var response = await client.Child("Cliente").OnceAsync<Cliente>();

            var edades = response.Select(x => x.Object.Edad).ToList();

            double promedio = 0;

            double desviacion = 0;

            if (edades.Count > 0)
            {
                promedio = edades.Sum(x => x) / edades.Count;

                edades.ForEach(x => desviacion += Math.Pow(x - promedio, 2));

                desviacion = Math.Sqrt(desviacion / (edades.Count - 1));
            }
            
            KpiCliente kpi = new KpiCliente() {
                Promedio = promedio,
                Desviacion = desviacion
            };

            return kpi;
        }

        public async Task<bool> Crear(Cliente cliente)
        {
            cliente.FechaMuerte = cliente.FechaNacimiento.AddYears(new Random().Next((DateTime.Today - cliente.FechaNacimiento).Days));

            await client.Child("Cliente").PostAsync(JsonConvert.SerializeObject(cliente));

            return true;
        }
    }
}
