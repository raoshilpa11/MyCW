using System.Collections.Generic;
using System.Linq;

namespace CompanyAPI.DataAccessLayer
{
    public static class CompanyDetails
    {
        public static IEnumerable<Company> GetAllDuplicateRecords(CompanyEntities db)
        {
            string duplicateCompanyRecords = "SELECT y.CompanyId, y.CompanyName, y.LastName,y.Email,y.Phone FROM Company y INNER JOIN(SELECT CompanyName, COUNT(*) AS CountOf FROM Company GROUP BY CompanyName HAVING COUNT(*)> 1 ) dt ON y.Companyname = dt.Companyname order by dt.CompanyName desc";

            var result = db.Companies.SqlQuery(duplicateCompanyRecords).ToList();

            return result;
        }
    }
}