using System;
using FAB.Forms;
using Xamarin.Forms;

namespace FABSample
{
    public class CSharpExample : ContentPage
    {
        private FloatingActionButton miniFab;
        private FloatingActionButton normalFab;

        public CSharpExample()
        {
            this.Title = "C# Example";

            var layout = new RelativeLayout();

            var green = new Button()
            {
                Text = "Green",
                Command = new Command(() => { this.UpdateButtonColor(Color.Green); })
            };

            var red = new Button()
            {
                Text = "Red",
                Command = new Command(() => { this.UpdateButtonColor(Color.Red); })
            };

            var blue = new Button()
            {
                Text = "Blue",
                Command = new Command(() => { this.UpdateButtonColor(Color.Blue); })
            };

            var noShadow = new Button()
            {
                Text = "Change Shadow",
                Command = new Command(() =>
                {
                    this.miniFab.HasShadow = !this.miniFab.HasShadow;
                    this.normalFab.HasShadow = !this.normalFab.HasShadow;
                })
            };

            Button disable = null;
            disable = new Button()
            {
                Text = "Disabled",
                Command = new Command(() =>
                {
                    this.miniFab.IsEnabled = !this.normalFab.IsEnabled;
                    this.normalFab.IsEnabled = !this.normalFab.IsEnabled;

                    disable.Text = this.miniFab.IsEnabled ? "Disable" : "Enable";
                })
            };

            layout.Children.Add(
                new StackLayout
                {
                    Padding = new Thickness(15),
                    Children =
                    {
                        green,
                        red,
                        blue,
                        disable,
                        noShadow
                    }
                },
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height)
            );

            normalFab = new FloatingActionButton();
            normalFab.Source = "plus.png";
            normalFab.Size = FabSize.Normal;
            normalFab.RippleColor = Color.Gray;

            layout.Children.Add(
                normalFab,
                xConstraint: Constraint.RelativeToParent((parent) => { return (parent.Width - normalFab.Width) - 16; }),
                yConstraint: Constraint.RelativeToParent((parent) => { return (parent.Height - normalFab.Height) - 16; })
            );

            normalFab.SizeChanged += (sender, args) => { layout.ForceLayout(); };

            miniFab = new FloatingActionButton();
            miniFab.Source = "plus.png";
            miniFab.Size = FabSize.Mini;
            miniFab.RippleColor = Color.Gray;

            layout.Children.Add(
                miniFab,
                xConstraint: Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Width - miniFab.Width) - 16;
                }),
                yConstraint: Constraint.RelativeToView(normalFab, (parent, view) =>
                {
                    return (view.Y - miniFab.Height) - 16;
                })
            );
            miniFab.SizeChanged += (sender, args) => { layout.ForceLayout(); };


            normalFab.Clicked += (sender, e) =>
            {
                this.DisplayAlert("Floating Action Button", "You clicked the normal FAB!", "Awesome!");
            };

            miniFab.Clicked += (sender, e) =>
            {
                this.DisplayAlert("Floating Action Button", "You clicked the mini FAB!", "Awesome!");
            };

            this.Content = layout;
        }

        private void UpdateButtonColor(Color color)
        {
            var normal = color;
            var disabled = color.MultiplyAlpha(0.25);

            miniFab.NormalColor = normal;
            miniFab.DisabledColor = disabled;

            normalFab.NormalColor = normal;
            normalFab.DisabledColor = disabled;
        }
    }
}


