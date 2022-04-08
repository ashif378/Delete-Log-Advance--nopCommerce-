using System;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Models;
using Nop.Services.Helpers;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Factories
{
    public class DeleteLogByDateModelFactory : IDeleteLogByDateModelFactory
    {
        #region fields

        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion fields

        #region ctor

        public DeleteLogByDateModelFactory(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        #endregion ctor

        #region methods

        public DeleteLogByDateModel PrepareDeleteLogByDateModel()
        {
            var model = new DeleteLogByDateModel();
            model.EndDateToDeleteLog = DateTime.Now.AddDays(-10);

            return model;
        }

        #endregion methods
    }
}