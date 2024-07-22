using MusicSchool.Model;
using static MusicSchool.Configuration.AppConfiguration;
using static MusicSchool.Service.MusicSchoolService;


namespace MusicSchool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CreateCarXmlIfNotExists();
            // InsertClassRoom("guitar jazz");
            //AddTeacher("guitar jazz", "enosh");
            // AddStudent("guitar jazz", "leizer", "guitar");
            //AddStudent("guitar jazz", "leizer", "guitar");
            //AddStudent("guitar jazz", "leizer", "guitar");
            //AddStudent("piano jazz", "ely", "piano");
            //AddStudent("violino jazz", "beny", "violino");
            //AddStudent("guitar pop", "adina", "guitar");
            //AddManyStudents("guitar jazz");
            //UpdateInstrument( "violino", "leizer");
            //UpdateTeacherName("guitar jazz", "alef");
            UpdateStudent("guitar jazz", "omer");

        }
    }



}
