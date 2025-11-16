using BarberiaJK.Application.Dtos;
// COURSE DTO HACER REFERENCIA A BTOBASE

namespace BarberiaJK.Application.Dtos.Course
{
    public class CourseDto : DtoBase
    {
        public string Title { get; set; } = string.Empty;



        public int Duration { get; set; }
    }
}
