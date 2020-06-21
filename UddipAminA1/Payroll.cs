using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Payroll
    {
        private int _iD;
        private int _hoursWorked;
        private double _rate;
        private String _employeeID;
        private String _date;

        public Payroll()
        {
            _iD = 0;
            _hoursWorked = 0;
            _rate = 0;
            _employeeID = "";
            _date = "";
        }

        public Payroll(int iD, int hoursWorked, double rate, String employeeID, String date)
        {
            _iD = iD;
            _hoursWorked = hoursWorked;
            _rate = rate;
            _employeeID = employeeID;
            _date = date;
        }

        public void addPayroll()
        {

        }

        public void deletePayroll()
        {

        }

        public void updatePayroll()
        {

        }

        public void viewPayroll()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
