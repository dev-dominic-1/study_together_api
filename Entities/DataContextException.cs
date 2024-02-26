using System;

namespace study_together_api.Entities
{
    public class DataContextException
    {
        public int Id { get; init; }

        public required string Message { get; set; }

        public DateTime timestamp { get; set; } = DateTime.Now;

        public static DataContextException From<T> (T Exception) where T : Exception
        {
            return new DataContextException{ Message = Exception.Message };
        }
    }
}