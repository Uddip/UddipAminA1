using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Vacation
    {
        private int _iD;
        private int _numDays;
        private String _employeeID;

        public Vacation()
        {
            _iD = 0;
            _numDays = 0;
            _employeeID = "";
        }

        public Vacation(int iD, int numDays, , String employeeID)
        {
            _iD = iD;
            _numDays = numDays;
            _employeeID = employeeID;
        }

        public void addVacation()
        {

        }

        public void deleteVacation()
        {

        }

        public void updateVacation()
        {

        }

        public void viewVacation()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
