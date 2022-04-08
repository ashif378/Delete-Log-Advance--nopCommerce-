using System;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models;
using Nop.Services.Helpers;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Factories
{
    public class DeleteLogAdvancedModelFactory : IDeleteLogAdvancedModelFactory
    {
        #region fields

        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion fields

        #region ctor

        public DeleteLogAdvancedModelFactory(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        #endregion ctor

        #region methods

        public DeleteLogAdvancedModel PrepareDeleteLogAdvancedModel()
        {
            var model = new DeleteLogAdvancedModel();
            model.EndDateToDeleteLog = DateTime.Now.AddDays(-10);

            return model;
        }

        #endregion methods
    }
}