using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        private ServiceRepository ServiceRepository;

        public ShipperHelper()
        {
            ServiceRepository = new ServiceRepository();
        }
        public List<ShipperViewModel> GetAll()
        {

            List<ShipperViewModel> lista;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/shipper/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);

            return lista;
        }

        public ShipperViewModel Get(int id)
        {

            ShipperViewModel shipper;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/shipper/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }

        public ShipperViewModel Create(ShipperViewModel ship)
        {

            ShipperViewModel shipper;

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/shipper/", ship);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }

        public ShipperViewModel Delete(int id)
        {

            ShipperViewModel shipper;

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/shipper/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }

        public ShipperViewModel Edit(ShipperViewModel ship)
        {

            ShipperViewModel shipper;

            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/shipper/", ship);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }
    }
}
