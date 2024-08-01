using DBFirstNeat.Models;
using DBFirstNeat.Data;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DBFirstNeat.BizLayer
{
    public class PayRollBL
    {
        private readonly PayRollDbContext _context;//Provide interaction with DAL
        private readonly ILogger _logger;
        public PayRollBL(PayRollDbContext context)
        {
            _context = context; // now we cam communicate with DAL
        }

        public async Task<List<Dept>> GetPayRollAsyc()
        {
            //Pre Business Logic
            var dp=await Task.Run(()=>_context.Depts.ToList());
            //Post Business
            return dp;
        }

        public async Task<Dept> GetPayRollsAsync(int? id)
        {
            //Pre Business Logic
            var dp =await Task.Run(()=> _context.Depts.SingleOrDefault(p => p.DeptNo == id));
            //Post BL
            return dp;
        }

        public async Task AddDeptAsync(Dept dept)
        {
            _context.Depts.Add(dept);
            try
            {
                await Task.Run(() => _context.SaveChanges());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw ex;
            }
        }
        public async Task RemoveDeptAsync(Dept dept)
        {
            _context.Depts.Remove(dept);
            try
            {
                await Task.Run(() => _context.SaveChanges());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task UpdateDeptAsync(Dept dept)
        {
            _context.Depts.Update(dept);
            try
            {
                await Task.Run(() => _context.SaveChanges());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
