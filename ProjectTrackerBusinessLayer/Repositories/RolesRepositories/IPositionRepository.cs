using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.RolesRepositories
{
    public interface IPositionRepository
    {
        abstract List<Position> AllPositions();
    }
}
