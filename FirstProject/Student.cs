using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject {
    class Student {

        public string Name { get; set; }

        public string Email { get; set; }

        public Student(string name, string email) {
            this.Name = name;
            this.Email = email;
        }

        public override string ToString() {
            return Name + ", " + Email;
        }
    }
}
