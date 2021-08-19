﻿using AutoMapper;
using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using PersonalFinance.Infraestructure.DataAcces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Services
{
    public class SavingDetailService : ISavingDetailService
    {
        private readonly IRepository<SavingDetail> _repository;

        public SavingDetailService(IRepository<SavingDetail> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<SavingDetailDto> GetByIdAsync(int id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted).ConfigureAwait(false);
            return Mapper.Map<SavingDetailDto>(result);
        }
        public async Task<IEnumerable<SavingDetailDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await _repository.GetAllAsync(x => !x.Deleted, page, limit, orderBy, ascending).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<SavingDetailDto>>(result);
        }
        public (bool status, int id) Post(SavingDetailDto entity)
        {
            var obj = Mapper.Map<SavingDetail>(entity);
            var result = _repository.Insert(obj);
            return (result, obj.Id);
        }
        public async Task<bool> PutAsync(int id, SavingDetailDto entity)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (existingEntity is null) return false;

            Mapper.Map(entity, existingEntity);
            return _repository.Update(existingEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (existingEntity is null) return false;
            return _repository.Delete(existingEntity);
        }

        public async Task<bool> DeleteLogicAsync(DeletedInfo<int> entity)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id == entity.Id).ConfigureAwait(false);
            if (existingEntity is null) return false;
            existingEntity.ModificationDate = DateTime.Now;
            existingEntity.ModificationUser = entity.UserName;
            existingEntity.Deleted = true;
            return _repository.Update(existingEntity);
        }

    }
}
