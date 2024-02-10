using Employee_Management_App.Context;
using Employee_Management_App.Models;

namespace Employee_Management_App.UtilClasses
{
    public class FormService
    {
        private readonly EmpContext _context;

        public FormService(EmpContext context)
        {
            _context = context;
        }

        public string GenerateFormNumber(string userId)
        {
            int currentYear = DateTime.UtcNow.Year;
            string prefix = userId.Substring(0, 1);
            string currentSeries = $"{prefix}{currentYear % 100}";

            // Get the latest form number for the current series
            string latestFormNumber = _context.Forms
                .Where(f => f.FormNumber.StartsWith(currentSeries))
                .OrderByDescending(f => f.FormId)
                .Select(f => f.FormNumber)
                .FirstOrDefault();

            int sequenceNumber = 1;
            if (!string.IsNullOrEmpty(latestFormNumber))
            {
                sequenceNumber = int.Parse(latestFormNumber.Substring(3, 6)) + 1;
            }

            string newFormNumber = $"{prefix}{currentYear % 100}{sequenceNumber:D6}AA";

            // Save the new form to the database
            _context.Forms.Add(new Form { UserId = userId, FormNumber = newFormNumber });
            _context.SaveChanges();

            return newFormNumber;
        }
    }
}
