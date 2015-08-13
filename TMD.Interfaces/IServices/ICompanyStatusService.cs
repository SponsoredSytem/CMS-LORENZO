﻿using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ICompanyStatusService
    {
        IEnumerable<CompanyStatus> GetCompanyStatusesBySortOrder();
    }
}
