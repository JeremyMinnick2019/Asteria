namespace Asteria.Models
{
    public class APOD
    {
        public string? CopyRight { get; set; }

        private string? date;

        public string Date
        {
             get
             {
                if(this.date == null)
                {
                    return "No Date Available";
                }

                return this.date;
             } 

             set
             {
                if(value == null)
                {
                    this.date = "No Date Available";
                    return;
                }
                    
                this.date = DateTime.Parse(value).ToString("MM/dd/yyyy");
             }
        }
        public string? Explanation { get; set; }
        public byte[]? Hdurl { get; set; }
        public string? MediaType { get; set; }
        public string? Title { get; set; }
    }
}
