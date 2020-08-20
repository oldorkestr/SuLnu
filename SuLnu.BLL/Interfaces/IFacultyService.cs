using SuLnu.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuLnu.BLL.Interfaces
{
    public interface IFacultyService
    {
        public IEnumerable<string> GetAllFacultiesNames();
        public int GetFacultyIdByName(string FacultyName);
    }
}
