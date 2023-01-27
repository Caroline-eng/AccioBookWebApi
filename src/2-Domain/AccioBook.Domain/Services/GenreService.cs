﻿using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.Domain.Services
{
    public class GenreService : DatabaseService<Genre>, IGenreService
    {
        public GenreService(IGenreRepository repository) : base(repository)
        {

        }
    }
}
