using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Zaměstnanec2
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public delegate void Check(string obj, bool isOK, bool valueEmpty);

    public partial class MainWindow : Window
    {
        Employee em = new Employee();
        bool isOKFName;
        bool isOKSName;
        bool isOKBDay;
        bool isOKJob;
        bool isOKSalary;
        public MainWindow()
        {
            if (!File.Exists(@"Employees.txt"))
            {
                using (StreamWriter sw = File.CreateText(@"Employees.txt")) { }
            }
            em.Checker1 += Controler1;
            em.Checker2 += Controler2;
            InitializeComponent();
            em.FName = "";
            em.SName = "";
            em.Salary = "";
            em.Job = "";
            em.BDay = "";
            em.HGrad = "";
            em._ID = Guid.NewGuid();
            DataContext = em;
            using (StreamReader sr = new StreamReader("Employees.txt"))
            {
                StringBuilder sb = new StringBuilder();
                string s;
                int ind1;
                int ind2;
                while ((s = sr.ReadLine()) != null)
                {
                    ind1 = s.IndexOf("\"");
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.FName = sb.ToString();
                    sb.Clear();
                    ind1 = s.IndexOf("\"", ind2 + 1);
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.SName = sb.ToString();
                    sb.Clear();
                    ind1 = s.IndexOf("\"", ind2 + 1);
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.BDay = sb.ToString();
                    sb.Clear();
                    ind1 = s.IndexOf("\"", ind2 + 1);
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.HGrad = sb.ToString();
                    sb.Clear();
                    ind1 = s.IndexOf("\"", ind2 + 1);
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.Job = sb.ToString();
                    sb.Clear();
                    ind1 = s.IndexOf("\"", ind2 + 1);
                    ind2 = s.IndexOf("\"", ind1 + 1);
                    for (int i = ind1 + 1; i < ind2; i++)
                    {
                        sb.Append(s[i]);
                    }
                    em.Salary = sb.ToString();
                    sb.Clear();
                    Employee q = Employee.AllEmp.Find(t => t._ID == em._ID);
                    int qIndex = Employee.AllEmp.IndexOf(q);
                    Employee.AllEmp.Add(Employee.EmployeeCopy(em, Controler1));
                    lview.ItemsSource = null;
                    lview.ItemsSource = Employee.AllEmp;
                }
            }
            em.FName = "";
            em.SName = "";
            em.Salary = "";
            em.Job = "";
            em.BDay = "";
            em.HGrad = "";
            em._ID = Guid.NewGuid();
            DataContext = em;
        }
        public void Controler1(string obj, bool isOK, bool valueEmpty)
        {
            if (obj == "fname")
            {
                if (isOK)
                {
                    tbFName.Background = Brushes.White;
                    labErrorFirstName.Content = "";
                    isOKFName = true;
                }

                if (!isOK)
                {
                    if (valueEmpty)
                    {
                        tbFName.Background = Brushes.White;
                        labErrorFirstName.Content = "";
                        isOKFName = true;
                    }
                    else
                    {
                        tbFName.Background = Brushes.Red;
                        labErrorFirstName.Content = "Chyba při zadávání jména!";
                        isOKFName = false;
                    }

                }
            }
            if (obj == "sname")
            {
                if (isOK)
                {
                    tbSName.Background = Brushes.White;
                    labErrorSecondName.Content = "";
                    isOKSName = true;
                }

                if (!isOK)
                {
                    if (valueEmpty)
                    {
                        tbSName.Background = Brushes.White;
                        labErrorSecondName.Content = "";
                        isOKSName = false;
                    }
                    else
                    {
                        tbSName.Background = Brushes.Red;
                        labErrorSecondName.Content = "Chyba při zadávání jména!";
                        isOKSName = false;
                    }

                }
            }
            if (obj == "bday")
            {
                if (isOK)
                {
                    tpBDay.Background = Brushes.White;
                    labErrorBday.Content = "";
                    isOKBDay = true;
                }

                if (!isOK)
                {
                    if (valueEmpty)
                    {
                        tpBDay.Background = Brushes.White;
                        labErrorBday.Content = "";
                        isOKBDay = true;
                    }
                    else
                    {
                        tpBDay.Background = Brushes.Red;
                        labErrorBday.Content = "Chyba při zadávání narozenin!";
                        isOKBDay = false;
                    }

                }
            }


        }
        public void Controler2(string obj, bool isOK, bool valueEmpty)
        {
            if (obj == "job")
            {
                if (isOK)
                {
                    tbJob.Background = Brushes.White;
                    labErrorJob.Content = "";
                    isOKJob = true;
                }

                if (!isOK)
                {
                    if (valueEmpty)
                    {
                        tbJob.Background = Brushes.White;
                        labErrorJob.Content = "";
                        isOKJob = false;
                    }
                    else
                    {
                        tbJob.Background = Brushes.Red;
                        labErrorJob.Content = "Chyba při zadávání druhu povolání!";
                        isOKJob = false;
                    }

                }
            }
            if (obj == "salary")
            {
                if (isOK)
                {
                    tbSalary.Background = Brushes.White;
                    labErrorSalary.Content = "";
                    isOKSalary = true;
                }

                if (!isOK)
                {
                    if (valueEmpty)
                    {
                        tbSalary.Background = Brushes.White;
                        labErrorSalary.Content = "";
                        isOKSalary = false;
                    }
                    else
                    {
                        tbSalary.Background = Brushes.Red;
                        labErrorSalary.Content = "Chyba při zadávání mzdy!";
                        isOKSalary = false;
                    }

                }
            }

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (isOKFName == true && isOKSName == true && isOKBDay == true && isOKJob == true && isOKSalary == true)
            {
                using (StreamWriter sw = new StreamWriter("Employees.txt", true))
                {
                    sw.Write("Jméno: \"" + em.FName + "\" ");
                    sw.Write("Příjmení: \"" + em.SName + "\" ");
                    sw.Write("Narozeniny: \"" + em.BDay + "\" ");
                    sw.Write("Vzdělání: \"" + em.HGrad + "\" ");
                    sw.Write("Pracovní pozice: \"" + em.Job + "\" ");
                    sw.WriteLine("Plat: \"" + em.Salary.ToString() + "\"");
                    ableToSave.Content = $"Člověk uložen";
                }
                Employee q = Employee.AllEmp.Find(t => t._ID == em._ID);
                int qIndex = Employee.AllEmp.IndexOf(q);

                if (q != null)
                {
                    Employee.AllEmp[qIndex] = Employee.EmployeeCopy(em, Controler1);
                }
                else
                {
                    Employee.AllEmp.Add(Employee.EmployeeCopy(em, Controler1));
                    Employee.Clear(em);
                }

                lview.ItemsSource = null;
                lview.ItemsSource = Employee.AllEmp;
            }
            else
            {
                ableToSave.Content = "Jedna nebo více z povinných možností nejsou vyplněny nebo je nějaká možnost špatně vyplněna!";
            }
        }

        private void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Employees.txt"))
            {
                for (int i = 0; i < Employee.AllEmp.Count; i++)
                {
                    sw.Write("Jméno: \"" + Employee.AllEmp[i].FName + "\" ");
                    sw.Write("Příjmení: \"" + Employee.AllEmp[i].SName + "\" ");
                    sw.Write("Narozeniny: \"" + Employee.AllEmp[i].BDay + "\" ");
                    sw.Write("Vzdělání: \"" + Employee.AllEmp[i].HGrad + "\" ");
                    sw.Write("Pracovní pozice: \"" + Employee.AllEmp[i].Job + "\" ");
                    sw.WriteLine("Plat: \"" + Employee.AllEmp[i].Salary + "\"");
                }
            }
            CreateXml("XML.xml");
            ableToSave.Content = $"Soubor byl aktualizován!";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee toDelete = ((Button)sender).DataContext as Employee;
            Employee.AllEmp.Remove(toDelete);

            lview.ItemsSource = null;
            lview.ItemsSource = Employee.AllEmp;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            em.FName = (((Button)sender).DataContext as Employee).FName;
            em.SName = (((Button)sender).DataContext as Employee).SName;
            em.BDay = (((Button)sender).DataContext as Employee).BDay;
            em.HGrad = (((Button)sender).DataContext as Employee).HGrad;
            em.Job = (((Button)sender).DataContext as Employee).Job;
            em.Salary = (((Button)sender).DataContext as Employee).Salary;
            em._ID = (((Button)sender).DataContext as Employee)._ID;
        }
        private void btnNovak_Click(object sender, RoutedEventArgs e)
        {
            em.FName = "Jan";
            em.SName = "Novak";
            em.Salary = "10000";
            em.Job = "Ucitel";
            em.BDay = "01.01.2000";
            em.HGrad = "Základní škola";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            em.FName = "";
            em.SName = "";
            em.Salary = "";
            em.Job = "";
            em.BDay = "";
            em.HGrad = "";
        }
        public static void CreateXml(string soubor)
        {
            XDocument doc = new XDocument(new XElement("Zaměstnanci"));
            doc.Root.SetAttributeValue("datum", DateTime.Now);
            for (int i = 0; i < Employee.AllEmp.Count; i++)
            {
                XElement emXeml = new XElement("Zaměstnanec");
                emXeml.SetAttributeValue("Id", i);
                emXeml.SetAttributeValue("First_name", Employee.AllEmp[i].FName);
                emXeml.SetAttributeValue("Second_Name", Employee.AllEmp[i].SName);
                emXeml.SetAttributeValue("Bday", Employee.AllEmp[i].BDay);
                emXeml.SetAttributeValue("Hgrad", Employee.AllEmp[i].HGrad);
                emXeml.SetAttributeValue("Job", Employee.AllEmp[i].Job);
                emXeml.SetAttributeValue("Salary", Employee.AllEmp[i].Salary);
                doc.Root.Add(emXeml);

            }
            doc.Save(soubor);
        }
        class Person : INotifyPropertyChanged
        {
            protected Regex str = new Regex("^[A-Z][a-z]{2,20}$");
            private Regex bdayreg = new Regex("^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$");
            private Regex salary = new Regex("^\\d{5,6}$");
            public event Check Checker1;
            private string fName;
            public string FName
            {
                get => fName;
                set
                {
                    if (str.IsMatch(value))
                    {
                        fName = value;
                        Checker1.Invoke("fname", true, false);
                    }
                    else
                    {
                        fName = value;
                        if (value == "")
                            Checker1.Invoke("fname", false, true);
                        else Checker1.Invoke("fname", false, false);

                    }
                    OnPropertyChanged("FName");
                    OnPropertyChanged("Status");

                }
            }
            private string sName;
            public string SName
            {
                get => sName;
                set
                {
                    if (str.IsMatch(value))
                    {
                        sName = value;
                        Checker1.Invoke("sname", true, false);
                    }
                    else
                    {
                        sName = value;
                        if (value == "")
                            Checker1.Invoke("sname", false, true);
                        else Checker1.Invoke("sname", false, false);
                    }
                    OnPropertyChanged("SName");
                    OnPropertyChanged("Status");

                }
            }
            private string bDay;
            public string BDay
            {
                get => bDay;
                set
                {
                    if (bdayreg.IsMatch(value))
                    {
                        bDay = value;
                        Checker1.Invoke("bday", true, false);
                    }
                    else
                    {
                        bDay = value;
                        if (value == "")
                            Checker1.Invoke("bday", false, true);
                        else Checker1.Invoke("bday", false, false);
                    }
                    bDay = value;
                    OnPropertyChanged("BDay");
                    OnPropertyChanged("Status");

                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        class Employee : Person
        {
            public static List<Employee> AllEmp { get; set; } = new List<Employee>();
            public Guid _ID { get; set; }
            public static Employee EmployeeCopy(Employee em, Check c)
            {
                Employee em2 = new Employee();

                em2.Checker1 += c;
                em2.Checker2 = em.Checker2;
                em2.SName = em.SName;
                em2.FName = em.FName;
                em2.Salary = em.Salary;
                em2.Job = em.Job;
                em2.BDay = em.BDay;
                em2.HGrad = em.HGrad;
                em2._ID = Guid.NewGuid();
                return em2;
            }
            public static void Clear(Employee em)
            {
                em.SName = "";
                em.FName = "";
                em.Salary = "";
                em.Job = "";
                em.BDay = "";
                em.HGrad = "";
            }
            private Regex salaryreg = new Regex("^\\d{5,6}$");
            public event Check Checker2;
            private string hGrad;
            public string HGrad
            {
                get => hGrad;
                set
                {
                    hGrad = value;
                    OnPropertyChanged("HGrad");
                    OnPropertyChanged("Status");

                }
            }
            private string job;
            public string Job
            {
                get => job;
                set
                {
                    if (str.IsMatch(value))
                    {
                        job = value;
                        Checker2.Invoke("job", true, false);
                    }
                    else
                    {
                        job = value;
                        if (value == "")
                            Checker2.Invoke("job", false, true);
                        else Checker2.Invoke("job", false, false);
                    }
                    job = value;
                    OnPropertyChanged("Job");
                    OnPropertyChanged("Status");

                }
            }
            private string salary;
            public string Salary
            {
                get => salary;
                set
                {
                    if (salaryreg.IsMatch(value))
                    {
                        salary = value;
                        Checker2.Invoke("salary", true, false);
                    }
                    else
                    {
                        salary = value;
                        if (value == "")
                            Checker2.Invoke("salary", false, true);
                        else Checker2.Invoke("salary", false, false);
                    }
                    salary = value;
                    OnPropertyChanged("Salary");
                    OnPropertyChanged("Status");

                }
            }
            public string Status
            {
                get => "Jméno: \"" + FName + "\" Příjmení: \"" + SName + "\" Narozeniny: \"" + BDay + "\" Nejvyšší dokončené vzdělání: \"" + HGrad + "\" Pracovní pozice: \"" + Job + "\" Výplata: \"" + Salary + " Kč\"";
            }

        }
    }
}
