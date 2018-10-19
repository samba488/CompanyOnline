using CompanyOnline.API.Models.Repository;
using log4net;
using System.Collections.Generic;  
using System.Linq;
using System.Reflection;

namespace CompanyOnline.API.Models.DataManager
{
    public class CompanyManager : IDataRepository<Company, long>
    {
        ApplicationContext ctx;
        private ILog _logger;
        public CompanyManager(ApplicationContext c)
        {
            ctx = c;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public Company Get(long id)
        {
            dynamic company = null;
            try
            {
                 company = ctx.Companies.FirstOrDefault(b => b.Id == id);
               
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);
               
            }
            return company;

        }

        public IEnumerable<Company> GetAll()
        {
            dynamic companies = null;
                try
            {
               companies = ctx.Companies.ToList();
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);

            }
            return companies;
        }

        public long Add(Company company)
        {
            ctx.Companies.Add(company);
            long companyId = ctx.SaveChanges();
            return companyId;
        }

        public long Update(long id, Company item)
        {
            long companyId = 0;
            try
            {
                var company = ctx.Companies.Find(id);
                if (company != null)
                {
                    company.Code = item.Code;
                    company.Name = item.Name;
                    company.Address = item.Address;
                    company.Phone_Number = item.Phone_Number;

                    companyId = ctx.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);

            }
            return companyId;
        }

        public long Delete(long id)
        {
            int companyId = 0;
            try
            {
                var company = ctx.Companies.FirstOrDefault(b => b.Id == id);
                if (company != null)
                {
                    ctx.Companies.Remove(company);
                    companyId = ctx.SaveChanges();
                }

            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);

            }
            return companyId;
        }
    }
}