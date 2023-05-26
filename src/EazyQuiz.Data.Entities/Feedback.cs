using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyQuiz.Data.Entities;
public class Feedback
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Text { get; set; } = string.Empty;

    public User? User { get; set; }

}
