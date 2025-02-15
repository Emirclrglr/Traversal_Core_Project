﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR_API.DAL;
using SignalR_API.Hubs;

namespace SignalR_API.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(IHubContext<VisitorHub> hubContext, Context context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "GetVisitorChartList()");
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from crosstab \r\n(\r\n'Select \"VisitDate\", \"City\", \"VisitorCount\"\r\n\tFrom \"Visitors\"\r\n\tOrder By 1,2'\r\n) As ct(\"VisitDate\" date, City1 int, City2 int, City3 int, City4 int, City5 int)";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));
                        });

                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}