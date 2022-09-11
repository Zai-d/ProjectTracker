using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.RolesRepositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public PositionRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<Position> AllPositions()
        {
            return applicationDbContext.Positions.ToList();
        }


    }
}
