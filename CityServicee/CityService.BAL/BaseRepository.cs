﻿using CityService.DATA;
using CityService.DTO;
using System; 

namespace CityService.BAL
{
    public class BaseRepository : IBaseRepository
    {
        protected ApplicationContext _dbContext;
        public IRequestDTO Request { get; set; }
        public bool IsSuccess { get; set; } 

        public BaseRepository(ApplicationContext applicationContext)
        {
            this._dbContext = applicationContext;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        } 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
