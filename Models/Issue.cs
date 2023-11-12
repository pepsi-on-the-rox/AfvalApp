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
        public float? X1 { get; set; }
        public float? X2 { get; set; }
        public float? Y1 { get; set; }
        public float? Y2 { get; set; }
        public Label? Label { get; set; }
        public Operator? Operator { get; set; }
        

        public float? normalize(float? cord)
        {
            return cord / 2345;
        } 

        public float? denormalize(float? cord)
        {
            return (cord * 2345);
        }
    }
}
