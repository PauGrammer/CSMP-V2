using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CSMP_V2.Models.Domain;

namespace CSMP_V2.ViewModels
{
    public class HomeViewModel
    {
        public List<SNC> SNCList { get; set; }
        public List<Area> AreaList { get; set; }
    }
}