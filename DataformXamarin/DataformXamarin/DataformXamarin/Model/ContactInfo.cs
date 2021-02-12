using DataformXamarin.Rex;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataformXamarin
{
    public class ContactInfo
    {
        [Display(GroupName = "Name")]
        public String FirstName { get; set; }

        [Display(GroupName = "Name")]
        public String LastName { get; set; }

        [Display(GroupName = "Details")]
        public String Address { get; set; }

        [Display(GroupName = "Details")]
        public int? ContactNo { get; set; }

        public ContactInfo()
        {
        }
    }
}