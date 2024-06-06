using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class UrlService : IUrlService
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly IUrlManagementRepository _urlRepository;
        public UrlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _urlRepository = unitOfWork.UrlManagementRepository;
            this._mapper = mapper;
        }
        public async Task AddAsync(UrlModel model)
        {
            var url = _mapper.Map<UrlManagement>(model);
            await _urlRepository.AddAsync(url);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _urlRepository.DeleteAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UrlModel>> GetAllAsync()
        {
            var urls = await _urlRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UrlModel>>(urls);
        }

        public async Task<UrlModel> GetByIdAsync(int id)
        {
            var url = await _urlRepository.GetByIdAsync(id);
            return _mapper.Map<UrlModel>(url);

        }

        public async Task<UrlModel> GetByShortUrlAsync(string shortUrl)
        {
            var url = await _urlRepository.GetByShortUrlAsync(shortUrl);
            return _mapper.Map<UrlModel>(url);
        }

        public async Task<IEnumerable<UrlModel>> GetByUserIdAsync(string userId)
		{
			var urls = await _urlRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<UrlModel>>(urls);
		}

		public async Task UpdateAsync(UrlModel model)
        {
            var url = _mapper.Map<UrlManagement>(model);
            _urlRepository.Update(url);
            await _unitOfWork.SaveAsync();
        }
    }
}
