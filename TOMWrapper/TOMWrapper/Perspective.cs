﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOM = Microsoft.AnalysisServices.Tabular;

namespace TabularEditor.TOMWrapper
{
    public partial class Perspective
    {
        public Perspective() : base(TabularModelHandler.Singleton, new TOM.Perspective() { Name = TabularModelHandler.Singleton.Model.Perspectives.MetadataObjectCollection.GetNewName("Perspective") }, false )
        {

        }

        public override TabularNamedObject Clone(string newName, bool includeTranslations)
        {
            Handler.BeginUpdate("duplicate perspective");
            var tom = MetadataObject.Clone();
            tom.IsRemoved = false;
            tom.Name = Model.Perspectives.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
            var p = new Perspective(Handler, tom);
            Model.Perspectives.Add(p);

            if (includeTranslations)
            {
                p.TranslatedDescriptions.CopyFrom(TranslatedDescriptions);
                p.TranslatedDisplayFolders.CopyFrom(TranslatedDisplayFolders);
                if (string.IsNullOrEmpty(newName))
                    p.TranslatedNames.CopyFrom(TranslatedNames, n => n + " copy");
                else
                    p.TranslatedNames.CopyFrom(TranslatedNames, n => n.Replace(Name, newName));
            }

            Handler.EndUpdate();

            return p;
        }

        public override void Delete()
        {
            if (Collection != null) Collection.Remove(this);
        }

        internal override void Undelete(ITabularObjectCollection collection)
        {
            var tom = new TOM.Perspective();
            MetadataObject.CopyTo(tom);
            tom.IsRemoved = false;
            MetadataObject = tom;

            base.Undelete(collection);
        }
    }
}
