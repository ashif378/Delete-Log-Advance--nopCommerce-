using System;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Services
{
    public interface IDeleteLogAdvancedService
    {
        void DeleteLogAdvancedRange(DateTime? startDate, DateTime? endDate);
    }
}