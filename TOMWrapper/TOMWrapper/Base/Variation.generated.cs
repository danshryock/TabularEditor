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
	/// Base class declaration for Variation
	/// </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class Variation: TabularNamedObject, IDescriptionObject, IAnnotationObject
	{
	    protected internal new TOM.Variation MetadataObject { get { return base.MetadataObject as TOM.Variation; } internal set { base.MetadataObject = value; } }

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
        /// Gets or sets the Description of the Variation.
        /// </summary>
		[DisplayName("Description")]
		[Category("Basic"),IntelliSense("The Description of this Variation.")]
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
        /// Gets or sets the IsDefault of the Variation.
        /// </summary>
		[DisplayName("Default")]
		[Category("Variation Options"),IntelliSense("The Default of this Variation.")]
		public bool IsDefault {
			get {
			    return MetadataObject.IsDefault;
			}
			set {
				var oldValue = IsDefault;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("IsDefault", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsDefault = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "IsDefault", oldValue, value));
				OnPropertyChanged("IsDefault", oldValue, value);
			}
		}
		private bool ShouldSerializeIsDefault() { return false; }
        /// <summary>
        /// Gets or sets the Column of the Variation.
        /// </summary>
		[DisplayName("Parent Column")]
		[Category("Basic"),IntelliSense("The Parent Column of this Variation.")][TypeConverter(typeof(TableColumnConverter)),ReadOnly(true)]
		public Column Column {
			get {
				if (MetadataObject.Column == null) return null;
			    return Handler.WrapperLookup[MetadataObject.Column] as Column;
            }
			
		}
		private bool ShouldSerializeColumn() { return false; }
        /// <summary>
        /// Gets or sets the Relationship of the Variation.
        /// </summary>
		[DisplayName("Relationship")]
		[Category("Variation Options"),IntelliSense("The Relationship of this Variation.")][TypeConverter(typeof(AllRelationshipConverter))]
		public Relationship Relationship {
			get {
				if (MetadataObject.Relationship == null) return null;
			    return Handler.WrapperLookup[MetadataObject.Relationship] as Relationship;
            }
			set {
				var oldValue = Relationship;
				if (oldValue?.MetadataObject == value?.MetadataObject) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("Relationship", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.Relationship = value == null ? null : value.MetadataObject;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "Relationship", oldValue, value));
				OnPropertyChanged("Relationship", oldValue, value);
			}
		}
		private bool ShouldSerializeRelationship() { return false; }
        /// <summary>
        /// Gets or sets the DefaultHierarchy of the Variation.
        /// </summary>
		[DisplayName("Default Hierarchy")]
		[Category("Variation Options"),IntelliSense("The Default Hierarchy of this Variation.")][TypeConverter(typeof(AllHierarchyConverter))]
		public Hierarchy DefaultHierarchy {
			get {
				if (MetadataObject.DefaultHierarchy == null) return null;
			    return Handler.WrapperLookup[MetadataObject.DefaultHierarchy] as Hierarchy;
            }
			set {
				var oldValue = DefaultHierarchy;
				if (oldValue?.MetadataObject == value?.MetadataObject) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("DefaultHierarchy", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DefaultHierarchy = value == null ? null : value.MetadataObject;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "DefaultHierarchy", oldValue, value));
				OnPropertyChanged("DefaultHierarchy", oldValue, value);
			}
		}
		private bool ShouldSerializeDefaultHierarchy() { return false; }
        /// <summary>
        /// Gets or sets the DefaultColumn of the Variation.
        /// </summary>
		[DisplayName("Default Column")]
		[Category("Variation Options"),IntelliSense("The Default Column of this Variation.")][TypeConverter(typeof(AllColumnConverter))]
		public Column DefaultColumn {
			get {
				if (MetadataObject.DefaultColumn == null) return null;
			    return Handler.WrapperLookup[MetadataObject.DefaultColumn] as Column;
            }
			set {
				var oldValue = DefaultColumn;
				if (oldValue?.MetadataObject == value?.MetadataObject) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("DefaultColumn", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DefaultColumn = value == null ? null : value.MetadataObject;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "DefaultColumn", oldValue, value));
				OnPropertyChanged("DefaultColumn", oldValue, value);
			}
		}
		private bool ShouldSerializeDefaultColumn() { return false; }



		/// <summary>
		/// Creates a new Variation and adds it to the parent Column.
		/// </summary>
		public Variation(Column parent) : base(new TOM.Variation()) {
			MetadataObject.Name = parent.MetadataObject.Variations.GetNewName("New Variation");
			parent.Variations.Add(this);
			Init();
		}
	
        internal override void RenewMetadataObject()
        {
            var tom = new TOM.Variation();
            Handler.WrapperLookup.Remove(MetadataObject);
            MetadataObject.CopyTo(tom);
            MetadataObject = tom;
            Handler.WrapperLookup.Add(MetadataObject, this);
        }


		public Column Parent { 
			get {
				return Handler.WrapperLookup[MetadataObject.Parent] as Column;
			}
		}

		public Variation Clone(string newName = null) {
		    Handler.BeginUpdate("Clone Variation");

				var tom = MetadataObject.Clone();
				tom.Name = Parent.Variations.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
				var obj = new Variation(tom);

            Handler.EndUpdate();

            return obj;
		}

		
		/// <summary>
		/// Creates a Variation object representing an existing TOM Variation.
		/// </summary>
		internal Variation(TOM.Variation metadataObject) : base(metadataObject)
		{
		}	
    }

	/// <summary>
	/// Collection class for Variation. Provides convenient properties for setting a property on multiple objects at once.
	/// </summary>
	public partial class VariationCollection: TabularObjectCollection<Variation, TOM.Variation, TOM.Column>
	{
		public Column Parent { get; private set; }

		public VariationCollection(string collectionName, TOM.VariationCollection metadataObjectCollection, Column parent) : base(collectionName, metadataObjectCollection)
		{
			Parent = parent;

			// Construct child objects (they are automatically added to the Handler's WrapperLookup dictionary):
			foreach(var obj in MetadataObjectCollection) {
				new Variation(obj) { Collection = this };
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
		[Description("Sets the IsDefault property of all objects in the collection at once.")]
		public bool IsDefault {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("IsDefault"));
				this.ToList().ForEach(item => { item.IsDefault = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the Relationship property of all objects in the collection at once.")]
		public Relationship Relationship {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("Relationship"));
				this.ToList().ForEach(item => { item.Relationship = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the DefaultHierarchy property of all objects in the collection at once.")]
		public Hierarchy DefaultHierarchy {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DefaultHierarchy"));
				this.ToList().ForEach(item => { item.DefaultHierarchy = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the DefaultColumn property of all objects in the collection at once.")]
		public Column DefaultColumn {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DefaultColumn"));
				this.ToList().ForEach(item => { item.DefaultColumn = value; });
				Handler.UndoManager.EndBatch();
			}
		}

		public override string ToString() {
			return string.Format("({0} {1})", Count, (Count == 1 ? "Variation" : "Variations").ToLower());
		}
	}
}