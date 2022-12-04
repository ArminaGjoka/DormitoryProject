using System;
using System.Collections.Generic;

namespace DormitoryProject.DAL.Entities
{
    public partial class Room
    {
        public Room()
        {
            Announcements = new HashSet<Announcement>();
            RoomStudents = new HashSet<RoomStudent>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int Capacity { get; set; }
        public int DormitoryId { get; set; }

        public virtual Dormitory Dormitory { get; set; } = null!;
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<RoomStudent> RoomStudents { get; set; }
    }
}
