using System;
namespace Waldo.Entity
{
    public class User
    {
        private String _Username { get; set; }
        private String _Password{ get; set; }

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
    }
}
