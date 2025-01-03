﻿using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IPhaseRepository : IReadable<Phase>, IWriteable<Phase>, IRemovable<Phase>
    {
    }
}