
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tickets>>>Get(int userId)
        {
            var Tickets = await _context.Tickets
                .Where(x => x.UserId == userId)
                .Include(c =>c.Passenger)
                .Include(c =>c.FlightDepartments)
                .ToListAsync();

            return Tickets;
        }

        [HttpPost]
        public async Task<ActionResult<List<Tickets>>> Create(CreateTicketsDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newTickets = new Tickets
            {

                Description = request.Description,
                User = user,
            };

           _context.Tickets.Add(newTickets);
            await _context.SaveChangesAsync();


            return await Get(newTickets.UserId);
        }
        [HttpPost("Passenger")]
        public async Task<ActionResult<Tickets>> AddPassenger(AddPassengerDto request)
        {
            var Tickets = await _context.Tickets.FindAsync(request.TicketsId);
            if (Tickets == null)
                return NotFound();

            var newPassenger = new Passenger
            {

                Name = request.Name,
                Tickets = Tickets

            };

            _context.Passenger.Add(newPassenger);
            await _context.SaveChangesAsync();


            return Tickets;
        }

        [HttpPost("FlightDepartments")]
        public async Task<ActionResult<Tickets>> AddTicketsFlightDepartments(AddTicketsFlightDepartmentsDto request)
        {
            var Tickets = await _context.Tickets
                .Where(c => c.Id==request.TicketsId)
                .Include(c => c.FlightDepartments)
                .FirstOrDefaultAsync();

            if (Tickets == null)
                return NotFound();

            var FlightDepartments = await _context.FlightDepartments.FindAsync(request.FlightDepartmentsId);
            if (FlightDepartments == null)
                return NotFound();

           Tickets.FlightDepartments.Add(FlightDepartments);
            await _context.SaveChangesAsync();


            return Tickets;
        }
    }
}
