using System;
using System.Linq;
using Nop.Core.Data;
using Nop.Core.Domain.Logging;
using Nop.Services.Helpers;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Services
{
    public class DeleteLogAdvancedService : IDeleteLogAdvancedService
    {
        #region fields

        private readonly IRepository<Log> _logRepository;
        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion fields

        #region ctor

        public DeleteLogAdvancedService(IRepository<Log> logRepository,
            IDateTimeHelper dateTimeHelper)
        {
            _logRepository = logRepository;
            _dateTimeHelper = dateTimeHelper;
        }

        #endregion ctor

        #region methods

        public void DeleteLogAdvancedRange(DateTime? startDate, DateTime? endDate)
        {
            var startDateUtc = startDate.HasValue
               ? (DateTime?)_dateTimeHelper.ConvertToUtcTime(startDate.Value, _dateTimeHelper.CurrentTimeZone) : null;
            var endDateUtc = endDate.HasValue
               ? (DateTime?)_dateTimeHelper.ConvertToUtcTime(endDate.Value, _dateTimeHelper.CurrentTimeZone).AddDays(1) : null;

            var query = _logRepository.Table;

            if (query == null)
                throw new NullReferenceException(nameof(query));

            if (startDateUtc.HasValue)
                query = query.Where(l => startDateUtc.Value <= l.CreatedOnUtc);
            if (endDateUtc.HasValue)
                query = query.Where(l => endDateUtc.Value >= l.CreatedOnUtc);

            _logRepository.Delete(query);
        }

        #endregion methods
    }
}