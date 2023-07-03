using TataGamedom.Models.Dtos.InventoryItems;
using TataGamedom.Models.Dtos.Orders;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Services;

namespace TestProject
{
	public class TestGetIndex
	{
		[Test]
		public void �ثeOrderIndexMax��300()
		{
			var dto = new OrderDto { CreatedAt = new DateTime(2023,06,30),ShipmemtMethodId = 1 , MemberId = 1 , Id = 1 };
			var orderIndexGenerator = new IndexGenerator(300);

			string expectedIndex = "2023063011301";
			string actualIndex = orderIndexGenerator.GetOrderIndex(dto);

			Assert.That(actualIndex, Is.EqualTo(expectedIndex));
		}


		//[Test]
		//public void �p�GId���Q�ǤJ() //�|�Q�ɤJ0
		//{
		//	throw new NotImplementedException();
		//	//var dto = new OrderDto { CreatedAt = new DateTime(2023, 06, 30), ShipmemtMethodId = 1, MemberId = 1 };
		//	//var orderIndexGenerator = new OrderIndexGenerator();

		//	//string expectedIndex = "2023063010";
		//	//string actualIndex = orderIndexGenerator.GetIndex(dto);

		//	//Assert.AreEqual(expectedIndex, actualIndex);
		//}

		[Test]
		public void �ثeInventoryItemId�̤j�Ȭ�701_ProductId��1_Index��PC001()
		{
			var dto = new InventoryItemCreateDto { ProductId = 1, StockInSheetIndex = "�i�f��s��50" };
			var orderIndexGenerator = new IndexGenerator(701);

			string expectedIndex = "PC001�i�f��s��50702";
			string actualIndex = orderIndexGenerator.GetSKU(dto, "PC001");

			Assert.That(actualIndex, Is.EqualTo(expectedIndex));
		}

	}
}