namespace Archive.API.ResourceParameters
{
    public class BoxesResourceParameters 
    {
        public string searchByName { get; set; }
        public string searchByCode { get; set; }

        private const int MaxPageSize = 5; 
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize: value; 
        }

        public string OrderBy { get; set; } = "";

    }
}