using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerFront
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ServerFront"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ServerFront;assembly=ServerFront"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:AspectRatioLayoutDecorator/>
    ///
    /// </summary>
    public class AspectRatioLayoutDecorator : Decorator
    {
        public static readonly DependencyProperty AspectRatioProperty =
      DependencyProperty.Register(
              "AspectRatio",
              typeof( double ),
              typeof( AspectRatioLayoutDecorator ),
              new FrameworkPropertyMetadata
                 (
                    1d,
                    FrameworkPropertyMetadataOptions.AffectsMeasure
                 ),
              ValidateAspectRatio );

        private static bool ValidateAspectRatio( object value )
        {
            if( !(value is double) )
            {
                return false;
            }

            var aspectRatio = (double)value;
            return aspectRatio > 0
                     && !double.IsInfinity( aspectRatio )
                     && !double.IsNaN( aspectRatio );
        }

        public double AspectRatio
        {
            get { return (double)GetValue( AspectRatioProperty ); }
            set { SetValue( AspectRatioProperty, value ); }
        }

        protected override Size MeasureOverride( Size constraint )
        {
            if( Child != null )
            {
                constraint = SizeToRatio( constraint, false );
                Child.Measure( constraint );

                if( double.IsInfinity( constraint.Width )
                   || double.IsInfinity( constraint.Height ) )
                {
                    return SizeToRatio( Child.DesiredSize, true );
                }

                return constraint;
            }

            // we don't have a child, so we don't need any space
            return new Size( 0, 0 );
        }

        public Size SizeToRatio( Size size, bool expand )
        {
            double ratio = AspectRatio;

            double height = size.Width / ratio;
            double width = size.Height * ratio;

            if( expand )
            {
                width = Math.Max( width, size.Width );
                height = Math.Max( height, size.Height );
            }
            else
            {
                width = Math.Min( width, size.Width );
                height = Math.Min( height, size.Height );
            }

            return new Size( width, height );
        }

        protected override Size ArrangeOverride( Size arrangeSize )
        {
            if( Child != null )
            {
                var newSize = SizeToRatio( arrangeSize, false );

                double widthDelta = arrangeSize.Width - newSize.Width;
                double heightDelta = arrangeSize.Height - newSize.Height;

                double top = 0;
                double left = 0;

                if( !double.IsNaN( widthDelta )
                   && !double.IsInfinity( widthDelta ) )
                {
                    left = widthDelta / 2;
                }

                if( !double.IsNaN( heightDelta )
                   && !double.IsInfinity( heightDelta ) )
                {
                    top = heightDelta / 2;
                }

                var finalRect = new Rect( new Point( left, top ), newSize );
                Child.Arrange( finalRect );
            }

            return arrangeSize;
        }
    }

}
