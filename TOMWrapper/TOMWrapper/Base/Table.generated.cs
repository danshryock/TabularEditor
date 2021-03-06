// Code generated by a template
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using TabularEditor.PropertyGridUI;
using TabularEditor.UndoFramework;
using TOM = Microsoft.AnalysisServices.Tabular;

namespace TabularEditor.TOMWrapper
{
  
    /// <summary>
	/// Base class declaration for Table
	/// </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class Table: TabularNamedObject, IHideableObject, IDescriptionObject, IAnnotationObject
	{
	    protected internal new TOM.Table MetadataObject { get { return base.MetadataObject as TOM.Table; } internal set { base.MetadataObject = value; } }

		public Table(Model parent) : base(parent.Handler, new TOM.Table(), false) {
			MetadataObject.Name = parent.MetadataObject.Tables.GetNewName("New Table");
			parent.Tables.Add(this);
			Init();
		}

		public Table(TabularModelHandler handler, TOM.Table tableMetadataObject) : base(handler, tableMetadataObject)
		{
		}
		public string GetAnnotation(string name) {
		    return MetadataObject.Annotations.Find(name)?.Value;
		}
		public void SetAnnotation(string name, string value, bool undoable = true) {
			if(MetadataObject.Annotations.Contains(name)) {
				MetadataObject.Annotations[name].Value = value;
			} else {
				MetadataObject.Annotations.Add(new TOM.Annotation{ Name = name, Value = value });
			}
			if (undoable) Handler.UndoManager.Add(new UndoAnnotationAction(this, name, value));
		}
		        /// <summary>
        /// Gets or sets the DataCategory of the Table.
        /// </summary>
		[DisplayName("Data Category")]
		[Category("Metadata"),IntelliSense("The Data Category of this Table.")]
		public string DataCategory {
			get {
			    return MetadataObject.DataCategory;
			}
			set {
				var oldValue = DataCategory;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("DataCategory", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DataCategory = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "DataCategory", oldValue, value));
				OnPropertyChanged("DataCategory", oldValue, value);
			}
		}
		private bool ShouldSerializeDataCategory() { return false; }
        /// <summary>
        /// Gets or sets the Description of the Table.
        /// </summary>
		[DisplayName("Description")]
		[Category("Basic"),IntelliSense("The Description of this Table.")][Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string Description {
			get {
			    return MetadataObject.Description;
			}
			set {
				var oldValue = Description;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("Description", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.Description = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "Description", oldValue, value));
				OnPropertyChanged("Description", oldValue, value);
			}
		}
		private bool ShouldSerializeDescription() { return false; }
        /// <summary>
        /// Collection of localized descriptions for this Table.
        /// </summary>
        [Browsable(true),DisplayName("Descriptions"),Category("Translations and Perspectives")]
	    public new TranslationIndexer TranslatedDescriptions { get { return base.TranslatedDescriptions; } }
        /// <summary>
        /// Gets or sets the IsHidden of the Table.
        /// </summary>
		[DisplayName("Hidden")]
		[Category("Basic"),IntelliSense("The Hidden of this Table.")]
		public bool IsHidden {
			get {
			    return MetadataObject.IsHidden;
			}
			set {
				var oldValue = IsHidden;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("IsHidden", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsHidden = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "IsHidden", oldValue, value));
				OnPropertyChanged("IsHidden", oldValue, value);
				Handler.UpdateObject(this);
			}
		}
		private bool ShouldSerializeIsHidden() { return false; }
    }

	/// <summary>
	/// Collection class for Table. Provides convenient properties for setting a property on multiple objects at once.
	/// </summary>
	public partial class TableCollection: TabularObjectCollection<Table, TOM.Table, TOM.Model>
	{
		public Model Parent { get; private set; }

		public TableCollection(TabularModelHandler handler, string collectionName, TOM.TableCollection metadataObjectCollection, Model parent) : base(handler, collectionName, metadataObjectCollection)
		{
			Parent = parent;

			// Construct child objects (they are automatically added to the Handler's WrapperLookup dictionary):
			foreach(var obj in MetadataObjectCollection) {
				switch(obj.GetSourceType()) {
				    case TOM.PartitionSourceType.Calculated: new CalculatedTable(handler, obj) { Collection = this }; break;
					default: new Table(handler, obj) { Collection = this }; break;
				}
			}
		}

		[Description("Sets the DataCategory property of all objects in the collection at once.")]
		public string DataCategory {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DataCategory"));
				this.ToList().ForEach(item => { item.DataCategory = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the Description property of all objects in the collection at once.")]
		public string Description {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("Description"));
				this.ToList().ForEach(item => { item.Description = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the IsHidden property of all objects in the collection at once.")]
		public bool IsHidden {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("IsHidden"));
				this.ToList().ForEach(item => { item.IsHidden = value; });
				Handler.UndoManager.EndBatch();
			}
		}

		public override string ToString() {
			return string.Format("({0} {1})", Count, (Count == 1 ? "Table" : "Tables").ToLower());
		}
	}
}
