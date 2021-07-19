using System.Windows;
using System.Windows.Controls;

namespace RateStarControl.CustomControl
{
    public class RateStar:Control
    {
         static RateStar()
        {
               DefaultStyleKeyProperty.OverrideMetadata(typeof(RateStar), new FrameworkPropertyMetadata(typeof(RateStar))); 
        }
    }
}