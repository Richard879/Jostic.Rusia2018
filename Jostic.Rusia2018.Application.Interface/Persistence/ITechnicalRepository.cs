﻿using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface ITechnicalRepository : IReadable<Technical>, IWriteable<Technical>, IRemovable<Technical>
    {
    }
}