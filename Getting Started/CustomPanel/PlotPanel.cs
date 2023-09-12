using System.Windows;
using System.Windows.Controls;

namespace CustomPanel;

class PlotPanel : Panel {
    public PlotPanel() : base() { }

    // Override the default Measure method of Panel
    protected override Size MeasureOverride(Size availableSize) {
        Size panelDesiredSize = new();

        // In our example, we just have one child.
        // Report that our panel requires just the size of its only child.
        foreach (UIElement child in InternalChildren) {
            child.Measure(availableSize);
            panelDesiredSize = child.DesiredSize;
        }
        return panelDesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize) {
        foreach (UIElement child in InternalChildren) {
            double x = 50;
            double y = 50;
            child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
        }
        return finalSize;
    }
}

