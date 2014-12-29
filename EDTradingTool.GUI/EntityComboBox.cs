using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    /// <summary>
    /// This class represents a combo box which automatically watches for Entity Events
    /// </summary>
    public class EntityComboBox<T> : ComboBox, Core.IEntityWatcher<T>, IRequiresEntityHandler where T : Core.IEntity
    {
        public EntityComboBox()
            : base()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            entityHandler.RegisterEntityWatcher(this);
        }

        public void OnInitialObjectsLoaded(List<T> objects)
        {
            Items.Clear();
            foreach(var dataSet in objects)
            {
                OnDataSetAdded(dataSet, null);
            }
        }

        public void OnDataSetAdded(T dataSet, params Core.IEntity[] parentObjects)
        {
            Items.Add(dataSet);
        }

        public void OnDataSetUpdated(T dataSet)
        {
            // should happen automatically, maybe a refresh is required
        }

        public void OnDataSetRemoved(T dataSet)
        {
            Items.Remove(dataSet);
        }
    }
}
