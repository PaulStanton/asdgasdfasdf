﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asdgasdfasdf.Models
{
    public class QuestionOrder
    {
        public int QuestionNumber { get; set; }
        public string QuestionID { get; set; }
        public int QuestionOrderID { get; set; }
        public int ExamAssessmentFK { get; set; }

        //public virtual ExamAssessment ExamAssessment { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}