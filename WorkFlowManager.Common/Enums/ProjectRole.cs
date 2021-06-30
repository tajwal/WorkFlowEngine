﻿using System.ComponentModel.DataAnnotations;

namespace WorkFlowManager.Common.Enums
{
    public enum ProjectRole
    {
        [Display(Name = "Admin")]
        Admin = 10,

        [Display(Name = "Monitor")]
        Monitor = 70,

        [Display(Name = "Officer")]
        Officer = 80,

        [Display(Name = "Unit Purchasing Officer")]
        UnitPurchasingOfficer = 90,

        [Display(Name = "Spending Officer")]
        SpendingOfficer = 100,

        [Display(Name = "Purchasing Officer")]
        PurchasingOfficer = 110,

        [Display(Name = "Budget Coordinator")]
        BudgetCoordinator = 120,

        [Display(Name = "Country Director")]
        CountryDirector = 130,

        [Display(Name = "Line Manager")]
        LineManager = 140,

        [Display(Name = "Sub Director")]
        SubDirector = 150,

        [Display(Name = "TC Director/Mastofy")]
        Director = 160,

        [Display(Name = "System")]
        System = 1000
    }
}
