using Web_HelpDesk.Data.Models;
using Web_HelpDesk.Data.Models.NonDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _dbContext;      
        
        public TicketService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;            
        }

        public async Task AddCommentAsync(TicketDetail ticketDetail)
        {
            ticketDetail.DateTime = DateTime.Now;
            var result = await _dbContext.TicketDetails.AddAsync(ticketDetail);            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ticket> GetTicketAsync(int ticketNumber)
        {
            var result = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status)
                .FirstOrDefaultAsync(t => t.Id == ticketNumber); // * refer to notes (NAVPROP)
            return result;
        }

        public async Task<IEnumerable<TicketDetail>> GetTicketDetailsAsync(int ticketId)
        {
            var result = await _dbContext.TicketDetails.Where(t => t.TicketId == ticketId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ResponseTimes>> GetTicketResponseTimesAsync(DateTime startDate, DateTime endDate)
        {
            List<ResponseTimes> responeTimes = new List<ResponseTimes>();

            var ticketResults = await _dbContext.Tickets.Where(t => t.Logged >= startDate && t.Logged <= endDate).ToListAsync();
            var ticketDetailResults = await _dbContext.TicketDetails.Where(t => t.DateTime >= startDate && t.DateTime <= endDate).ToListAsync();

            foreach(var item in ticketResults)
            {
                ResponseTimes temp = new ResponseTimes();
                temp.TicketId = item.Id;
                temp.Logged = item.Logged;

                var ticketClaimed = ticketDetailResults.Where(t => t.TicketId == item.Id).FirstOrDefault();
                if(ticketClaimed != null)
                    temp.Claimed = ticketClaimed.DateTime;

                var ticketClosed = ticketDetailResults.Where(t => t.TicketId == item.Id).LastOrDefault();
                if(ticketClosed != null && ticketClosed.Comments.Contains("Ticket Closed"))
                {
                    temp.Closed = ticketClosed.DateTime;
                }

                if(ticketClaimed != null && !ticketClaimed.Comments.Contains("Placed on hold:")) // This is a hack so tickets that were placed on hold do not get counted in the response times.
                    responeTimes.Add(temp);
            }

            return responeTimes;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(string userEmail, List<string> userInRoles, TicketStates ticketState)
        {
            List<Ticket> results = new List<Ticket>();

            if (userInRoles.Contains("Administrators") || userInRoles.Contains("Support"))
            {
                switch (ticketState)
                {
                    case TicketStates.New:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.Status.TicketStatus == "New").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Open:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "Open").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.OnHold:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "On Hold").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Closed:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "Closed").OrderByDescending(i => i.Id).ToListAsync();
                        //results = await _dbContext.Tickets.Where(t => t.Status.TicketStatus == "Closed").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Incomplete:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus != "Closed").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.All:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).OrderByDescending(i => i.Id).Take(1000).ToListAsync();
                        break;

                    default: break;
                }
            }
            else
            {
                switch (ticketState)
                {
                    case TicketStates.New:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "New").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Open:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "Open").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.OnHold:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "On Hold").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Closed:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "Closed").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Incomplete:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus != "Closed").OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.All:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    default: break;
                }
            }

            return results;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(string userEmail, List<string> userInRoles, TicketStates ticketState, DateTime startDate, DateTime endDate)
        {
            List<Ticket> results = new List<Ticket>();

            if (userInRoles.Contains("Administrators") || userInRoles.Contains("Support"))
            {
                switch (ticketState)
                {
                    case TicketStates.New:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.Status.TicketStatus == "New" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Open:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "Open" && (t.Logged >= startDate && t.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.OnHold:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "On Hold" && (t.Logged >= startDate && t.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Closed:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus == "Closed" && (t.Logged >= startDate && t.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Incomplete:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Status.TicketStatus != "Closed" && (t.Logged >= startDate && t.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.All:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(t => t.Logged >= startDate && t.Logged <= endDate).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    default: break;
                }
            }
            else
            {
                switch (ticketState)
                {
                    case TicketStates.New:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "New" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Open:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "Open" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.OnHold:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "On Hold" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Closed:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus == "Closed" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.Incomplete:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && e.Status.TicketStatus != "Closed" && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    case TicketStates.All:
                        results = await _dbContext.Tickets.Include(p => p.Priority).Include(s => s.Status).Where(e => e.EmailAddress == userEmail && (e.Logged >= startDate && e.Logged <= endDate)).OrderByDescending(i => i.Id).ToListAsync();
                        break;

                    default: break;
                }
            }

            return results;
        }

        public async Task NewTicketAsync(Ticket ticket)
        {
            ticket.Logged = DateTime.Now;
            var result = await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket, string comments)
        {
            var ticketResult = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticket.Id);
            ticketResult.Assignee = ticket.Assignee;
            ticketResult.StatusId = ticket.StatusId;

            TicketDetail ticketDetail = new TicketDetail();
            ticketDetail.DateTime = DateTime.Now;
            ticketDetail.Comments = comments;
            ticketDetail.TicketId = ticket.Id;

            var ticketDetailResult = await _dbContext.TicketDetails.AddAsync(ticketDetail);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            var ticketResult = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticket.Id);
            ticketResult.Department = ticket.Department;
            ticketResult.Location = ticket.Location;
            ticketResult.Category = ticket.Category;
            await _dbContext.SaveChangesAsync();
        }
    }
}
