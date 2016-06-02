using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace UWPIntellisenseDemo
{
    public class ConnectorViewModel
    {
        public static ObservableCollection<Connector> listViews;
        static ConnectorViewModel()
        {
            listViews = new ObservableCollection<Connector>();
            listViews.Add(new Connector { Name = "哈1" });
            listViews.Add(new Connector { Name = "哈2" });
            listViews.Add(new Connector { Name = "哈3" });
            listViews.Add(new Connector { Name = "哈4" });
            listViews.Add(new Connector { Name = "哈5" });
        }

        public static ObservableCollection<Connector> GetViewModel()
        {
            ObservableCollection<Connector> views = new ObservableCollection<Connector>();
            foreach(Connector c in listViews)
            {
                views.Add(c);
            }
            return views;
        }

        public static ObservableCollection<Connector> UpdateSource(string Name)
        {
            ObservableCollection<Connector> ret = new ObservableCollection<Connector>();
            foreach(Connector c in listViews)
            {
                if (c.Name.Contains(Name))
                {
                    ret.Add(c);
                }
            }
            return ret;
        }
    }
    public class Connector
    {
        public string Name { get; set; }
    }
}
