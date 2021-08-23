﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StudentSubject
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public double Grade { get; set; }
        public bool IsDeleted { get; set; }


    }
}
