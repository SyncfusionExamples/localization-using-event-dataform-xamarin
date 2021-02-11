using DataformXamarin.Rex;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DataformXamarin
{
    public class DataformBehavior : Behavior<SfDataForm>
    {
        public DataformBehavior()
        {
        }
        SfDataForm dataForm;
        protected override void OnAttachedTo(SfDataForm bindable)
        {
            dataForm = bindable;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Localization.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(CultureInfo.CurrentCulture);
            }
            dataForm.DataObject = new ContactInfo();
            dataForm.Validating += DataForm_Validating;

            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
            base.OnAttachedTo(bindable);
        }
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.LabelText == "FirstName")
                {
                    e.DataFormItem.LabelText = Localization.FirstName;
                    e.DataFormItem.PlaceHolderText = Localization.EnterFirstName;
                }
                if (e.DataFormItem.LabelText == "LastName")
                {
                    e.DataFormItem.LabelText = Localization.LastName;
                    e.DataFormItem.PlaceHolderText = Localization.EnterLastName;
                }
                if (e.DataFormItem.LabelText == "Address")
                {
                    e.DataFormItem.LabelText = Localization.Address;
                    e.DataFormItem.PlaceHolderText = Localization.EnterAddress;
                }
                if (e.DataFormItem.LabelText == "ContactNo")
                    e.DataFormItem.LabelText = Localization.ContactNo;

                if (e.DataFormItem.GroupName == "Name")
                {
                    e.DataFormItem.GroupName = Localization.Name;
                }
                if (e.DataFormItem.GroupName == "Details")
                {
                    e.DataFormItem.GroupName = Localization.Details;
                }
            }
        }
        private void DataForm_Validating(object sender, ValidatingEventArgs e)
        {
            if (e.PropertyName == "FirstName")
            {
                if (e.Value.ToString().Length == 0)
                {
                    e.IsValid = false;
                    e.ErrorMessage = Localization.FirstNameEmpty;
                }
                else if (e.Value != null && e.Value.ToString().Length > 0 && !(e.Value.ToString().Length >= 5))
                {
                    e.IsValid = false;
                    e.ErrorMessage = Localization.FirstNameLength;
                }
            }
            if (e.PropertyName == "LastName")
            {
                if (e.Value.ToString().Length == 0)
                {
                    e.IsValid = false;
                    e.ErrorMessage = Localization.LastNameEmpty;
                }
                else if (e.Value != null && e.Value.ToString().Length > 0 && !(e.Value.ToString().Length >= 5))
                {
                    e.IsValid = false;
                    e.ErrorMessage = Localization.LastNameLength;
                }
            }
            if (e.PropertyName == "Address")
            {
                if (e.Value.ToString().Length == 0)
                {
                    e.IsValid = false;
                    e.ErrorMessage = Localization.AddressEmptyString;
                }
            }
        }
    }
}
