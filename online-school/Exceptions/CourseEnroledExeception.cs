using System;
using System.Collections.Generic;
using System.Text;

namespace online_school
{
    public class CourseEnroledExeception:Exception
    {
        public CourseEnroledExeception(string? message) : base(message)
        {

        }
    }
}
