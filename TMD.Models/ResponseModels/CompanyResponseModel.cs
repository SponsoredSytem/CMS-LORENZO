﻿using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class CompanyResponseModel
    {
        public Company Company{get; set; }
        public IEnumerable<City> Cities{ get; set; }
        public IEnumerable<Municipal> Municipals { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public IEnumerable<CompanyContact> CompanyContacts { get; set; }
        public IEnumerable<AspNetUser> Employees { get; set; }
        public IEnumerable<CompanyStatus> CompanyStatuses { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Company> CompaniesAndIndividuals { get; set; }
        public IEnumerable<Note> CompanyNotes { get; set; }
        public IEnumerable<NotesCategory> NotesCategories { get; set; }
    }
}
