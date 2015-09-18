using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.PostModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISourceRepository sourceRepository;
        private readonly ICompanyContactRepository companyContactRepository;
        private readonly IAspNetUserRepository aspNetUserRepository;
        private readonly ICompanyStatusRepository companyStatusRepository;
        private readonly INotesCategoryRepository notesCategoryRepository;
        private readonly INoteRepository noteRepository;

        public CompanyService(ICompanyRepository companyRepository,ICityRepository cityRepository,ISourceRepository sourceRepository,ICompanyContactRepository companyContactRepository, IAspNetUserRepository aspNetUserRepository, ICompanyStatusRepository companyStatusRepository, INotesCategoryRepository notesCategoryRepository, INoteRepository noteRepository)
        {
            this.companyRepository = companyRepository;
            this.cityRepository = cityRepository;
            this.sourceRepository = sourceRepository;
            this.companyContactRepository = companyContactRepository;
            this.aspNetUserRepository = aspNetUserRepository;
            this.companyStatusRepository = companyStatusRepository;
            this.notesCategoryRepository = notesCategoryRepository;
            this.noteRepository = noteRepository;
        }

        public Company GetCompany(long companyId)
        {
            return companyRepository.Find(companyId);
        }

        public CompanyResponseModel GetCompanyResponse(long? companyId)
        {
            CompanyResponseModel responseModel=new CompanyResponseModel();

            //Load Company Data
            if (companyId != null)
            {
                responseModel.Company = companyRepository.Find((long)companyId);
                //Load Contacts
                responseModel.CompanyContacts = companyContactRepository.GetCompanyContactsByCompanyId((long)companyId).ToList();
                //Notes
                responseModel.CompanyNotes = noteRepository.GetNotesByCompanyId((long)companyId).ToList();
            }
                
            //Load Cities
            responseModel.Cities = cityRepository.GetAll().ToList();
            //Load Sources
            responseModel.Sources = sourceRepository.GetAll().ToList();

            //Load Employees
            responseModel.Employees = aspNetUserRepository.GetAllUsersOfEmployeeRole().ToList();

            //Load Company Statuses
            responseModel.CompanyStatuses = companyStatusRepository.GetCompanyStatusesBySortOrder().ToList();

            //Load Companies And Individuals
            responseModel.CompaniesAndIndividuals = companyRepository.GetAll().ToList();

            //Load Companies
            responseModel.Companies = companyRepository.GetCompanies().ToList();

            //Notes Categories
            responseModel.NotesCategories = notesCategoryRepository.GetAll().ToList();

            return responseModel;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return companyRepository.GetAll();
        }

        public IEnumerable<Company> GetOnlyCompanies()
        {
            return companyRepository.GetCompanies();
        }

        public long SaveCompany(CompanyPostModal companyPostModal)
        {
            if (companyPostModal.Company.CompanyId > 0)
                companyRepository.Update(companyPostModal.Company);
            else
                companyRepository.Add(companyPostModal.Company);

            companyRepository.SaveChanges();

            if (companyPostModal.Company.IsCompany)
            {
                UpdateCompanyContacts(companyPostModal);
                UpdateCompanyNotes(companyPostModal);
            }
            
            return companyPostModal.Company.CompanyId;
        }

        private void UpdateCompanyContacts(CompanyPostModal companyPostModal)
        {
            var isAnyChangeInContacts = false;

            //update contacs
            if (companyPostModal.CompanyContacts != null)
            {
                foreach (var companyContact in companyPostModal.CompanyContacts)
                {
                    companyContact.CompanyId = companyPostModal.Company.CompanyId;
                    companyContactRepository.Update(companyContact);
                    isAnyChangeInContacts = true;
                }
            }

            //delete contacts
            if (!string.IsNullOrEmpty(companyPostModal.ContactsToBeDeleted))
            {
                var stringListOfIds = companyPostModal.ContactsToBeDeleted.Split(',');
                var longListOfIds = stringListOfIds.Select(Int64.Parse).ToList();
                companyContactRepository.DeleteAllContactsById(longListOfIds);
                isAnyChangeInContacts = true;
            }
            if (isAnyChangeInContacts)
                companyContactRepository.SaveChanges();
        }

        private void UpdateCompanyNotes(CompanyPostModal companyPostModal)
        {
            var isAnyChangeInNotes = false;

            //update Notes
            if (companyPostModal.CompanyNotes != null)
            {
                foreach (var companyNote in companyPostModal.CompanyNotes)
                {
                    companyNote.CompanyId = companyPostModal.Company.CompanyId;
                    noteRepository.Update(companyNote);
                    isAnyChangeInNotes = true;
                }
            }

            //delete Notes
            if (!string.IsNullOrEmpty(companyPostModal.NotesToBeDeleted))
            {
                var stringListOfIds = companyPostModal.NotesToBeDeleted.Split(',');
                var longListOfIds = stringListOfIds.Select(Int64.Parse).ToList();
                noteRepository.DeleteAllNotesById(longListOfIds);
                isAnyChangeInNotes = true;
            }
            if (isAnyChangeInNotes)
                noteRepository.SaveChanges();
        }
    }
}

