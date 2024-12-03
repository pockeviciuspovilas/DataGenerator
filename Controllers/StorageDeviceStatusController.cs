
using Microsoft.AspNetCore.Mvc;
using WcsDataGenerator.Repositories;

namespace WcsDataGenerator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StorageDeviceStatusController : ControllerBase
	{
		private readonly ILogger<StorageDeviceStatusController> _logger;
		private readonly IStorageDeviceStatusRepository _storageDeviceStatusRepository;

		public StorageDeviceStatusController(ILogger<StorageDeviceStatusController> logger, IStorageDeviceStatusRepository storageDeviceStatusRepository)
		{
			_logger = logger;
			_storageDeviceStatusRepository = storageDeviceStatusRepository;
		}

		[HttpGet]
		public async Task<bool> Generate(int count)
		{
			return await _storageDeviceStatusRepository.Insert(count);
		}
	}
}
