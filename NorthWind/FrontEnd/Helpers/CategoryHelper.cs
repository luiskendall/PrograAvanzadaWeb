using FrontEnd.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace FrontEnd.Helpers
{
    public class CategoryHelper
    {
        private ServiceRepository ServiceRepository;

        public CategoryHelper()
        {
            ServiceRepository = new ServiceRepository();
        }
        public List<CategoryViewModel> GetAll()
        {

            List<CategoryViewModel> lista;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);

            return lista;
        }

        public CategoryViewModel Get(int id)
        {

            CategoryViewModel category;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

        public CategoryViewModel Create(CategoryViewModel cat)
        {

            CategoryViewModel category;

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/category/", cat);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

        public CategoryViewModel Delete(int id)
        {

            CategoryViewModel category;

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/category/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

        public CategoryViewModel Edit(CategoryViewModel cat)
        {

            CategoryViewModel category;

            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/category/", cat);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

    }
}
