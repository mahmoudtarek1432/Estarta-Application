using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IssueDate : IValueObject
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public IssueDate SetYear(int year)
        {
            if(year < 1900 || year > DateTime.Now.Year)
                 throw new BusinessLogicException("Year is not valid");
            
            Year = year;
            return this;
        }
        public IssueDate SetMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new BusinessLogicException("Month is not valid");

            Month = month;
            return this;
        }
        public IssueDate(int year, int month)
        {
            SetYear(year);
            SetMonth(month);
        }

        public IssueDate() { }
    }
}
