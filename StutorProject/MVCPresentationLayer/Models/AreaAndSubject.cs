using StutorDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class AreaAndSubject
    {
        public IList<SubjectArea> SubjectAreas { get; set; }

        public IList<Subject> Subjects { get; set; }

    }
}