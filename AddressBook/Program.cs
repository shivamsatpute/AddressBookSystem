using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        EditContact edit = new EditContact();
        static Dictionary<String, Program> addressBookDictionary = new Dictionary<string, Program>(); 
        static void Main(string[] args) 
        {
            bool loop1 = true; 
            EditContact edit = new EditContact();
            while (loop1)  
            {
                Console.WriteLine("**** Welcome To Address Book System ****");
                Console.WriteLine("\n1.Add Address Book System\n2.Show Address Books System Names\n3.Search Person in City or State\n4.Exit "); //Print menu

                Console.Write("Enter Your Choice:- "); 
                int choice1 = Convert.ToInt32(Console.ReadLine()); 

                while (choice1 > 4)
                {
                    Console.WriteLine("Plz Enter Valid Option");  
                    Console.Write("Enter Your Choice:-");  
                    choice1 = Convert.ToInt32(Console.ReadLine()); 
                }

                //UC7
                Program addressBook = new Program(); 
                string addressBookName = null;
                switch (choice1)  
                {
                    case 1:

                        Console.Write("Enter Address Book System Name:- ");

                        addressBookName = Console.ReadLine();  

                        bool isKeyAvailable = false; 

                        foreach (System.Collections.Generic.KeyValuePair<string, Program> keyValue in addressBookDictionary)
                        { 
                            if (keyValue.Key.Equals(addressBookName)) 
                            {
                                isKeyAvailable = true;
                            }
                        }
                        if (isKeyAvailable) 
                        {
                            Console.WriteLine($"Address Book System {addressBookName} is Already Exist\n Please Enter New Address Book Name:-");
                            addressBookName = Console.ReadLine();//Take input user

                        }
                        bool loop2 = true;
                        Console.WriteLine("**** Welcome To Address Book System ****");
                        int i = 0;
                        // Edit edit = new Edit(); //Create object Edit class
                        while (loop2)
                        {
                            Console.WriteLine("\n1. Add New Person      ");
                            Console.WriteLine("2. Display Records     ");
                            Console.WriteLine("3. Edit Records        ");
                            Console.WriteLine("4. Delete Records      ");
                            Console.WriteLine("5. Exit		        \n");
                            Console.Write("Enter Your Choice:- ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    edit.AddRecord(); 
                                    break;
                                case 2:
                                    edit.DisplayRecord();  
                                    break;
                                case 3:
                                    Console.Write("Enter First Name To Edit Records:- ");
                                    String firstName = Console.ReadLine();
                                    edit.EditRecord(firstName); 
                                    break;
                                case 4:
                                    Console.Write("Enter First Name To Delete Records:- ");
                                    String Name = Console.ReadLine();
                                    edit.DeleteRecord(Name);
                                    break;
                                case 5:
                                    loop2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter Valid Option");
                                    break;
                            }
                        }
                        addressBookDictionary.Add(addressBookName, addressBook);
                        break;
                    case 2:
                        Console.WriteLine(" Available Address Books System ");

                        foreach (KeyValuePair<String, Program> keyValue in addressBookDictionary) 
                        {
                            Console.WriteLine("Address Book System Name:-  " + keyValue.Key);
                        }
                        break;
                    case 3:
                        Console.Write("Enter City Name To Search Records:- ");
                        String city = Console.ReadLine();
                        edit.SearchRecordCityOrState();
                        break;

                    default:
                        loop1 = false;
                        break;
                }

            }
        }

    }
}

