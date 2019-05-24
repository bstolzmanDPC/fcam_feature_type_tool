using System;
using  mBox = System.Windows.Forms.MessageBox;
using FeatureCAM;

namespace FeatureTypeTool
{
    public class Addin
    {
        static public Application Application { get; set; }

        static public void OnConnect(object obj, tagFMAddInFlags flags)
        {
            Application.CommandBars.CreateButton("Utilities", "ListFeatureTypes", tagFMMacroButtonFaceId.eMBFID_Cogs);
        }

        static public void OnDisConnect(tagFMAddInFlags flags)
        {
            Application.CommandBars.DeleteButton("Utilities", "ListFeatureTypes");
        }
        static public void ListFeatureTypes()
        {
            FMDocument doc = (FMDocument)Application.ActiveDocument;
            string fList = "";
            foreach (FMFeature feature in doc.Features)
            {
                tagFMFeatureType type;
                feature.GetFeatureType(out type);
                fList += $"{feature.Name} {type} \n";
            }
            mBox.Show(fList);
        }
    }
}
