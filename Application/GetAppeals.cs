using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Database;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class GetAppeals
    {
        private readonly ApplicationDbContext _ctx;

        public GetAppeals(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<AppealViewModel> Do() =>
            _ctx.Appeals
                .Include(x => x.Country)
                .Select(x => new AppealViewModel
                {
                    Id = x.Id,
                    Country = x.Country.Name,
                    Region = x.Region,
                    City = x.City,
                    Phone = x.Phone,
                    Reason = x.Reason,
                    Department = x.Department.ToString(),
                    Time = x.Time.ToString(CultureInfo.InvariantCulture)
                });

        public class AppealViewModel
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string Region { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Reason { get; set; }
            public string Department { get; set; }
            public string Time { get; set; }
        }
    }
}
