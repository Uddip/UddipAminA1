using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Payroll
    {
        private long _iD;
        private int _employeeID;
        private double _hoursWorked;
        private double _rate;
        private String _date;

        public Payroll()
        {
            _iD = 0;
            _hoursWorked = 0;
            _rate = 0;
            _employeeID = 0;
            _date = "";
        }

        public Payroll(long iD, double hoursWorked, double rate, int employeeID, String date)
        {
            _iD = iD;
            _hoursWorked = hoursWorked;
            _rate = rate;
            _employeeID = employeeID;
            _date = date;
        }

        public long Id
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public double HoursWorked
        {
            get { return _hoursWorked; }
            set { _hoursWorked = value; }
        }

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
