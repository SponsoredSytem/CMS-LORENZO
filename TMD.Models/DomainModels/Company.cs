﻿using System;
using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LegalName { get; set; }
        public string VATNumber { get; set; }
        public string VATOffice { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string CompanyDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public Nullable<long> MunicipalId { get; set; }
        public Nullable<long> SourceId { get; set; }

        public virtual Municipal Municipal { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<CompanyContact> CompanyContacts { get; set; }
    }
}