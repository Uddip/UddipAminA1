using System;
using System.Collections.Generic;
using System.Text;

namespace UddipAminA1
{
    class Employee
    {
        private int _iD;
        private long _phone;
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

        public Employee(int iD, long phone, String name, String address, String email, String role)
        {
            _iD = iD;
            _phone = phone;
            _name = name;
            _address = address;
            _email = email;
            _role = role;
        }

        public int Id
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public long Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public String Name
        {
            get { return _address; }
            set { _address = value; }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public String Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public override string ToString()
        {
            return $"{_name, -15} {_role, -20} {_iD, -13} {_email, -30} {_phone, -15}";
        }
    }
}
