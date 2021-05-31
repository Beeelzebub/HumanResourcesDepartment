using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class TimeSheet : Action
    {
        private static string[] MonthName = 
            { 
                "январь", "февраль", "март", "апрель", 
                "май", "июнь", "июль", "август",
                "сентрябрь", "октябрь", "ноябрь", "декабрь" 
            };
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public int NumberOfWorkingDays { get; set; }
        public int NumberOfWorkingHours { get; set; }
        public int NumberOfDaysOff { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string InternalAttendanceMarks { get; set; }

        [NotMapped]
        public List<Vacation> Vacations { get; set; }

        [NotMapped]
        public List<BusinessTrip> BusinessTrips { get; set; }

        [NotMapped]
        public List<SickLeave> SickLeaves { get; set; }

        [NotMapped]
        public string[] AttendanceMarks
        {
            get
            {
                if (SplitedAttendanceMarks != null)
                    return SplitedAttendanceMarks;
                SplitedAttendanceMarks = this.InternalAttendanceMarks.Split(';');

                return SplitedAttendanceMarks;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                    if (Int32.TryParse(value[i], out int temp))
                        if (temp < 0)
                            value[i] = "0";
                        else if (temp > 24)
                            value[i] = "24";

                this.InternalAttendanceMarks = String.Join(";", value);
            }
        }

        private string[] SplitedAttendanceMarks;

        public void CalculateAmount()
        {
            for (int i = 0; i < AttendanceMarks.Length; i++)
            {
                if (AttendanceMarks[i] == "ОТ" || AttendanceMarks[i] == "К" || AttendanceMarks[i] == "Б")
                    NumberOfDaysOff++;
                else if (AttendanceMarks[i] == "")
                {
                    NumberOfDaysOff++;
                    AttendanceMarks[i] = "0";
                }
                else
                {
                    NumberOfWorkingDays++;
                    NumberOfWorkingHours += Int32.Parse(AttendanceMarks[i]);
                }
            }
        }

        public void SetGaps()
        {
            foreach (var item in Vacations)
                SetMarksToAttendanceMarks(item.VacationStartDate, item.VacationEndDate, "ОТ");

            foreach (var item in BusinessTrips)
                SetMarksToAttendanceMarks(item.TripStartDate, item.TripEndDate, "К");

            foreach (var item in SickLeaves)
                SetMarksToAttendanceMarks(item.SickLeaveStartDate, item.SickLeaveEndDate, "Б");
        }

        private void SetMarksToAttendanceMarks(DateTime startDate, DateTime endDate, string mark)
        {
            DateTime lastDayOfMonth = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            var attendanceMarks = AttendanceMarks;

            while ((startDate <= endDate) && (startDate <= lastDayOfMonth))
            {
                if (startDate.Month == Month)
                    attendanceMarks[startDate.Day - 1] = mark;

                startDate = startDate.AddDays(1);
            }

            AttendanceMarks = attendanceMarks;
        }

        public string GetDateString() => MonthName[Month - 1] + " " + Year;
        public override string GetActionName() => "Изменение табеля рабочего времени";
        public override string GetDescription() => 
            "Период: " + GetDateString();

        public TimeSheet()
        {
            Vacations = new List<Vacation>();
            BusinessTrips = new List<BusinessTrip>();
            SickLeaves = new List<SickLeave>();
        }
    }
}
