using System;
namespace Waldo.Entity
{
    public class User
    {
        private String _Username { get; set; }
        private String _Password{ get; set; }
        private String _FirstName { get; set; }
        private String _LastName { get; set; }
        private String _Address { get; set; }

        public String Username
        {
            get
            {
                return _Username == null ? "" : _Username;
            }
            set
            {
                _Username = value;
            }
        }

        public String Password
        {
            get
            {
                return _Password == null ? "" : _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public String FirstName
        {
            get
            {
                return _FirstName == null ? "" : _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public String LastName
        {
            get
            {
                return _LastName == null ? "" : _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public String Address
        {
            get
            {
                return _Address == null ? "" : _Address;
            }
            set
            {
                _Address = value;
            }
        }
    }
}
