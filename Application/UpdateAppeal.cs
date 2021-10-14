using System;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Domain.Enums;
using Domain.Models;

namespace Application
{
    public class UpdateAppeal
    {
        private readonly ApplicationDbContext _ctx;

        public UpdateAppeal(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var appeal = _ctx.Appeals.FirstOrDefault(x => x.Id == request.Id);

            appeal.Country = _ctx.Countries.FirstOrDefault(x => x.Id == request.Country);
            appeal.Region = request.Region;
            appeal.City = request.City;
            appeal.Phone = request.Phone;
            appeal.Reason = request.Reason;
            appeal.Department = (Departments) request.Department;

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
            public int Id { get; set; }
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
