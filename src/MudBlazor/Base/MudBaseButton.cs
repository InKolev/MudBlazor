﻿using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MudBlazor
{
    public abstract class MudBaseButton : MudComponentBase
    {
      
        /// <summary>
        /// The HTML element that will be rendered in the root by the component
        /// </summary>
        [Parameter] public string HtmlTag { get; set; }


        /// <summary>
        /// The button Type (Button, Submit, Refresh)
        /// </summary>
        [Parameter] public ButtonType ButtonType { get; set; }

        /// <summary>
        /// If set to a URL, clicking the button will open the referenced document. Use Target to specify where
        /// </summary>
        [Parameter] public string Link { get; set; }

        /// <summary>
        /// The target attribute specifies where to open the link, if Link is specified. Possible values: _blank | _self | _parent | _top | <i>framename</i>
        /// </summary>
        [Parameter] public string Target { get; set; }

        /// <summary>
        /// If true, force browser to redirect outside component router-space.
        /// </summary>
        [Parameter] public bool ForceLoad { get; set; }

        /// <summary>
        /// Command executed when the user clicks on an element.
        /// </summary>
        [Parameter] public ICommand Command { get; set; }

        /// <summary>
        /// Command parameter.
        /// </summary>
        [Parameter] public object CommandParameter { get; set; }

        /// <summary>
        /// Button click event.
        /// </summary>
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected async Task OnClickHandler(MouseEventArgs ev)
        {          
                await OnClick.InvokeAsync(ev);
                if (Command?.CanExecute(CommandParameter) ?? false)
                {
                    Command.Execute(CommandParameter);
                }            
        }

        protected override void OnInitialized()
        {
            //default tag for a MudButton is "button"
            if (string.IsNullOrWhiteSpace(HtmlTag))
            {
                HtmlTag = "button";
            }

            //But if Link property is set, it changes to an anchor element automatically
            if (!string.IsNullOrWhiteSpace(Link))
            {
                HtmlTag = "a";
            }
            base.OnInitialized();
        }
    }
}
