using Microsoft.AspNetCore.Mvc;
using ApiCalculoDeHoras.Models;

namespace ApiCalculoDeHoras.Controllers
{
    public class ServiceController : Controller
    {
        //GetServices, GetServiceCost
        [HttpGet]
        [Route("GetServices")]
        public JsonResult GetServices()
        {
            //instalação, manutenção, avaliação, cotação
            try
            {
                List<Services> listServices = new List<Services>();
                Services service = new Services();
                service.id = 1;
                service.nome = "Instalação";
                service.valor = 100;
                listServices.Add(service);


                service = new Services();
                service.id = 2;
                service.nome = "Manutenção";
                service.valor = 70;
                listServices.Add(service);

                service = new Services();
                service.id = 3;
                service.nome = "Avaliação";
                service.valor = 50;
                listServices.Add(service);

                service = new Services();
                service.id = 4;
                service.nome = "Cotação";
                service.valor = 30;
                listServices.Add(service);

                return new JsonResult(listServices);


            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetServiceCost")]
        public JsonResult GetServiceCost(int id,int horas)
        {
            try
            {
                List<Services> listServices = new List<Services>();
                Services service = new Services();
                service.id = 1;
                service.nome = "Instalação";
                service.valor = 100;
                listServices.Add(service);


                service = new Services();
                service.id = 2;
                service.nome = "Manutenção";
                service.valor = 70;
                listServices.Add(service);

                service = new Services();
                service.id = 3;
                service.nome = "Avaliação";
                service.valor = 50;
                listServices.Add(service);

                service = new Services();
                service.id = 4;
                service.nome = "Cotação";
                service.valor = 30;
                listServices.Add(service);
                double totalHoras;
                double resultado =0;
                double diferenca;
                double perc;
                
                if (horas < 2 || horas > 12)
                {
                    return new JsonResult("Serviço com menos de 2 horas ou mais de 12 horas");
                }
                if (horas > 8)
                {
                    diferenca = horas - 8;
                    perc = diferenca + (diferenca*0.5);
                    totalHoras = horas + perc;

                }
                else
                    totalHoras = horas;
                for (int i = 0; i < listServices.Count; i++)
                {
                    if (listServices[i].id == id)
                    {
                        resultado = listServices[i].valor * totalHoras;
                    }
                }
                return new JsonResult(resultado);
                
                               

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
