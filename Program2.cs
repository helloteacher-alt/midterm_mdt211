using System;
using System.Collections.Generic;

namespace midterm_Quiz2 //63120501029
{
    enum Menu // สร้าง enum Menu เพื่อที่จะ casting กับค่าที่ผู้ใช้กรอกเลือกเมนูได้
    {
        Login=1,
        Register
    }
    enum ListBook // สร้าง enum ListBook เพื่อที่จะ casting กับค่าที่ผู้ใช้กรอกเลือกเมนูได้
    {
        ListBook=1
    }

    class Program
    {
        static PersonList personList; // รอเก็บ list person ที่จะทำการ Register

        static void Main(string[] args)
        {
            WaitingForPersonList();
            ShowScreen();
        }

        static void WaitingForPersonList() //สร้างไว้รอเก็บข้อมูล
        {
            Program.personList = new PersonList();
        }

        static void ShowScreen() // สร้างฟังก์ชันแสดงหน้าจอที่มีรายละเอียดเริ่มต้น
        {
            Console.Clear();
            ShowWelcomeText();
            ShowMenuScreen();
        }

        static void ShowWelcomeText() // แสดงข้อความ Welcome
        {
            Console.WriteLine("Welcome to Digital Library"); 
            Console.WriteLine("--------------------------");
        }

        static void ShowMenuScreen() // แสดงเมนู
        {
            
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register ");
            InputMenuFromKeyboard(); // เรียกใช้ฟังก์ชัน InputMenuFromKeyboard();
        }

        static void InputMenuFromKeyboard() // รับค่าว่าผู้ใช้งานเลือกเมนูอะไร
        {
            Console.Write("Select Menu:");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            ShowMenu(menu); // เรียกใช้ฟังก์ชัน ShowMenu
        }

        static void ShowMenu(Menu menu) // โยนค่าเข้ากับ enum Menu
        {
            if (menu == Menu.Login)
            {
                ShowLoginScreen(); // เรียกใช้ฟังก์ชัน ShowLoginScreen(); เมื่อผู้ใช้เลือก 1
            }
            else if (menu == Menu.Register)
            {
                ShowRegisterScreen(); // เรียกใช้ฟังก์ชัน ShowRegisterDcreen(); เมื่อผู้ใช้เลือก 2
            }
            else ShowErrorText(); // เรียกใช้ฟังก์ชัน ShowErrorText(); เมื่อผู้ใช้กรอกเมนูนอกเหนือจาก 1 และ 2
        }

        static void ShowErrorText() // แสดงข้อความหากผู้ใช้กรอกเมนูผิด
        {
            Console.WriteLine("You entered wrong menu. Please try again.");
            InputMenuFromKeyboard(); // เรียกใช้ฟังก์ชันกลับไปให้ผู้ใช้ได้กรอกเลือกเมนูใหม่อีกครั้ง
        }

        static void ShowLoginScreen() // แสดงผลหน้าจอ Log in
        {
            Console.Clear();
            ShowHeaderLoginPersonScreen();
            InputInformation();
        }

        static void ShowRegisterScreen() // แสดงผลหน้าจอ Register
        {
            Console.Clear();
            ShowHeaderRegisterPersonScreen();
        }
        
        static void ShowHeaderLoginPersonScreen() // แสดงหัวข้อความของหน้า Log in 
        {
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------");
        }

        static void InputInformation() // ให้กรอกข้อมูลเพื่อ Log in 
        {
            Console.Write("Input name:");
            string name = Console.ReadLine();
            //Console.Write(PersonList.Contains(name));
            Console.Write("Input password: ");
            string password = Console.ReadLine();
            Console.Write("1=student / 2=employee: ");
            string studentoremployee = Console.ReadLine();
            if (studentoremployee == "1")
            {
                ShowStudentScreen();
            }else if (studentoremployee == "2")
            {
                ShowEmployeeScreen();
            }
        }

        static void ShowStudentScreen() // หน้าจอ Log in หากผู้ใช้เป็น Student
        {
            Console.Clear();
            ShowStudentHeaderText();
            GetListBookMenu();
        }

        static void ShowEmployeeScreen() // หน้าจอ Log in หากผู้ใช่เป็น Employee
        {
            Console.Clear();
            ShowEmployeeHeaderText();
            GetListBookMenu();
        }

        static void GetListBookMenu() // แสดงเมนูดูรายชื่อหนังสือ
        {
            Console.WriteLine("1. Get List Books");
            Console.Write("Input Menu: ");
            ListBook listbook = (ListBook)(int.Parse(Console.ReadLine()));
            ShowListBookMenu(listbook);
        }

        static void ShowListBookMenu(ListBook listbook) // โยนค่าเข้ากับ enum Listbook
        {
            if (listbook == ListBook.ListBook)
            {
                ShowListBookScreen();
            }
        }

        static void ShowListBookScreen() //แสดงรายการหนังสือ
        {
            Console.Clear();
            Console.WriteLine("Book List");
            Console.WriteLine("---------");
            Console.WriteLine("Book ID: 1");
            Console.WriteLine("Book name: NOW I UNDERSTAND");
            Console.WriteLine("Book ID: 2");
            Console.WriteLine("Book name:  REVOLUTIONARY WEALTH");
            Console.WriteLine("Book ID: 3");
            Console.WriteLine("Book name: Six Degrees");
            Console.WriteLine("Book ID: 4");
            Console.WriteLine("Book name: Les Vacances");
            ShowInputBookIDScreen();
        }


        static void ShowInputBookIDScreen() // กรอกหนังสือที่จะยืม
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Input book ID: ");
                string bookID = Console.ReadLine();
                if (bookID == "1")
                {
                    Console.WriteLine("Book name: NOW I UNDERSTAND");
                }
                else if (bookID == "2")
                {
                    Console.WriteLine("Book name: REVOLUTIONARY WEALTH");
                }
                else if (bookID == "3")
                {
                    Console.WriteLine("Book name: Six Degrees");
                }
                else if (bookID == "4")
                {
                    Console.WriteLine("Book name: Les Vacances");
                }
                else if (bookID == "exit")
                {
                    ShowAllInformation();
                }
            }
        }

        static void ShowAllInformation() // แสดงผลทั้งหมด
        {
            Console.Clear();
            Console.WriteLine("Book List");
            Console.WriteLine("Book name:");
        }

        static void ShowStudentHeaderText() // แสดงหัวข้อหลักของข้อความหน้า Student
        {
            Console.WriteLine("Student Management");
            Console.WriteLine("-------------------");
        }

        static void ShowEmployeeHeaderText() // แสดงหัวข้อหลักของข้อความหน้า Employee
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine("-------------------");
        }


        static void ShowHeaderRegisterPersonScreen() // แสดงหัวข้อหลักของข้อความหน้า Register
        {
            Console.WriteLine("Register new Person");
            Console.WriteLine("-------------------");
            InputRegisterNewPeron();
            ShowScreen();
        }

        static Person InputRegisterNewPeron() //  เก็บค่าการ Register
        {
            return new Student(InputName(), InputPassword(),InputStudentOrEmployee());
        }

        static string InputName() // กรอกชื่อ
        {
            Console.Write("Input Name:");
            return Console.ReadLine();
        }

        static string InputPassword() // กรอกรหัสผ่าน
        {
            Console.Write("Input Password:");
            return Console.ReadLine();
        }

        static string InputStudentOrEmployee() // ตรวจสอบว่าเป็น Student or Employee
        {
            Console.Write("Input User Type (1 = student , 2 = Employee) :");
            int studentOremployee = int.Parse(Console.ReadLine());

            if (studentOremployee == 1)
            {
                Console.Write("Student ID:");
                string studentID = Console.ReadLine();
                return Console.ReadLine();
            }
            else if (studentOremployee == 2)
            {
                Console.Write("Employee ID:");
                string employeeID = Console.ReadLine();
                return Console.ReadLine();
            }
            return "1";
            
        }
    }

    class Person // สร้าง class person
    {
        protected string name;
        protected string password;
        public Person(string name,string password) // สร้าง constructor ของ Person
        {
            this.name = name;
            this.password = password;
        }
        public string GetName() // return ชื่อ
        {
            return this.name;
        }
        public string GetPassword() // return รหัสผ่าน
        {
            return this.password;
        }
    }
    class Student : Person // สร้าง class Student ที่มีคุณสมับติเชื่อมกับ class Person
    {
        private string studentID;
        public Student(string name,string password,string studentID) :base(name,password) // สร้าง constructor ของ Student โดยสืบทอดค่า name,password จาก Person
        {
            this.studentID = studentID; // อ้างอิง instance ทีของ Student ที่นอกเหนือจาก Person
        }
    }
    class Employee : Person // สร้าง class Employee ที่มีคุณสมบัติเชื่อมกับ class Person
    {
        private string employeeID;
        public Employee(string name,string password,string employeeID) : base(name, password) // สร้าง constructor ของ Employee โดยสืบทอดค่า name,password จาก Person
        {
            this.employeeID = employeeID; // อ้างอิง instance ทีของ Employee ที่นอกเหนือจาก Person
        }
    }

    class PersonList // สร้าง class เก็บ list ของ person
    {
        private List<Person> personList;
        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddPerson(Person person) // เพิ่มประวัติคนเข้าไปในลิสต์
        {
            this.personList.Add(person);
        }

        public void CheckPersonList() //ตรวจสอบว่ามีรายชื่อ Register เรียบร้อยแล้วหรือเปล่า
        {
            foreach(Person person in this.personList)
            {
                if(person is Student)
                {
                    Console.WriteLine("Name: {0}",person.GetName());
                }else if(person is Employee)
                {
                    Console.WriteLine("Name:{0}",person.GetName());
                }
            }
        }
    }
}
