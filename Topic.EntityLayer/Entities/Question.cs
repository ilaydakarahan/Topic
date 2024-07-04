using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.EntityLayer.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
