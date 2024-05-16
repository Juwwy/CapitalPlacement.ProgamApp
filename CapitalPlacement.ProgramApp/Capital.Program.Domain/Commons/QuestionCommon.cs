using Capital.Program.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Program.Domain.Commons
{
    public class QuestionCommon
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string QuestionTypeId { get; set; }
        public string? EmployerProgramId { get; set; }
        public EmployerProgram? EmployerProgram { get; set; }
    }
}
