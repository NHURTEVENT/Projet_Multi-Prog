using System;
namespace Controller {
	public interface IClient {
		void Book();
		List<Model.Kitchen.Dish> GetOrder();
		void ConsumeWaterAndBread();
		void Pay();

	}

}
