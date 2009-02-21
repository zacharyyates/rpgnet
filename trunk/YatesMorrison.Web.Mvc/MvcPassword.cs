/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
    public class MvcPassword : MvcTextBox // todo: create a analog hierarchy for control interfaces?
    {
        public MvcPassword(string name)
            : base(name)
        {
            Type = InputType.Password;
        }
    }
}