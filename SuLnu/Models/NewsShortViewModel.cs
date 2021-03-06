﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuLnu.BLL.DTO;

namespace SuLnu.Models
{
    public class NewsShortViewModel
    {
        public string Tilte { get; set; }
        public int FacultyId { get; set; }
        public int NumberOflikes { get; set; }
        public string FacultyName { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhotoFilePath { get; set; }
    }
}