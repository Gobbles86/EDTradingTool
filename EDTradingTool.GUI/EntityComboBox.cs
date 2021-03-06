﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    /// <summary>
    /// This class represents a combo box which automatically watches for Entity Events
    /// </summary>
    public class EntityComboBox<T> : ComboBox, Core.IEntityWatcher<T>, IRequiresEntityHandler where T : Entity.EntityWithIdAndName
    {
        public EntityComboBox()
            : base()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.MaxDropDownItems = 25;
            MinimumSize = new Size(100, 0);
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            entityHandler.RegisterEntityWatcher(this);
        }

        public void Unregister(Core.IEntityHandler entityHandler)
        {
            entityHandler.UnregisterEntityWatcher(this);
        }

        public void OnInitialObjectsLoaded(List<T> objects)
        {
            Items.Clear();
            Items.Add(String.Empty);
            foreach(var dataSet in objects)
            {
                OnDataSetAdded(dataSet, null);
            }
        }

        public void OnDataSetAdded(T dataSet, params Core.IEntity[] parentObjects)
        {
            Items.Add(dataSet);

            Items.Remove(String.Empty);
            var castedItems = Items.Cast<T>();
            var orderedItems = castedItems.OrderBy(entity => entity.Name).ToArray();

            Items.Clear();
            Items.Add(String.Empty);
            Items.AddRange(orderedItems);
        }

        public void OnDataSetUpdated(T dataSet)
        {
            // should happen automatically, maybe a refresh is required
        }

        public void OnDataSetRemoved(T dataSet)
        {
            if (!Items.Contains(dataSet)) return;

            Items.Remove(dataSet);
        }
    }
}
