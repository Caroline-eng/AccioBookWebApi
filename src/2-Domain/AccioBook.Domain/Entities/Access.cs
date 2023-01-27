﻿namespace AccioBook.Domain.Entities
{
    public class Access
    {
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public DateTime DateAccess { get; set; }
        public DateTime DateOff { get; set; }
    }
}
