namespace EazyQuiz.Models.DTO
{
    public class ThemeResponseWithFlag : ThemeResponse
    {
        public bool Enabled { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
