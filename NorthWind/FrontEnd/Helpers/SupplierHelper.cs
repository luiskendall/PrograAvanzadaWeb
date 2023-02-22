using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class SupplierHelper
    {
        private ServiceRepository ServiceRepository;
        public SupplierHelper()
        {
            ServiceRepository = new ServiceRepository();

        }

        public List<SupplierViewModel> GetAll()
        {
            List<SupplierViewModel> listaSup = new List<SupplierViewModel>();

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/supplier");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                listaSup = JsonConvert.DeserializeObject<List<SupplierViewModel>>(content);
            }

            return listaSup;
        }

        public SupplierViewModel Get(int id)
        {
            SupplierViewModel supplier;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/supplier/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            supplier = JsonConvert.DeserializeObject<SupplierViewModel>(content);

            return supplier;
        }
    }
}
