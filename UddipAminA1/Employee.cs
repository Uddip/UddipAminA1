using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Employee
    {
        private int _iD;
        private int _phone;
        private String _name;
        private String _address;
        private String _email;
        private String _role;

        public Employee()
        {
            _iD = 0;
            _phone = 0;
            _name = "";
            _address = "";
            _email = "";
            _role = "";
        }

        public Employee(int iD, int phone, String name, String address, String email, String role)
        {
            _iD = iD;
            _phone = phone;
            _name = name;
            _address = address;
            _email = email;
            _role = role;
        }

        public void addEmployee()
        {

        }

        public void deleteEmployee()
        {

        }

        public void updateEmployee()
        {

        }

        public void viewEmployee()
        {

        }
    }
}
