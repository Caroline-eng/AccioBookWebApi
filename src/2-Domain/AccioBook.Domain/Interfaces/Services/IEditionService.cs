﻿using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IEditionService : IDatabaseService<Edition>
    {
        Task <IEnumerable<Edition>> GetLastEditionsTop100();
    }
}
