using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyQuiz.Data.Entities;


public class Theme
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
}
