namespace WcsDataGenerator.Repositories
{
	public interface IStorageDeviceStatusRepository
	{
		public Task<bool> Insert(int count);
	}
}
