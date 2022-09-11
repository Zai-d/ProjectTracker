using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IStatusesRepository
    {
        public List<Status> AllStatuses();
        public List<Status> Statuses();
    }
}
