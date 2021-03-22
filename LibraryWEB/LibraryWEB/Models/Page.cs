using System;

namespace LibraryWEB.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string PageCode { get; set; }
        public string? TitleUa { get; set; }
        public string? TitleEng { get; set; }
        public string? ContentUa { get; set; }
        public string? ContentEng { get; set; }
        public string? ShortContentUa { get; set; }
        public string? ShortContentEng { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateEdit { get; set; }
        public string ParentCode { get; set; }
        public string? Image { get; set; }
        public string? BigImage { get; set; }
        public string DisplayType { get; set; }
        public string OrderType { get; set; }
        public string? Tag { get; set; }
    }
}
