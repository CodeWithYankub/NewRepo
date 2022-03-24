using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary.Streams
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Stream Stream { get; set; }

        private Dictionary<string,int> Classes { get; set; }

        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Classes = new Dictionary<string, int>();

            if (id > 0)
                Stream = new Stream().Read(id);
        }

        #region Functions
        void GetClasses()
        {
            List<Class> classes = new Class().Read();

            if (cbClass.Items.Count > 0)
                cbClass.Items.Clear();

            cbClass.Items.Add("--- select ---");
            Classes.Clear();

            foreach(Class classe in classes)
            {
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);
                string text = string.Format("{0} {1}-{2}", sector.Acronym, level.Class, faculty.Name);
                cbClass.Items.Add(text);
                Classes.Add(text, classe.ID);
            }

            cbClass.SelectedIndex = 0;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Stream stream = new Stream()
                {
                    ClassId = Classes[cbClass.Text],
                    Description=tbStream.Text
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(stream);
                }
                else
                {
                    Update(stream);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Stream stream)
        {
            var updated = stream.Update(Stream.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Stream Updated Successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Stream stream)
        {
            if (!stream.Exists())
                doUpdates(stream);
            else
                Helper.ShowMessage(lbError, "Stream already exists");
        }

        private void Create(Stream stream)
        {
            if (!stream.Exists())
            {
                var created = stream.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Stream Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Stream already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetClasses();

            if (Action.Equals(App.Action.Edit))
            {
                Class classe = new Class().Read(Stream.ClassId);
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);
                cbClass.Text = string.Format("{0} {1}-{2}", sector.Acronym, level.Class, faculty.Name);
                tbStream.Text = Stream.Description;

                btnSave.Text = "Update Record";
            }
        }
    }
}
