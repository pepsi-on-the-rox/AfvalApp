using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelViewIssue
    {
        public int? SelectedOperatorId { get; set; }
        public int? SelectedLabelId { get; set; }
        public List<Operator>? Operators { get; set; }
        public List<Label>? Labels { get; set; }

        public Issue? Issue { get; set; }


    }
}
