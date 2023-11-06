using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string? PicturePath {  get; set; }
        public bool State { get; set; } = false;
        public DateTime Createdate {  get; set; } = DateTime.Now;
        public DateTime? Resolveddate { get; set; }
        public int? X1 { get; set; }
        public int? X2 { get; set; }
        public int? Y1 { get; set; }
        public int? Y2 { get; set; }
        public Label? Label { get; set; }
        public Operator? Operator { get; set; }
    }
}
