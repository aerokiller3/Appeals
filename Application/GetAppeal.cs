using System;
using System.Linq;
using Database;
using Domain.Enums;

namespace Application
{
    public class GetAppeal
    {
        private readonly ApplicationDbContext _ctx;

        public GetAppeal(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public AppealViewModel Do(int id) =>
            _ctx.Appeals.Where(x => x.Id == id)
                .Select(x => new AppealViewModel
                {
                    Id = x.Id,
                    Country = x.Country.Id,
                    Region = x.Region,
                    City = x.City,
                    Phone = x.Phone,
                    Reason = x.Reason,
                    Department = x.Department,
                    Time = x.Time
                })
                .FirstOrDefault();

        public class AppealViewModel
        {
            public int Id { get; set; }
            public int  Country { get; set; }
            public string Region { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Reason { get; set; }
            public Departments Department { get; set; }
            public DateTime Time { get; set; }
        }
    }
}
