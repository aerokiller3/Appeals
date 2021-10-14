using System;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Domain.Enums;
using Domain.Models;

namespace Application
{
    public class CreateAppeal
    {
        private readonly ApplicationDbContext _ctx;

        public CreateAppeal(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var appeal = new Appeal
            {
                Country = _ctx.Countries.FirstOrDefault(x=>x.Id==request.Country),
                Region = request.Region,
                City = request.City,
                Department = (Departments)request.Department,
                Phone = request.Phone,
                Reason = request.Reason,
                Time = DateTime.Now
            };

            if (appeal.Country == null)
            {
                return new Response
                {
                    Id = appeal.Id,
                    Country = appeal.Country,
                    Region = appeal.Region,
                    City = appeal.City,
                    Department = appeal.Department,
                    Phone = appeal.Phone,
                    Reason = appeal.Reason,
                    Time = appeal.Time
                };
            }

            _ctx.Appeals.Add(appeal);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = appeal.Id,
                Country = appeal.Country,
                Region = appeal.Region,
                City = appeal.City,
                Department = appeal.Department,
                Phone = appeal.Phone,
                Reason = appeal.Reason,
                Time = appeal.Time
            };
        }

        public class Request
        {
            public int Country { get; set; }
            public string Region { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Reason { get; set; }
            public int Department { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public Country Country { get; set; }
            public string Region { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Reason { get; set; }
            public Departments Department { get; set; }
            public DateTime Time { get; set; }
        }
    }
}
