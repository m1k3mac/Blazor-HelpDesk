using Web_HelpDesk.Data.Models;
using Web_HelpDesk.Data.Models.NonDB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketAsync(int ticketNumber);
        Task<IEnumerable<Ticket>> GetTicketsAsync(string userEmail, List<string> userInRoles, TicketStates ticketState);        
        Task<IEnumerable<Ticket>> GetTicketsAsync(string userEmail, List<string> userInRoles, TicketStates ticketState, DateTime startDate, DateTime endDate);
        Task NewTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket, string comments);
        Task AddCommentAsync(TicketDetail ticketDetail);
        Task<IEnumerable<TicketDetail>> GetTicketDetailsAsync(int ticketId);
        Task<IEnumerable<ResponseTimes>> GetTicketResponseTimesAsync(DateTime startDate, DateTime endDate);
    }
}
