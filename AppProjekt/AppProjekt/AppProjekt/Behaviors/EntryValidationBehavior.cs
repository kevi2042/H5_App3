using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppProjekt.Behaviors
{
    public class EntryValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEditorTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEditorTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
                double numbers;
                bool isValid = double.TryParse(args.NewTextValue, out numbers);
                ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
