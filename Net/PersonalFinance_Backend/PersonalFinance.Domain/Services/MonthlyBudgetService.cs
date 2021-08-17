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
    public class MonthlyBudgetService : IMonthlyBudgetService
    {
        private readonly IRepository<MonthlyBudget> _repository;

        public MonthlyBudgetService(IRepository<MonthlyBudget> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<MonthlyBudgetDto> GetByIdAsync(int id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted).ConfigureAwait(false);
            return Mapper.Map<MonthlyBudgetDto>(result);
        }
        public async Task<IEnumerable<MonthlyBudgetDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await _repository.GetAllAsync(x => !x.Deleted, page, limit, orderBy, ascending).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<MonthlyBudgetDto>>(result);
        }
        public (bool status, int id) Post(MonthlyBudgetDto entity)
        {
            var obj = Mapper.Map<MonthlyBudget>(entity);
            var result = _repository.Insert(obj);
            return (result, obj.Id);
        }
        public async Task<bool> PutAsync(int id, MonthlyBudgetDto entity)
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
            existingEntity.ModifiedDate = DateTime.Now;
            existingEntity.ModificationUser = entity.UserName;
            existingEntity.Deleted = true;
            return _repository.Update(existingEntity);
        }

    }
}
