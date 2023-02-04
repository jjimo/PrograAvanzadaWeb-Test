using System;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
	public class CategoryHelper
	{

		private ServiceRepository serviceRepository;


		public CategoryHelper()
		{
			serviceRepository = new ServiceRepository();
		}

		public List<CategoryModel> GetAll()
		{
			List<CategoryModel> lista;
			HttpResponseMessage responseMessage = serviceRepository.GetResponse("api/Category");
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			lista = JsonConvert.DeserializeObject<List<CategoryModel>>(content);

			return lista;
		}

		public CategoryModel Get(int id)
		{
			CategoryModel category;
			HttpResponseMessage responseMessage = serviceRepository.GetResponse("api/Category/" + id.ToString());
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			category = JsonConvert.DeserializeObject<CategoryModel>(content);

			return category;
		}
	}
}

