using System.Data;
using System.Text;
using Dapper;

namespace WcsDataGenerator.Repositories
{
	public class StorageDeviceStatusRepository(IDbConnection dbConnection) : IStorageDeviceStatusRepository
	{
		public async Task<bool> Insert(int count)
		{

	
			for (int i = 0; i < count; i+=10)
			{
				var values = new StringBuilder().Insert(0, $"('C0101' ,'Fault' ,'9091','1' ,NULL ,NULL,'2024-11-22 15:08:19.0853402','0001-01-01 00:00:00.0000000','Custom' ,'2024-11-22 15:08:19.1980494',0 ,'Custom' ,'{RandomDay()}'),", 10).ToString();
				var removed = values.Remove(values.Length - 1);

				var final = "INSERT INTO [Wcs].[StorageDeviceStatus] VALUES " + removed.ToString();

				await dbConnection.QueryAsync(final);
			}

			return true;
		}

		private Random gen = new Random();
		DateTime RandomDay()
		{
			DateTime start = new DateTime(2022, 1, 1, 0,0,0);
			var range = (long) (new DateTime(2023, 1, 1,0,0,0) - start).TotalSeconds;
			return start.AddSeconds(gen.NextInt64(range));
		}

	}
}
