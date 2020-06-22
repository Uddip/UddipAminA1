using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Vacation
    {
        private long _iD;
        private int _employeeID;
        private int _numDays;

        public Vacation()
        {
            _iD = 0;
            _employeeID = 0;
            _numDays = 0;
        }

        public Vacation(long iD, int employeeID, int numDays)
        {
            _iD = iD;
            _employeeID = employeeID;
            _numDays = numDays;
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

        public int NumDays
        {
            get { return _numDays; }
            set { _numDays = value; }
        }

        public override string ToString()
        {
            return $"{_iD,-15} {_employeeID,-15} {_numDays,-5}";
        }
    }
}
