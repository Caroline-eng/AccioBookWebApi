﻿namespace AccioBook.Domain.Entities
{
    public class GenreSearch
    {
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public Int64 Id_Genre { get; set; }
        public Genre Genre { get; set; }

    }
}
