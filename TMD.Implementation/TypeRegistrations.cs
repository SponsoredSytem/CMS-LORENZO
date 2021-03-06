﻿using TMD.Implementation.Identity;
using TMD.Implementation.Services;
using TMD.Interfaces.IServices;
using TMD.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace TMD.Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IAspNetUserService, AspNetUserService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            unityContainer.RegisterType<IStagingEbayLoadService, EbayStagingLoadService>();
            unityContainer.RegisterType<IStagingEbayBatchImportsService, StagingEbayBatchImportsService>();
            unityContainer.RegisterType<IProductCategoryService, ProductCategoryService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<IVendorService, VendorService>();
            unityContainer.RegisterType<IInventoryItemService, InventoryItemService>();
            unityContainer.RegisterType<IOrdersService, OrdersService>();
            unityContainer.RegisterType<IOrderItemService, OrderItemsService>();
            unityContainer.RegisterType<IProductConfigurationService, ProductConfigurationService>();
            unityContainer.RegisterType<ICustomerService, CustomerService>();
            unityContainer.RegisterType<IExpenseCategoryService, ExpenseCategoryService>();
            unityContainer.RegisterType<IExpenseService, ExpenseService>();
            unityContainer.RegisterType<IReportsService, ReportsService>();
            unityContainer.RegisterType<INotesCategoryService, NotesCategoryService>();
            unityContainer.RegisterType<INoteService, NoteService>();
            unityContainer.RegisterType<ICompanyService, CompanyService>();
            unityContainer.RegisterType<ICityService, CityService>();
            unityContainer.RegisterType<IMunicipalService, MunicipalService>();
            unityContainer.RegisterType<ISourceService, SourceService>();
            unityContainer.RegisterType<ICompanyContactService, CompanyContactService>();
            unityContainer.RegisterType<ICompanyStatusService, CompanyStatusService>();
            unityContainer.RegisterType<ICurrencyService, CurrencyService>();
            unityContainer.RegisterType<IColorService, ColorService>();
            unityContainer.RegisterType<ISizeService, SizeService>();
            unityContainer.RegisterType<IProductImageService, ProductImageService>();
            unityContainer.RegisterType<IEventService, EventService>();
            unityContainer.RegisterType<IEventStatusService, EventStatusService>();
        } 
    }
}
