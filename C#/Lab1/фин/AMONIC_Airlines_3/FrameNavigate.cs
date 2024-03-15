using System.Windows.Controls;

namespace AMONIC_Airlines_3
{
    public static class FrameNavigate
    {
        public static Frame frame { get; set; }

        public static void NavigateTo(Page page)
        {
            frame.Navigate(page);
        }

        public static void RemovePage()
        {
            while (frame.CanGoBack)
                frame.RemoveBackEntry();
        }
    }
}
