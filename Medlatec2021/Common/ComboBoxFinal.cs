
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CMS_Core.Common
{
    public class ComboBoxFinal<AnyType>
    {
      
        /// <summary>  
        /// Get GetComboBox method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBox(List<AnyType> data, string IDField, string NameField, bool withEmtyRow)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                        }
                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

      

        /// <summary>  
        /// Get GetComboBoxBySelected method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBoxBySelected(List<AnyType> data, string IDField, string NameField, string ValueSelected, bool withEmtyRow)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            if (valueCombobox.Equals(ValueSelected))
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }

                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }


       
    }
}
