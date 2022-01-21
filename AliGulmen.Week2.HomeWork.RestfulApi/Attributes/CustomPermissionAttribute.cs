using System;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Attributes
{
    public class CustomPermissionAttribute : Attribute
    {
        //This attribute will check if the client has authorization
        public string Permission { get; /*set; //we don't let this set from outside, just able to change from constructor*/}
        public CustomPermissionAttribute(string permission)
        {
            Permission = permission;
        }

    }

}
