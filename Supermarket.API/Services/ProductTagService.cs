using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ProductTagService : IProductTagService
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductTagResponse> AssignProductTagAsync(int productId, int tagId)
        {
            try
            {
                await _productTagRepository.AssignProductTag(productId, tagId);
                await _unitOfWork.CompleteAsync();
                ProductTag productTag = await _productTagRepository.FindByProductIdAndTagId(productId, tagId);
                return new ProductTagResponse(productTag);
            }
            catch (Exception ex)
            {
                return new ProductTagResponse($"An error ocurred while assigning Product and Tag: {ex.Message}");
            }
            

        }

        public Task<IEnumerable<ProductTag>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductTagResponse> UnassignProductTagAsync(int productId, int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
