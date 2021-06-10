using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class EditContact
    {

        public static bool PhoneNumberValidation(String phone)
        {
            String PPattern = @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"; 
            Regex Pregex = new Regex(PPattern); 
            return Pregex.IsMatch(phone);
        }
        public static bool EmailValidation(String email)
        {
            String Epattern = @"^[a-z]+([-+*.]?[0-9a-z])*@[a-z0-9]+\.(\.?[a-z]{2,}){1,2}$"; 
            Regex eregex = new Regex(Epattern); 
            return eregex.IsMatch(email);

        }


        PersonDetails person = null;

        List<PersonDetails> list = new List<PersonDetails>(); 

        String fname = null; 
        String lname, address, city, state, phone, zip, email;
        public void AddRecord()
        {
            int i = 0;
            while (i == 0) 
            {
                Console.Write("Enter First Name:- "); 
                this.fname = Console.ReadLine();        
                if (CheckExist(fname)) 
                {
                    Console.WriteLine($"Record with name { fname } Already Exist\n Please Enter New name:-");
                }
                else
                {
                    i = 1;
                }
            }
            Console.Write("Enter Last Name:- "); 
            lname = Console.ReadLine();            
            Console.Write("Enter Address:- "); 
            address = Console.ReadLine();       
            Console.Write("Enter City:- "); 
            city = Console.ReadLine();        
            Console.Write("Enter State:- "); 
            state = Console.ReadLine();        
            Console.Write("Enter Zip:- ");
            zip = Console.ReadLine();        


            Console.Write("Enter Phone Number:- "); 
            phone = Console.ReadLine();           
            while (!PhoneNumberValidation(phone))
            {
                Console.Write(phone + " is Invalid Phone Number \nPlease Enter Valid Number:- ");
                phone = Console.ReadLine();
            }

            Console.Write("Enter Email:- ");  
            email = Console.ReadLine();          

            while (!EmailValidation(email))
            {
                Console.Write(email + " is Invalid Email \nPlease Enter Valid Email:- ");
                email = Console.ReadLine();
            }

            person = new PersonDetails(fname, lname, address, city, state, phone, zip, email);
            list.Add(person);   
        }
        public void DisplayRecord()  
        {
            if (list.Count == 0) 
            {
                Console.WriteLine(" No Records Found"); 
            }
            else
            {
                foreach (PersonDetails k in list)
                {
                    Console.WriteLine(k);
                }
            }
        }
        public void EditRecord(String fname)  
        {
            for (int k = 0; k < list.Count; k++) 
            {
                if (list[k].FirstName.Equals(fname))
                {
                    PersonDetails person = list[k];
                    Console.WriteLine(person);  

                    while (k == 0) 
                    {
                        Console.WriteLine("What Do You Want to edit Contact Details \n"
                                + "1. Address\n"
                                + "2. city\n"
                                + "3. State\n"
                                + "4. Zip Code\n"
                                + "5. Phone\n"
                                + "6. Email\n"
                                + "7. Save And Exit\n");

                        int choice = Convert.ToInt32(Console.ReadLine()); 
                        switch (choice)  
                        {
                            case 1:
                                Console.Write("Enter new Address:-  "); 
                                String address = Console.ReadLine();  
                                person.Address = address;  
                                break;
                            case 2:
                                Console.Write("Enter new City:- "); 
                                String city = Console.ReadLine(); 
                                person.City = city;
                                break;
                            case 3:
                                Console.Write("Enter new State:- "); 
                                String state = Console.ReadLine();  
                                person.State = state;              
                                break;
                            case 5:
                                Console.Write("Enter new Phone:- "); 
                                String phone = Console.ReadLine();   
                                while (!PhoneNumberValidation(phone))
                                {
                                    Console.Write(phone + " is Invalid Phone Number \nPlease Enter Valid Number:- ");
                                    phone = Console.ReadLine();
                                }
                                person.PhoneNo = phone;                 
                                break;
                            case 4:
                                Console.Write("Enter new Zip Code:- "); 
                                String zip = Console.ReadLine();        
                                person.ZipCode = zip;                       
                                break;
                            case 6:
                                Console.Write("Enter new Email:- "); 
                                String email = Console.ReadLine();
                                while (!EmailValidation(email))
                                {
                                    Console.Write(email + " is Invalid Email \nPlease Enter Valid Email:- ");
                                    email = Console.ReadLine();
                                }//store email veriable
                                person.Email = email;                      
                                break;
                            case 7:
                                k = 1;
                                break;
                            default:
                                Console.WriteLine("Please Enter Valid Option");
                                break;
                        }
                        foreach (PersonDetails t in list) 
                        {
                            Console.WriteLine(t);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{fname} Name of Record Not Found "); 
                }
            }
        }
        public void DeleteRecord(string firstName) 
        {
            for (int i = 0; i < list.Count; i++)   
            {
                if (list[i].FirstName.Equals(firstName))  
                {
                    list.Remove(this.person); 
                    Console.WriteLine($"{firstName} Name of Record Delete Successfully"); 
                }
                else
                {
                    Console.WriteLine($"{firstName} Name of Record Not Found "); 
                }
            }
        }
        public bool CheckExist(string fname) 
        {
            int flag = 0;
            foreach (PersonDetails person in list) 
            {
                if (person.FirstName.Equals(fname))
                { 
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            return false;
        }
        public void SearchRecordCityOrState()  
        {
           
            Console.WriteLine("1.City\n2.State\nEnter Choice:-");

            int choice2 = Convert.ToInt32(Console.ReadLine());
            if (choice2 == 1)
            {
                int count = 0;
                Console.WriteLine("Searching contact by City");
                Console.WriteLine("Enter City Name:-");
                string city = Console.ReadLine();

                for (int i = 0; i < list.Count; i++)  
                {
                    if (list[i].City.Equals(city))  
                    {
                        count++;

                    }
                    else
                    {
                        Console.WriteLine($"{city} City Name of Record Not Found "); 
                    }

                }

                Console.WriteLine($"\nNumber of contact in the City:- {city} are {count}");
            }
            else
            {
                int count = 0;
                Console.WriteLine("Search Record by State");
                Console.WriteLine("Enter State Name:-");
                string state = Console.ReadLine();

                for (int i = 0; i < list.Count; i++)   
                {
                    if (list[i].State.Equals(state))  
                    {
                        count++;
                        Console.WriteLine($"Name:- { list[i].FirstName} State:- { list[i].State} "); 
                    }
                    else
                    {
                        Console.WriteLine($"{state} State Name of Record Not Found "); 
                    }
                }

                Console.WriteLine($"\nNumber of contact in the City:- {state} are {count}");
            }
        }

    }
}
