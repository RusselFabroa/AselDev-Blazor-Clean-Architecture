using AselBlazorCleanArchitecture.Infrastructure.Data.CleanPattern;
using AselBlazorCleanArchitecture.Shared.Models;
using AselBlazorCleanArchitecture.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AselBlazorCleanArchitecture.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AselController : ControllerBase
    {
        private readonly IDBContextFactory _dbContext;
        public AselController(IDBContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<APIResponse<List<EmployeeInformation>>> GetEmployeeList()
        {
            try
            {
                using var dbContext = _dbContext.CreateDbContext("TPCInformationDB");

                var employees = await dbContext.Set<EmployeeInformation>().ToListAsync();
                return new APIResponse<List<EmployeeInformation>>(employees,"Operation Succesfull",200);
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                return new APIResponse<List<EmployeeInformation>>
                {
                    Message = $"An error occurred while retrieving employee list: {ex.Message}",
                    StatusCode = 500,
                };
            }
        }


    }
}
