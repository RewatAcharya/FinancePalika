using FinancePalika.Areas.FinanceSys.Interface;
using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.Areas.Identity.Pages.Account;
using FinancePalika.Models;
using FinancePalika.Models.financeAdmin;
using FinancePalika.Services;
using FinancePalika.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace FinancePalika.Areas.FinanceSys.Repository
{
    public class SahakariSuchiRepository : ISahakariSuchi
    {
        private readonly AppDbContext _context;
        //private readonly IUtility _utility;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string UserId = null;
        public SahakariSuchiRepository(AppDbContext context, ILogger<RegisterModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //_utility = utility;
            _logger = logger;
            UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<SahakariSuchiViewModel> GetSahakariSuchitById(int? id)
        {
            var data = await _context.SahakariSuchi.Where(x => x.Id == id)
                .Select(x => new SahakariSuchiViewModel()
                {
                    Id = x.Id,
                    DartaNo = x.DartaNo,
                    DartaMiti = x.DartaMiti,
                    Name = x.Name,
                    NameNepali = x.NameNepali,
                    FinanceType = x.FinanceType,
                    StateId = x.StateId,
                    DistrictId = x.DistrictId,
                    PanNo = x.PanNo,
                    MainTask = x.MainTask,
                    WorkArea = x.WorkArea,
                    LocalLevel = x.LocalLevel,
                    WardNo = x.WardNo,
                    ToleName = x.ToleName,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    MobileNumber = x.MobileNumber,
                    FaxNo = x.FaxNo,
                    StateName = _context.State.Where(a => a.StateId == x.StateId).Select(a => a.StateName_Nep).FirstOrDefault(),
                    DistrictName = _context.District.Where(a => a.DistrictId == x.DistrictId).Select(a => a.DistrictName_Nep).FirstOrDefault(),
                }).FirstOrDefaultAsync() ?? new SahakariSuchiViewModel();
            return data;
        }
        public async Task<List<SahakariSuchiViewModel>> GetAllSahakariSuchi()
        {
            var SahakariSuchi = await (from c in _context.SahakariSuchi
                                       select new SahakariSuchiViewModel
                                       {
                                           Id = c.Id,
                                           DartaNo = c.DartaNo,
                                           DartaMiti = c.DartaMiti,
                                           Name = c.Name,
                                           NameNepali = c.NameNepali,
                                           FinanceType = c.FinanceType,
                                           DistrictId = c.DistrictId,
                                           StateId = c.StateId,
                                           PanNo = c.PanNo,
                                           MainTask = c.MainTask,
                                           WorkArea = c.WorkArea,
                                           LocalLevel = c.LocalLevel,
                                           WardNo = c.WardNo,
                                           ToleName = c.ToleName,
                                           EmailAddress = c.EmailAddress,
                                           PhoneNumber = c.PhoneNumber,
                                           MobileNumber = c.MobileNumber,
                                           FaxNo = c.FaxNo,
                                           StateName = _context.State.Where(a => a.StateId == c.StateId).Select(a => a.StateName_Nep).FirstOrDefault(),
                                           DistrictName = _context.District.Where(a => a.DistrictId == c.DistrictId).Select(a => a.DistrictName_Nep).FirstOrDefault(),
                                       }).ToListAsync();
            return SahakariSuchi;
        }
        public async Task<ResponseModel> InsertSahakariSuchit(SahakariSuchiViewModel model)
        {
            using (var transection = _context.Database.BeginTransaction())
            {
                ResponseModel response = new ResponseModel();
                try
                {
                    if (model.Id > 0)
                    {
                        var result = await _context.SahakariSuchi.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (result != null)
                        {
                            result.DartaNo = model.DartaNo;
                            result.DartaMiti = model.DartaMiti;
                            result.Name = model.Name;
                            result.NameNepali = model.NameNepali;
                            result.FinanceType = model.FinanceType;
                            result.State = model.State;
                            result.District = model.District;
                            result.PanNo = model.PanNo;
                            result.MainTask = model.MainTask;
                            result.WorkArea = model.WorkArea;
                            result.LocalLevel = model.LocalLevel;
                            result.WardNo = model.WardNo;
                            result.ToleName = model.ToleName;
                            result.EmailAddress = model.EmailAddress;
                            result.PhoneNumber = model.PhoneNumber;
                            result.MobileNumber = model.MobileNumber;
                            result.FaxNo = model.FaxNo;

                            _context.Entry(result).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            response.Status = true;
                        }
                        else
                            return response;
                    }
                    else
                    {
                        SahakariSuchi data = new SahakariSuchi()
                        {
                            DartaNo = model.DartaNo,
                            DartaMiti = model.DartaMiti,
                            Name = model.Name,
                            NameNepali = model.NameNepali,
                            FinanceType = model.FinanceType,
                            StateId = model.StateId,
                            DistrictId = model.DistrictId,
                            PanNo = model.PanNo,
                            MainTask = model.MainTask,
                            WorkArea = model.WorkArea,
                            LocalLevel = model.LocalLevel,
                            WardNo = model.WardNo,
                            ToleName = model.ToleName,
                            EmailAddress = model.EmailAddress,
                            PhoneNumber = model.PhoneNumber,
                            MobileNumber = model.MobileNumber,
                            FaxNo = model.FaxNo,
                        };
                        await _context.SahakariSuchi.AddAsync(data);
                        await _context.SaveChangesAsync();

                        response.PrimaryId = data.Id;
                        response.Status = true;
                    }
                    await transection.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("SahakariSuchi Repo create/update Error User Id = " + UserId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transection.RollbackAsync();
                    return response;
                }
                return response;
            }
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                
                try
                {
                    var result = await _context.SahakariSuchi.FirstOrDefaultAsync(x => x.Id == id);
                    if (result != null)
                    {
                        _context.SahakariSuchi.Remove(result);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return true;
                    }
                    await transaction.RollbackAsync();
                    return false;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        //
    }
}
