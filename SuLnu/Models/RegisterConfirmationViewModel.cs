using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuLnu.Models
{
    public class RegisterConfirmationViewModel
    {
        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }
    }
}
