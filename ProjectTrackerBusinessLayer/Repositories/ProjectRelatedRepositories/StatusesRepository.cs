using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusesRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public List<Status> AllStatuses()
        {
            return _context.Statuses.ToList();
        }
        public List<Status> Statuses()
        {
            var statuses =_context.Statuses.Where(x => x.StatusID == 1 || x.StatusID == 4 || x.StatusID == 5).ToList();
            return statuses;
        }

    }
}
