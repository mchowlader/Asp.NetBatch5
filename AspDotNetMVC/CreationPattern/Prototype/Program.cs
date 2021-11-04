using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            doc.Name = "Experoment";
            doc.OwnerName = "Mithun CH";
            doc.Content = "This is an experimen";
            doc.CreateDate = DateTime.Now;


            var newDoc = doc.Copy();
            newDoc.Content = "Content was update";

            //Icloneable use korle  comment kora code gula open kore dite hobe.
            //ICloneable


            //var cloneableObj = GetItem();
            //var newCloneObj = cloneableObj.Clone(); //I can copy object but can not modifie object value


        }


        //Icloneable use korle  comment kora code gula open kore dite hobe.
        //if i use ICloneable Interface


        //public static ICloneable GetItem()
        //{
        //    Document doc = new Document();
        //    doc.Name = "Experoment";
        //    doc.OwnerName = "Mithun CH";
        //    doc.Content = "This is an experimen";
        //    doc.CreateDate = DateTime.Now;

        //    return doc;
        //}
    }
}
