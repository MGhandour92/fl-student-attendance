using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Project_8_Attendance
{
    public partial class Home : Form
    {
        public static string UserName = "";
        public static string UserType = "";

        public Home()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            #region Getting Data

            //Validate or Create intial data and get the datafiles path
            string dataPath = Validate_Intial_Data();

            // Now it is ready to validate the data
            // Get the name and password form TextBoxes
            string nameData = nameTB.Text;
            string passwordData = passTB.Text;

            //Get User Type
            if (empRB.Checked)
                UserType = "employee";
            else if (stdRB.Checked)
                UserType = "student";

            #endregion


            #region Validating Data

            // Validate data with the file
            bool validated = Read_Validate_Employee(nameData, passwordData, dataPath, UserType);

            if (validated) //if valid
            {
                //Set the global variable with the userName for later use
                UserName = nameData;

                #region Redirect

                //Hide the Current form
                Hide();

                //Go to the next form
                Home_LoggedIn HomePage = new Home_LoggedIn();
                HomePage.Show();

                //This will close the old form
                HomePage.Closed += (s, args) => Close();
                HomePage.Show();

                #endregion

            }
            else
            {
                MessageBox.Show("Wrong Name or Password! Please Try Again", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            #endregion
        }

        /// <summary>
        /// Validate that the intial data found, if not it will be created
        /// </summary>
        /// <returns>Path of the Data files</returns>
        private string Validate_Intial_Data()
        {
            // Get the path where the EXE will be running from
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            // Append the Folder Name That will have Data
            DirectoryInfo dinfo = new DirectoryInfo(appPath + @"\DataFiles\");

            // If folder is not found then create the directory
            if (!dinfo.Exists)
            {
                dinfo.Create();
                // Create the file of Employees to help them login
                Create_Intial_Data(dinfo.FullName);
            }
            else // If folder is found, then check if the files existance
            {
                // Employees Data
                if (!File.Exists(dinfo.FullName + "employees.xml"))
                {
                    // Create the file of Employees to help them login
                    Create_Intial_Data(dinfo.FullName);
                }
                if (!File.Exists(dinfo.FullName + "students.xml"))
                {
                    // Create the file of Employees to help them login
                    Create_Intial_Data(dinfo.FullName);
                }
            }

            return dinfo.FullName;
        }

        /// <summary>
        /// <para>Create the intial Data for Employees and Students </para>
        /// </summary>
        /// <param name="path">Path that the file will be saved in</param>
        /// <remarks>It will contain Name, and password for each Employee and Students</remarks>
        private void Create_Intial_Data(string path)
        {
            #region Employees

            //Create A Dictionary of Employees
            //Name as ID
            //Password as Value
            Dictionary<string, string> Employees = new Dictionary<string, string>();

            Employees.Add("EMP1", "123");
            Employees.Add("EMP2", "123");

            //Create Employees file
            using (XmlWriter writer = XmlWriter.Create(path + "employee.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees"); //Root Node

                //for Each pair in Dictionary
                foreach (var emp in Employees)
                {
                    writer.WriteStartElement("Employee"); //Parent Node
                    writer.WriteAttributeString("name", emp.Key); //Name as attribute for searching
                    writer.WriteString(emp.Value); //Value - Password
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            } //No Dispose for XML Writer Object needed as [using] is used

            #endregion

            #region Students

            //Create A Dictionary of Students
            //array of strings for attributes
            //Password as Value
            Dictionary<string, string[]> Students = new Dictionary<string, string[]>();

            //array of strings using the order: password, ID, Academic Year
            Students.Add("STD1", new string[] { "123", "1", "2017" });
            Students.Add("STD2", new string[] { "123", "2", "2018" });

            //Create Students file
            using (XmlWriter writer = XmlWriter.Create(path + "student.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Students"); //Root Node

                //for Each pair in Dictionary
                foreach (var stud in Students)
                {
                    writer.WriteStartElement("Student"); //Parent Node
                    writer.WriteAttributeString("name", stud.Key); //Name as attribute for searching

                    //create attribute for each value in the array of strings
                    writer.WriteAttributeString("id", stud.Value[1]); //id as attribute
                    writer.WriteAttributeString("year", stud.Value[2]); //year as attribute

                    writer.WriteString(stud.Value[0]); //Value - Password
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            } //No Dispose for XML Writer Object needed as [using] is used

            #endregion

            #region Courses

            //Create A Dictionary of Courses
            //Name as ID
            ////array of strings for attributes
            Dictionary<string, string[]> Courses = new Dictionary<string, string[]>();

            //array of strings using the order: Name, Academic Year
            Courses.Add("DS17", new string[] { "Data-Structures", "2017" });
            Courses.Add("CS18", new string[] { "C-Sharp", "2018" });

            //Create Course file
            using (XmlWriter writer = XmlWriter.Create(path + "course.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Courses"); //Root Node

                //for Each pair in Dictionary
                foreach (var crs in Courses)
                {
                    writer.WriteStartElement("Course"); //Parent Node
                    writer.WriteAttributeString("code", crs.Key); //Code as attribute for searching

                    //create attribute for each value in the array of strings
                    writer.WriteAttributeString("year", crs.Value[1]); //year as attribute

                    writer.WriteString(crs.Value[0]); //Value - Name
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            } //No Dispose for XML Writer Object needed as [using] is used

            #endregion
        }

        /// <summary>
        /// Read the users data from XML file.
        /// Then Validate the data
        /// </summary>
        /// <param name="nameToValidate">Name text</param>
        /// <param name="passwordToValidate">Password text</param>
        /// <param name="path">Path to the File</param>
        /// <returns>Flag if valid or not</returns>
        private bool Read_Validate_Employee(string nameToValidate, string passwordToValidate, string path, string userType)
        {
            // Validation Flag
            bool valid = false;
            //File name according to user type
            string fileName = userType + ".xml";

            // Read the file
            // Create an XML reader for this file.
            using (XmlReader reader = XmlReader.Create(path + fileName))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            //When checking on the tag name
                            case "Employee":
                                // Search for the attribute name on this current node.
                                string empName = reader["name"];

                                //if it has attribute and equal to the name to be validated
                                //change characters to upper as the file to avoid Case sensitivity 
                                if (empName != null && empName == nameToValidate.ToUpper())
                                {    // Next read will contain text.
                                    if (reader.Read())
                                    {
                                        //if same password 
                                        if (reader.Value.Trim() == passwordToValidate)
                                        {
                                            //set the variable to true, else it will stay false
                                            valid = true;
                                        }
                                    }
                                }
                                break;

                            case "Student":
                                // Search for the attribute name on this current node.
                                string studName = reader["name"];

                                //if it has attribute and equal to the name to be validated
                                //change characters to upper as the file to avoid Case sensitivity 
                                if (studName != null && studName == nameToValidate.ToUpper())
                                {    // Next read will contain text.
                                    if (reader.Read())
                                    {
                                        //if same password 
                                        if (reader.Value.Trim() == passwordToValidate)
                                        {
                                            //set the variable to true, else it will stay false
                                            valid = true;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return valid;
        }
    }
}
