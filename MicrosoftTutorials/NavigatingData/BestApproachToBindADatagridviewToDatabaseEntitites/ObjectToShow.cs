using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApproachToBindADatagridviewToDatabaseEntitites
{
    public class ObjectToShow
    {
        MyDatabaseObject _myDatabaseObject = new MyDatabaseObject();
        
        public ObjectToShow(MyDatabaseObject myDatabaseObject)
        {
            _myDatabaseObject = myDatabaseObject;
        }

        public string Data1     //to asign to a datagridview column
        {
            get{ return _myDatabaseObject.data1; }
            set{ _myDatabaseObject.data1 = value; }
        }

        public string Data2     //to asign to a datagridview column
        {
            get { return _myDatabaseObject.data2; }
            set { _myDatabaseObject.data2 = value; }
        }

        //This is to notify the changes made to the object directoy and not from the control.
        //This refreshes the datagridview
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    
}
