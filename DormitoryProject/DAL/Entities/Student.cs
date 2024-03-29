﻿using System;
using System.Collections.Generic;

namespace DormitoryProject.DAL.Entities
{
    public partial class Student
    {
        public Student()
        {
            Applications = new HashSet<Application>();
           
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public virtual ICollection<Application> Applications { get; set; }
       
    }
}
