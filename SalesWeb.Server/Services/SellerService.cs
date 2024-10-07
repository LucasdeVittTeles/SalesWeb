using SalesWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Services.Exceptions;
using AutoMapper;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Repository;

namespace SalesWeb.Server.Services
{
    public class SellerService : ISellerService
    {

        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SellerDto>> GetAllAsync()
        {
            var sellers = await _sellerRepository.GetAllAsync();
            return _mapper.Map<List<SellerDto>>(sellers);
        }


        public async Task<SellerDto> GetByIdAsync(int id)
        {
            var seller = await _sellerRepository.GetByIdAsync(id);
            return _mapper.Map<SellerDto>(seller);
        }


        public async Task AddAsync(SellerDto sellerDto)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            await _sellerRepository.AddAsync(seller);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _sellerRepository.DeleteAsync(id);
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(SellerDto sellerDto)
        {

            var seller = _mapper.Map<Seller>(sellerDto);
            try
            {
                await _sellerRepository.UpdateAsync(seller);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
