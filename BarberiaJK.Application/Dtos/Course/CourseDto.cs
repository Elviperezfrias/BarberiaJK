using BarberiaJK.Application.Dtos;

namespace BarberiaJK.Application.Dtos.Course
{
    public class CourseDto : DtoBase
    {
        public string Title { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}
