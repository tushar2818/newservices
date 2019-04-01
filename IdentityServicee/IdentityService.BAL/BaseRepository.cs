using IdentityService.DATA;
using IdentityService.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public class BaseRepository : IBaseRepository
    {
        protected ApplicationContext _dbContext;
        public IRequestDTO Request { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<ErrorMessageDTO> ErrorMessages { get; set; } = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Code = "", Message = "" } };
        public string DisplayMessage { get; set; } = "";

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
