namespace Task1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            string direc = Directory.GetParent(
            Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString();
            string parth = direc + "\\File.txt";
            string parth1 = direc + "\\File1.txt";
            string parth2 = direc + "\\File2.txt";
            StreamReader reader = new StreamReader(parth);
            char s = '1';
            string typeContact = string.Empty;
            ArrayList arr = new ArrayList();
            while (reader.EndOfStream != true)
            {
                while (s != ' ')
                {
                    s = Convert.ToChar(reader.Read());
                    typeContact += s;
                }

                s = '1';
                switch (typeContact)
                {
                    case "PhoneContact ":
                        {
                            PhoneContact newContact = new PhoneContact();
                            newContact.ReadFromFile(reader);
                            arr.Add(newContact);
                            break;
                        }

                    case "MailContact ":
                        {
                            MailContact newContact = new MailContact();
                            newContact.ReadFromFile(reader);
                            arr.Add(newContact);
                            break;
                        }

                    case "SkypeContact ":
                        {
                            SkypeContact newContact = new SkypeContact();
                            newContact.ReadFromFile(reader);
                            arr.Add(newContact);
                            break;
                        }

                    default:
                        throw new Exception("Incorrect data");
                }

                typeContact = string.Empty;
            }

            arr.Sort();
            StreamWriter writer = new StreamWriter(parth1);
            foreach (var el in arr)
            {
                Console.WriteLine("{0}", el);
                ////( arr[i] as IFileManager).WrtiteToFile(writer);
            }

            var t = arr[0] as IFileManager;
            foreach (var el in arr)
            {
                (el as IFileManager).WrtiteToFile(writer);
            }

            writer.Close();
            Dictionary<string, string[]> newArray = new Dictionary<string, string[]>();
            foreach (var el in arr)
            {
                var el2 = el as IFileManager;
                try
                {
                    newArray[el2.Name][0] = newArray[el2.Name][0];
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    newArray[el2.Name] = new string[] { "-", "-", "-" };
                }

                if (el is PhoneContact)
                {
                    var el1 = el as PhoneContact;
                    newArray[el1.Name][0] = el1.Number;
                }
                else if (el is MailContact)
                {
                    var el1 = el as MailContact;
                    newArray[el1.Name][1] = el1.Email;
                }
                else if (el is SkypeContact)
                {
                    var el1 = el as SkypeContact;
                    newArray[el1.Name][2] = el1.NicknameInSkype;
                }
            }

            StreamWriter writer1 = new StreamWriter(parth2);
            foreach (var el in newArray)
            {
                Console.WriteLine("{0} Phone:{1}, Email:{2}, Skype:{3}", el.Key, el.Value[0], el.Value[1], el.Value[2]);
                writer1.WriteLine("{0} Phone:{1}, Email:{2}, Skype:{3}", el.Key, el.Value[0], el.Value[1], el.Value[2]);
            }
            
            writer1.WriteLine("\n");
            writer1.WriteLine("Only Phone:");
            writer1.WriteLine();

            var linq = from x in newArray
                       where x.Value[1] == "-" && x.Value[2] == "-"
                       select x;
            foreach (var el in linq)
            {
                Console.WriteLine(el.Key);
                writer1.Write("\n{0} Phone:{1}, Email:{2}, Skype:{3}", el.Key, el.Value[0], el.Value[1], el.Value[2]);
            }

            writer1.Close();
            Console.ReadKey();
        }
    }
}